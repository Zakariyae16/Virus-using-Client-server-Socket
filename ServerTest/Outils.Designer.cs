namespace ServerTest
{
    partial class Outils
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
            video_pictrbox = new PictureBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)video_pictrbox).BeginInit();
            SuspendLayout();
            // 
            // video_pictrbox
            // 
            video_pictrbox.BackColor = SystemColors.ActiveCaption;
            video_pictrbox.Location = new Point(124, 64);
            video_pictrbox.Name = "video_pictrbox";
            video_pictrbox.Size = new Size(683, 399);
            video_pictrbox.SizeMode = PictureBoxSizeMode.StretchImage;
            video_pictrbox.TabIndex = 0;
            video_pictrbox.TabStop = false;
            video_pictrbox.Click += video_pictrbox_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.Location = new Point(37, 17);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(189, 29);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Video En Directe";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
            // 
            // Outils
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(video_pictrbox);
            Name = "Outils";
            Size = new Size(823, 508);
            Load += Outils_Load;
            ((System.ComponentModel.ISupportInitialize)video_pictrbox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox video_pictrbox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
