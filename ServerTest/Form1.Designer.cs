namespace ServerTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            Data_btn = new Guna.UI2.WinForms.Guna2Button();
            pnl_slide = new Panel();
            ServerStat_btn = new Guna.UI2.WinForms.Guna2Button();
            panel3 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btn_exit = new Button();
            btn_minimiser = new Button();
            pnl_tous = new Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(guna2Button1);
            panel1.Controls.Add(Data_btn);
            panel1.Controls.Add(pnl_slide);
            panel1.Controls.Add(ServerStat_btn);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 607);
            panel1.TabIndex = 0;
            // 
            // Data_btn
            // 
            Data_btn.Animated = true;
            Data_btn.BorderRadius = 22;
            Data_btn.Cursor = Cursors.Hand;
            Data_btn.CustomizableEdges = customizableEdges3;
            Data_btn.DisabledState.BorderColor = Color.DarkGray;
            Data_btn.DisabledState.CustomBorderColor = Color.DarkGray;
            Data_btn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Data_btn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Data_btn.FillColor = Color.White;
            Data_btn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Data_btn.ForeColor = SystemColors.ActiveCaptionText;
            Data_btn.Image = (Image)resources.GetObject("Data_btn.Image");
            Data_btn.ImageOffset = new Point(-13, 0);
            Data_btn.ImageSize = new Size(45, 45);
            Data_btn.Location = new Point(19, 271);
            Data_btn.Name = "Data_btn";
            Data_btn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Data_btn.Size = new Size(244, 64);
            Data_btn.TabIndex = 9;
            Data_btn.Text = "View Data";
            Data_btn.Click += Data_btn_Click;
            // 
            // pnl_slide
            // 
            pnl_slide.BackColor = Color.Red;
            pnl_slide.Location = new Point(3, 177);
            pnl_slide.Name = "pnl_slide";
            pnl_slide.Size = new Size(10, 64);
            pnl_slide.TabIndex = 0;
            // 
            // ServerStat_btn
            // 
            ServerStat_btn.Animated = true;
            ServerStat_btn.BorderRadius = 22;
            ServerStat_btn.Cursor = Cursors.Hand;
            ServerStat_btn.CustomizableEdges = customizableEdges5;
            ServerStat_btn.DisabledState.BorderColor = Color.DarkGray;
            ServerStat_btn.DisabledState.CustomBorderColor = Color.DarkGray;
            ServerStat_btn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ServerStat_btn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ServerStat_btn.FillColor = Color.White;
            ServerStat_btn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ServerStat_btn.ForeColor = SystemColors.ActiveCaptionText;
            ServerStat_btn.Image = (Image)resources.GetObject("ServerStat_btn.Image");
            ServerStat_btn.ImageOffset = new Point(-10, 0);
            ServerStat_btn.ImageSize = new Size(50, 50);
            ServerStat_btn.Location = new Point(19, 177);
            ServerStat_btn.Name = "ServerStat_btn";
            ServerStat_btn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ServerStat_btn.Size = new Size(244, 64);
            ServerStat_btn.TabIndex = 8;
            ServerStat_btn.Text = "Server Stat";
            ServerStat_btn.Click += ServerStat_btn_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.ForeColor = SystemColors.Control;
            panel3.Location = new Point(12, 136);
            panel3.Name = "panel3";
            panel3.Size = new Size(214, 5);
            panel3.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(36, 101);
            label1.Name = "label1";
            label1.Size = new Size(163, 23);
            label1.TabIndex = 8;
            label1.Text = "Remote Control";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(79, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(250, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(838, 23);
            panel2.TabIndex = 1;
            // 
            // btn_exit
            // 
            btn_exit.Cursor = Cursors.Hand;
            btn_exit.FlatAppearance.BorderSize = 0;
            btn_exit.FlatStyle = FlatStyle.Flat;
            btn_exit.Font = new Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_exit.ForeColor = SystemColors.Desktop;
            btn_exit.Location = new Point(1048, 24);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(40, 40);
            btn_exit.TabIndex = 6;
            btn_exit.Text = "X";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_minimiser
            // 
            btn_minimiser.FlatAppearance.BorderSize = 0;
            btn_minimiser.FlatStyle = FlatStyle.Flat;
            btn_minimiser.Image = (Image)resources.GetObject("btn_minimiser.Image");
            btn_minimiser.Location = new Point(1004, 24);
            btn_minimiser.Name = "btn_minimiser";
            btn_minimiser.Size = new Size(38, 40);
            btn_minimiser.TabIndex = 7;
            btn_minimiser.Text = " ";
            btn_minimiser.UseVisualStyleBackColor = true;
            btn_minimiser.Click += btn_minimiser_Click;
            // 
            // pnl_tous
            // 
            pnl_tous.Dock = DockStyle.Bottom;
            pnl_tous.Location = new Point(250, 70);
            pnl_tous.Name = "pnl_tous";
            pnl_tous.Size = new Size(838, 537);
            pnl_tous.TabIndex = 8;
            // 
            // guna2Button1
            // 
            guna2Button1.Animated = true;
            guna2Button1.BorderRadius = 22;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.White;
            guna2Button1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = SystemColors.ActiveCaptionText;
            guna2Button1.Image = (Image)resources.GetObject("guna2Button1.Image");
            guna2Button1.ImageOffset = new Point(-13, 0);
            guna2Button1.ImageSize = new Size(45, 45);
            guna2Button1.Location = new Point(19, 361);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(244, 64);
            guna2Button1.TabIndex = 10;
            guna2Button1.Text = "Outils";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 607);
            Controls.Add(pnl_tous);
            Controls.Add(btn_minimiser);
            Controls.Add(btn_exit);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btn_exit;
        private Button btn_minimiser;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_etudiant;
        private Guna.UI2.WinForms.Guna2Button ServerStat_btn;
        private Panel pnl_tous;
        private Panel pnl_slide;
        private Guna.UI2.WinForms.Guna2Button Data_btn;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}