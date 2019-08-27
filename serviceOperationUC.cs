using System;
using System.Drawing;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentTool
{
    public partial class serviceOperationUC : UserControl
    {
        private string serviceName;
        private ServiceController ServiceController;
        private bool ForceKill = false;
        private bool ForceStart = false;
        private ServiceControllerStatus LastStatus = ServiceControllerStatus.PausePending;

        public serviceOperationUC(string name)
        {
            serviceName = name;
            ServiceController = new ServiceController();
            ServiceController.ServiceName = serviceName;
            InitializeComponent();
        }


        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (!ForceKill && !ForceStart) return;
            timer1.Stop();
            ServiceController.Refresh();
            if (ForceKill && ServiceController.Status == ServiceControllerStatus.Running)
            {
                await ChangeState(ServiceControllerStatus.Stopped);
            }
            else
            {
                if (ForceStart && ServiceController.Status != ServiceControllerStatus.Running && ServiceController.StartType != ServiceStartMode.Disabled)
                {
                    await ChangeState(ServiceControllerStatus.Running);
                }
            }
            timer1.Start();
        }

        private void UpdateColorAndText()
        {
            ServiceController.Refresh();
            if (LastStatus == ServiceController.Status)
                return;
            LastStatus = ServiceController.Status;
            switch (LastStatus)
            {
                case ServiceControllerStatus.ContinuePending:
                    break;
                case ServiceControllerStatus.Paused:
                    break;
                case ServiceControllerStatus.PausePending:
                    break;
                case ServiceControllerStatus.Running:
                    BackColor = Color.GreenYellow;
                    break;
                case ServiceControllerStatus.StartPending:
                    BackColor = Color.LightGreen;
                    break;
                case ServiceControllerStatus.Stopped:
                    BackColor = Color.Transparent;
                    break;
                case ServiceControllerStatus.StopPending:
                    BackColor = Color.Gray;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            lblStartMode.Text = "startup mode: " + ServiceController.StartType;
            
        }
        private async void btnStopStart_Click(object sender, EventArgs e)
        {
            if (ServiceController.Status == ServiceControllerStatus.Stopped && ServiceController.StartType != ServiceStartMode.Disabled)
            {
                await ChangeState(ServiceControllerStatus.Running);
                ForceKill = false;
                ForceStart = true;
            }
            else if (ServiceController.Status == ServiceControllerStatus.Running)
            {
                ForceKill = true;
                ForceStart = false;
                await ChangeState(ServiceControllerStatus.Stopped);
            }
        }

        private Task ChangeState(ServiceControllerStatus requestStatus)
        {
            Console.WriteLine($"Starting the {serviceName} service...");

            return Task.Run(() =>
            {
                try
                {
                    ServiceController.Refresh();
                    // Start the service, and wait until its status is "Running".
                    if (ServiceController.Status != requestStatus)
                        if (requestStatus == ServiceControllerStatus.Running)
                        {
                            ServiceController.Start();
                            ServiceController.WaitForStatus(ServiceControllerStatus.Running,
                                new TimeSpan(0, 0, 40));
                        }
                        else
                        {
                            if (requestStatus == ServiceControllerStatus.Stopped)
                            {
                                ServiceController.Stop();
                                ServiceController.WaitForStatus(ServiceControllerStatus.Stopped,
                                    new TimeSpan(0, 0, 40));
                            }
                        }

                }
                catch

                    (InvalidOperationException e)
                {
                    Console.WriteLine($"Could not change the {serviceName} service: {e}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not change the {serviceName} service: {e}");
                }
            });
        }
        private void serviceOperationUC_Load(object sender, EventArgs e)
        {
            lblServiceName.Text = ServiceController.DisplayName;
            lblStartMode.Text = "startup mode: " + ServiceController.StartType;
            timer1.Enabled = true;
        }


        public void Start()
        {
            ForceKill = false;
            ForceStart = true;

        }

        public void Stop()
        {
            ForceKill = true;
            ForceStart = false;
        }

        private void timerUpdateColor_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateColorAndText();
                timerUpdateColor.Interval = 500;
            }
            catch (Exception)
            {
                try
                {
                    timerUpdateColor.Interval = 5000;
                    ServiceController = new ServiceController();
                    ServiceController.ServiceName = serviceName;

                }
                catch (Exception)
                {
                }

            }
        }
    }
}

