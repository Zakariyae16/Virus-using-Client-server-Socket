﻿namespace ServerTest
{
    partial class viewData
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewData));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            data_dgv = new Guna.UI2.WinForms.Guna2DataGridView();
            btn_refresh = new Guna.UI2.WinForms.Guna2ImageButton();
            imgbox = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)data_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgbox).BeginInit();
            SuspendLayout();
            // 
            // data_dgv
            // 
            data_dgv.AllowUserToAddRows = false;
            data_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            data_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            data_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            data_dgv.ColumnHeadersHeight = 4;
            data_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            data_dgv.DefaultCellStyle = dataGridViewCellStyle6;
            data_dgv.GridColor = Color.FromArgb(231, 229, 255);
            data_dgv.Location = new Point(22, 55);
            data_dgv.Name = "data_dgv";
            data_dgv.RowHeadersVisible = false;
            data_dgv.RowHeadersWidth = 51;
            data_dgv.RowTemplate.Height = 29;
            data_dgv.Size = new Size(485, 381);
            data_dgv.TabIndex = 0;
            data_dgv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            data_dgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            data_dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            data_dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            data_dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            data_dgv.ThemeStyle.BackColor = Color.White;
            data_dgv.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            data_dgv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            data_dgv.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            data_dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            data_dgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            data_dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            data_dgv.ThemeStyle.HeaderStyle.Height = 4;
            data_dgv.ThemeStyle.ReadOnly = false;
            data_dgv.ThemeStyle.RowsStyle.BackColor = Color.White;
            data_dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            data_dgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            data_dgv.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            data_dgv.ThemeStyle.RowsStyle.Height = 29;
            data_dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            data_dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            data_dgv.CellContentClick += data_dgv_CellContentClick;
            // 
            // btn_refresh
            // 
            btn_refresh.CheckedState.ImageSize = new Size(64, 64);
            btn_refresh.Cursor = Cursors.Hand;
            btn_refresh.HoverState.ImageSize = new Size(64, 64);
            btn_refresh.Image = (Image)resources.GetObject("btn_refresh.Image");
            btn_refresh.ImageOffset = new Point(0, 0);
            btn_refresh.ImageRotate = 0F;
            btn_refresh.Location = new Point(113, 3);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.PressedState.ImageSize = new Size(64, 64);
            btn_refresh.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_refresh.Size = new Size(52, 35);
            btn_refresh.TabIndex = 18;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // imgbox
            // 
            imgbox.CustomizableEdges = customizableEdges5;
            imgbox.ImageRotate = 0F;
            imgbox.Location = new Point(558, 147);
            imgbox.Name = "imgbox";
            imgbox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            imgbox.Size = new Size(207, 217);
            imgbox.TabIndex = 19;
            imgbox.TabStop = false;
            // 
            // viewData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(imgbox);
            Controls.Add(btn_refresh);
            Controls.Add(data_dgv);
            Name = "viewData";
            Size = new Size(823, 581);
            Load += viewData_Load;
            ((System.ComponentModel.ISupportInitialize)data_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgbox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView data_dgv;
        private Guna.UI2.WinForms.Guna2ImageButton btn_refresh;
        private Guna.UI2.WinForms.Guna2PictureBox imgbox;
    }
}
