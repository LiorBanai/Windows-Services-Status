using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentTool
{
    public partial class ServicesUC : UserControl
    {
        private List<string> Services = new List<string>
        {
        };

        private List<string> Apps = new List<string>
        {

        };

        private List<serviceOperationUC> ServicesUCs = new List<serviceOperationUC>();
        private List<string> Exists;
        public ServicesUC()
        {
            InitializeComponent();
        }

        private void ServicesUC_Load(object sender, EventArgs e)
        {
            var allServices = ServiceController.GetServices().Select(itm => itm.ServiceName);
            Exists = Services.Where(ser => allServices.Contains(ser)).ToList();
            foreach (var service in Exists)
            {
                serviceOperationUC uc = new serviceOperationUC(service);
                splitContainer1.Panel2.Controls.Add(uc);
                uc.Dock = DockStyle.Top;
                ServicesUCs.Add(uc);
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (timerKill.Enabled)
            {
                timerKill.Enabled = false;
                btnKill.Text = "Kill'em all (and stay dead!)";
            }
            else
            {
                timerKill.Enabled = true;
                btnKill.Text = "Kill'em all (and stay dead!)" + " - Running";
                btnKill.Enabled = false;
            }

        }

        private async void timerKill_Tick(object sender, EventArgs e)
        {
            timerKill.Stop();
            try
            {

                foreach (var uc in ServicesUCs)
                {
                    uc.Stop();
                }
                /// await ExecuteBatchFile();
                //var active = Process.GetProcesses().Where(p => Apps.Contains(p.ProcessName));
                //foreach (var app in active)
                //{
                //    try
                //    {
                //        app.Kill();
                //    }
                //    catch (Exception)
                //    {

                //    }
                //}
            }
            finally
            {
                timerKill.Start();
                btnKill.Enabled = true;
            }
        }

        private Task KillInCMD(string processName)
        {
            return Task.Run(() =>
            {
                string argument = $"/c net stop {processName} /y";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("CMD.exe")
                {
                    Arguments = argument,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false,


                };
                Process p = new Process();
                p.OutputDataReceived += P_OutputDataReceived;
                p.ErrorDataReceived += P_ErrorDataReceived;
                p.StartInfo = procStartInfo;
                p.EnableRaisingEvents = true;

                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
            });

        }
        private Task ExecuteBatchFile()
        {
            return Task.Run(() =>
            {
                string argument = $"/c KillemAll.bat";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("CMD.exe")
                {
                    Arguments = argument,
                    //WindowStyle = ProcessWindowStyle.Hidden,
                    //RedirectStandardError = true,
                    //RedirectStandardOutput = true,
                    //CreateNoWindow = true,
                    //UseShellExecute = false,
                    WorkingDirectory = Environment.CurrentDirectory

                };
                Process p = new Process();
                p.OutputDataReceived += P_OutputDataReceived;
                p.ErrorDataReceived += P_ErrorDataReceived;
                p.StartInfo = procStartInfo;
                p.EnableRaisingEvents = true;

                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
            });

        }
        private void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => richTextBox1.Text += Environment.NewLine + e.Data));

        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => richTextBox1.Text += Environment.NewLine + e.Data));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerKill.Enabled = false;
            btnKill.Text = "Kill'em all (and stay dead!)";

            foreach (var uc in ServicesUCs)
            {
                uc.Start();
            }
        }

        private void btnDebugfile_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"D:\debug_break.cfg"))
                Process.Start(@"D:\debug_break.cfg");
        }
    }
}
