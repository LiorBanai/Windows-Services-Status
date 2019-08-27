using DeploymentTool;
using System.Windows.Forms;

namespace ProcessesStatus
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            ServicesUC uc = new ServicesUC();
            Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}
