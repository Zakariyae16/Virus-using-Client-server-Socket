namespace ServerTest
{
    partial class ServerStat
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerStat));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            serverIp_txt = new Guna.UI2.WinForms.Guna2TextBox();
            info_txtbox = new TextBox();
            label2 = new Label();
            ServerPort_txt = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            Start_btn = new Guna.UI2.WinForms.Guna2ImageButton();
            Stop_btn = new Guna.UI2.WinForms.Guna2ImageButton();
            status_imgbx = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            label4 = new Label();
            st_label = new Label();
            ((System.ComponentModel.ISupportInitialize)status_imgbx).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(40, 46);
            label1.Name = "label1";
            label1.Size = new Size(87, 22);
            label1.TabIndex = 0;
            label1.Text = "Server Ip";
            // 
            // serverIp_txt
            // 
            serverIp_txt.CustomizableEdges = customizableEdges8;
            serverIp_txt.DefaultText = "127.0.0.1";
            serverIp_txt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            serverIp_txt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            serverIp_txt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            serverIp_txt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            serverIp_txt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            serverIp_txt.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            serverIp_txt.ForeColor = Color.Black;
            serverIp_txt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            serverIp_txt.Location = new Point(133, 36);
            serverIp_txt.Name = "serverIp_txt";
            serverIp_txt.PasswordChar = '\0';
            serverIp_txt.PlaceholderText = "";
            serverIp_txt.SelectedText = "";
            serverIp_txt.ShadowDecoration.CustomizableEdges = customizableEdges9;
            serverIp_txt.Size = new Size(175, 40);
            serverIp_txt.TabIndex = 1;
            // 
            // info_txtbox
            // 
            info_txtbox.Location = new Point(118, 92);
            info_txtbox.Multiline = true;
            info_txtbox.Name = "info_txtbox";
            info_txtbox.ReadOnly = true;
            info_txtbox.ScrollBars = ScrollBars.Vertical;
            info_txtbox.Size = new Size(411, 290);
            info_txtbox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(314, 46);
            label2.Name = "label2";
            label2.Size = new Size(103, 22);
            label2.TabIndex = 3;
            label2.Text = "Server Port";
            // 
            // ServerPort_txt
            // 
            ServerPort_txt.CustomizableEdges = customizableEdges10;
            ServerPort_txt.DefaultText = "1616";
            ServerPort_txt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            ServerPort_txt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            ServerPort_txt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            ServerPort_txt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            ServerPort_txt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ServerPort_txt.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ServerPort_txt.ForeColor = Color.Black;
            ServerPort_txt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            ServerPort_txt.Location = new Point(423, 36);
            ServerPort_txt.Name = "ServerPort_txt";
            ServerPort_txt.PasswordChar = '\0';
            ServerPort_txt.PlaceholderText = "";
            ServerPort_txt.SelectedText = "";
            ServerPort_txt.ShadowDecoration.CustomizableEdges = customizableEdges11;
            ServerPort_txt.Size = new Size(100, 40);
            ServerPort_txt.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(634, 61);
            label3.Name = "label3";
            label3.Size = new Size(85, 22);
            label3.TabIndex = 5;
            label3.Text = "Client IP ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(552, 92);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(246, 290);
            textBox2.TabIndex = 6;
            textBox2.Text = "List Client Ip :";
            // 
            // Start_btn
            // 
            Start_btn.CheckedState.ImageSize = new Size(64, 64);
            Start_btn.HoverState.ImageSize = new Size(64, 64);
            Start_btn.Image = (Image)resources.GetObject("Start_btn.Image");
            Start_btn.ImageOffset = new Point(0, 0);
            Start_btn.ImageRotate = 0F;
            Start_btn.ImageSize = new Size(50, 50);
            Start_btn.Location = new Point(162, 425);
            Start_btn.Name = "Start_btn";
            Start_btn.PressedState.ImageSize = new Size(64, 64);
            Start_btn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            Start_btn.Size = new Size(43, 42);
            Start_btn.TabIndex = 7;
            Start_btn.Click += Start_btn_Click;
            // 
            // Stop_btn
            // 
            Stop_btn.CheckedState.ImageSize = new Size(64, 64);
            Stop_btn.HoverState.ImageSize = new Size(64, 64);
            Stop_btn.Image = (Image)resources.GetObject("Stop_btn.Image");
            Stop_btn.ImageOffset = new Point(0, 0);
            Stop_btn.ImageRotate = 0F;
            Stop_btn.ImageSize = new Size(50, 50);
            Stop_btn.Location = new Point(233, 425);
            Stop_btn.Name = "Stop_btn";
            Stop_btn.PressedState.ImageSize = new Size(64, 64);
            Stop_btn.ShadowDecoration.CustomizableEdges = customizableEdges13;
            Stop_btn.Size = new Size(43, 42);
            Stop_btn.TabIndex = 8;
            Stop_btn.Click += Stop_btn_Click;
            // 
            // status_imgbx
            // 
            status_imgbx.Image = (Image)resources.GetObject("status_imgbx.Image");
            status_imgbx.ImageRotate = 0F;
            status_imgbx.Location = new Point(518, 437);
            status_imgbx.Name = "status_imgbx";
            status_imgbx.ShadowDecoration.CustomizableEdges = customizableEdges14;
            status_imgbx.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            status_imgbx.Size = new Size(33, 30);
            status_imgbx.TabIndex = 9;
            status_imgbx.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(383, 437);
            label4.Name = "label4";
            label4.Size = new Size(129, 22);
            label4.TabIndex = 10;
            label4.Text = "Server status :";
            // 
            // st_label
            // 
            st_label.AutoSize = true;
            st_label.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            st_label.Location = new Point(544, 437);
            st_label.Name = "st_label";
            st_label.Size = new Size(136, 22);
            st_label.TabIndex = 11;
            st_label.Text = "Server is down";
            // 
            // ServerStat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(st_label);
            Controls.Add(label4);
            Controls.Add(status_imgbx);
            Controls.Add(Stop_btn);
            Controls.Add(Start_btn);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(ServerPort_txt);
            Controls.Add(label2);
            Controls.Add(info_txtbox);
            Controls.Add(serverIp_txt);
            Controls.Add(label1);
            Name = "ServerStat";
            Size = new Size(823, 508);
            Load += ServerStat_Load;
            ((System.ComponentModel.ISupportInitialize)status_imgbx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox serverIp_txt;
        private TextBox info_txtbox;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox ServerPort_txt;
        private Label label3;
        private TextBox textBox2;
        private Guna.UI2.WinForms.Guna2ImageButton Start_btn;
        private Guna.UI2.WinForms.Guna2ImageButton Stop_btn;
        private Guna.UI2.WinForms.Guna2CirclePictureBox status_imgbx;
        private Label label4;
        private Label st_label;
    }
}
