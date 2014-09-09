using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using OronUtil.Collections;

namespace PrimeSharp
{
    public partial class Form1 : Form
    {
        readonly PerformanceCounter _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        public Form1()
        {
            InitializeComponent();
            UpdateSysInfo();
        }

        private void UpdateSysInfo()
        {
            sysInfoLabel.Text = "System Info: ";
            sysInfoLabel.Text += String.Format("\n{0} CPU threads\n{1}-bit Process.\n{2}-bit OS.",
                Environment.ProcessorCount,
                Environment.Is64BitProcess ? 64 : 32,
                Environment.Is64BitOperatingSystem ? 64 : 32);
            sysInfoLabel.Text += "\nAvailable memory (MiB): " + (int)_ramCounter.NextValue();
            if (!Environment.Is64BitProcess && Environment.Is64BitOperatingSystem)
                sysInfoLabel.Text += "\nWarning: Running in 32-bit mode on 64-bit OS.\nPlease use the 64-bit version to prevent memory issues.";
        }

        private long GetLen()
        {
            return long.Parse(txtLength.Text);
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                txtFilename.Text = sfd.FileName;
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            UpdateSysInfo();
            var len = GetLen();
            var file = txtFilename.Text;
            if (len / 8388608 > _ramCounter.NextValue())
            {
                MessageBox.Show("Not enough memory! Aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (len / 8 > new DriveInfo(new DriveInfo(new FileInfo(file).DirectoryName).Name).AvailableFreeSpace)
            {
                MessageBox.Show("Not enough disk space! Aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            logLabel.Text = "";
            logLabel.Text += "Starting Calculation!";
            UseWaitCursor = true;
            var primeData = new LongBitArray(32);
            long count = 0;
            Stopwatch sw0 = new Stopwatch(), 
                sw1 = new Stopwatch(),
                sw2 = new Stopwatch();
            sw0.Start();

            logLabel.Text += "\nCalling GetPrimes()...";
            sw1.Start();
            var th1 = new Thread(() => primeData = Engine.GetPrimes(len));
            th1.Start();
            th1.Join();
            sw1.Stop();
            logLabel.Text += "\nReturned in " + sw1.Elapsed;

            logLabel.Text += "\nCalling Save()...";
            sw2.Start();
            var th3 = new Thread(() => count = Engine.Save(primeData.Data, file));
            th3.Start();
            th3.Join();
            sw2.Stop();
            logLabel.Text += "\nReturned in " + sw2.Elapsed + "\nPrimes found: " + count;

            sw0.Stop();
            logLabel.Text += "\nTotal time: " + sw0.Elapsed;

            logLabel.Text += "\nFreeing memory...";
            primeData = null;
            GC.Collect();
            logLabel.Text += "\nFinished.";
            UseWaitCursor = false;
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var len = GetLen();
                memUseLabel.Text = "Est. memory usage / file size: " + (int)(len / 8388608) + " MiB";
            }
            catch
            {
                memUseLabel.Text = "Est. memory usage / file size: ";
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateSysInfo();
        }
    }
}
