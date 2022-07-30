using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RcloneMountGUI
{
    public partial class RcloneMount : Form
    {
        public RcloneMount()
        {
            InitializeComponent();
            TrayMenuContext();

            // Default selection
            comboBoxMount.Text = "--vfs-cache-mode writes";

            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

                if (key.GetValue("RcloneMountGUI").ToString() == "\"" + Application.ExecutablePath + "\"" + " -tray")
                {
                    checkBoxRAAS.Checked = true;
                }
            }
            catch { }

            loadSettings();
        }

        string[] args = Environment.GetCommandLineArgs();

        #region Variables

        string rclonePath, rcloneFileName;

        #endregion

        #region Methods

        private void loadSettings()
        {
            // Loads settings from registry

            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\RcloneMountGUI", true);

            if (key != null)
            {
                try
                {
                    if (!String.IsNullOrEmpty(key.GetValue("RcloneLocation").ToString()))
                    {
                        txtRLocation.Text = key.GetValue("RcloneLocation").ToString();

                        rclonePath = Path.GetDirectoryName(txtRLocation.Text);
                        rcloneFileName = Path.GetFileNameWithoutExtension(txtRLocation.Text);
                    }
                }
                catch { }

                try
                {
                    if (!String.IsNullOrEmpty(key.GetValue("RemoteName").ToString()))
                    {
                        txtRemoteName.Text = key.GetValue("RemoteName").ToString();
                    }
                }
                catch { }

                try
                {
                    if (!String.IsNullOrEmpty(key.GetValue("DriveLetter").ToString()))
                    {
                        txtDriveLetter.Text = key.GetValue("DriveLetter").ToString();
                    }
                }
                catch { }
                try
                {
                    if (!String.IsNullOrEmpty(key.GetValue("MountOptions").ToString()))
                    {
                        comboBoxMount.Text = key.GetValue("MountOptions").ToString();
                    }
                }
                catch { }
            }
            else
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\RcloneMountGUI");
        }

        private void runTray()
        {
            // Minimizes to tray
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIconRclone.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        private void RcloneStart()
        {
            // Starts the mounting process
            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + rcloneFileName + " mount " + txtRemoteName.Text + ": " + txtDriveLetter.Text + ": " + comboBoxMount.Text;
            process.StartInfo.WorkingDirectory = rclonePath;
            process.Start();

            System.Threading.Thread.Sleep(1000);

            // Check if mounted
            if (this.WindowState != FormWindowState.Minimized)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process2 in processes)
                {
                    if (process2.ProcessName == rcloneFileName)
                    {
                        MessageBox.Show("Mounted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void RcloneKill()
        {
            // Kills the process
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName == rcloneFileName)
                {
                    process.Kill();
                    MessageBox.Show("Unmounted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TrayMenuContext()
        {
            this.notifyIconRclone.ContextMenuStrip = new ContextMenuStrip();
            this.notifyIconRclone.ContextMenuStrip.Items.Add("Show", null, this.Show_Click);
            this.notifyIconRclone.ContextMenuStrip.Items.Add("Exit", null, this.Exit_Click);
        }

        private string calculateMd5(string file)
        {
            // Calculates the md5 code of the file
            using (var md5Instance = MD5.Create())
            {
                using (var stream = File.OpenRead(file))
                {
                    var hashResult = md5Instance.ComputeHash(stream);
                    return BitConverter.ToString(hashResult).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private bool checkNewVersion(string md5Link)
        {
            // Checks for a new version

            WebClient client = new WebClient();

            string appName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string appCurrentVersion = calculateMd5(appName);

            string latestVersion = client.DownloadString(md5Link);

            if (appCurrentVersion == latestVersion || appCurrentVersion + "\n" == latestVersion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void updateApp(string appLink)
        {
            // Updates the application

            WebClient client = new WebClient();

            string appName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string tempFolder = Path.GetTempPath();
            string appPath = Application.StartupPath;

            client.DownloadFile(appLink, tempFolder + appName);

            try
            {
                File.Move(appName, tempFolder + appName + ".bak");
                File.Move(tempFolder + appName, appPath + "\\" + appName);
            }
            catch { }
        }

        public void clearOldVersion()
        {
            string appName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string tempFolder = Path.GetTempPath();

            try
            {
                if (File.Exists(tempFolder + appName))
                    File.Delete(tempFolder + appName);
            }
            catch { }

            try
            {
                if (File.Exists(tempFolder + appName + ".bak"))
                    File.Delete(tempFolder + appName + ".bak");
            }
            catch { }
        }

        #endregion

        #region Form tools

        private void RcloneMount_Load(object sender, EventArgs e)
        {
            backgroundWorkerRclone.RunWorkerAsync();

            // Starts the application according to the argument
            if (args.Length > 1)
            {
                if (!String.IsNullOrEmpty(args[1]))
                {
                    if (args[1] == "-tray")
                    {
                        this.WindowState = FormWindowState.Minimized;

                        runTray();
                        RcloneStart();
                    }
                }
            }
        }

        private void backgroundWorkerRclone_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            clearOldVersion();

            System.Threading.Thread.Sleep(2500);

            // If there is a new version of the application, it will ask for an update
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (!checkNewVersion("https://raw.githubusercontent.com/ImnLu/RcloneMountGUI/master/md5"))
                {
                    if (MessageBox.Show("A new version of the app is available. Would you like to update?", "Rclone Mount Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        updateApp("https://raw.githubusercontent.com/ImnLu/RcloneMountGUI/master/RcloneMountGUI.exe");
                        Application.Restart();
                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Saves requirement information
            if (openFileDialogRclone.ShowDialog() == DialogResult.OK)
            {
                txtRLocation.Text = openFileDialogRclone.FileName;
                rclonePath = Path.GetDirectoryName(openFileDialogRclone.FileName);
                rcloneFileName = Path.GetFileNameWithoutExtension(openFileDialogRclone.SafeFileName);
            }
        }

        private void btnMount_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRLocation.Text) || String.IsNullOrEmpty(txtRemoteName.Text) || String.IsNullOrEmpty(txtDriveLetter.Text))
            {
                MessageBox.Show("Please fill in the required information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Saves settings
                RegistryKey key;
                key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\RcloneMountGUI", true);

                key.SetValue("RcloneLocation", txtRLocation.Text);
                key.SetValue("RemoteName", txtRemoteName.Text);
                key.SetValue("DriveLetter", txtDriveLetter.Text);
                key.SetValue("MountOptions", comboBoxMount.Text);

                RcloneStart();
            }
        }

        private void btnUnmount_Click(object sender, EventArgs e)
        {
            RcloneKill();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRLocation.Text))
            {
                MessageBox.Show("Please fill the 'Rclone Location'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Opens rclone config settings

                Hide();

                rclonePath = Path.GetDirectoryName(txtRLocation.Text);
                rcloneFileName = Path.GetFileNameWithoutExtension(txtRLocation.Text);

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C " + rcloneFileName + " config";
                process.StartInfo.WorkingDirectory = rclonePath;
                process.Start();
                process.WaitForExit();

                Show();
            }
        }

        private void checkBoxRAAS_CheckedChanged(object sender, EventArgs e)
        {
            // Run automatically at startup settings
            if (checkBoxRAAS.Checked)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("RcloneMountGUI", "\"" + Application.ExecutablePath + "\"" + " -tray");
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue("RcloneMountGUI");
            }
        }

        private void linklblDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://rclone.org/commands/rclone_mount/#vfs-file-caching");
        }

        private void RcloneMount_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIconRclone.Visible = true;
            }
        }

        private void notifyIconRclone_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIconRclone.Visible = false;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIconRclone.Visible = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            RcloneKill();
            Application.Exit();
        }

        private void RcloneMount_FormClosed(object sender, FormClosedEventArgs e)
        {
            RcloneKill();
            Application.Exit();
        }

        #endregion
    }
}