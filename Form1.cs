using System.Windows.Forms;
using DeploymentTool;

namespace ProcessesStatus
{
    public partial class Form1 : Form
    {
        public Form1()
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
