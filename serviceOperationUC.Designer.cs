namespace DeploymentTool
{
    partial class serviceOperationUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.lblStartMode = new System.Windows.Forms.Label();
            this.btnStopStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerUpdateColor = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoEllipsis = true;
            this.lblServiceName.Location = new System.Drawing.Point(3, 1);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(327, 35);
            this.lblServiceName.TabIndex = 0;
            this.lblServiceName.Text = "Service Name";
            this.lblServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartMode
            // 
            this.lblStartMode.AutoEllipsis = true;
            this.lblStartMode.Location = new System.Drawing.Point(355, 1);
            this.lblStartMode.Name = "lblStartMode";
            this.lblStartMode.Size = new System.Drawing.Size(202, 35);
            this.lblStartMode.TabIndex = 1;
            this.lblStartMode.Text = "StartMode:";
            this.lblStartMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStopStart
            // 
            this.btnStopStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopStart.Location = new System.Drawing.Point(711, 1);
            this.btnStopStart.Name = "btnStopStart";
            this.btnStopStart.Size = new System.Drawing.Size(161, 35);
            this.btnStopStart.TabIndex = 2;
            this.btnStopStart.Text = "Stop / Start";
            this.btnStopStart.UseVisualStyleBackColor = true;
            this.btnStopStart.Click += new System.EventHandler(this.btnStopStart_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerUpdateColor
            // 
            this.timerUpdateColor.Enabled = true;
            this.timerUpdateColor.Interval = 500;
            this.timerUpdateColor.Tick += new System.EventHandler(this.timerUpdateColor_Tick);
            // 
            // serviceOperationUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStopStart);
            this.Controls.Add(this.lblStartMode);
            this.Controls.Add(this.lblServiceName);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "serviceOperationUC";
            this.Size = new System.Drawing.Size(885, 45);
            this.Load += new System.EventHandler(this.serviceOperationUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Label lblStartMode;
        private System.Windows.Forms.Button btnStopStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerUpdateColor;
    }
}
