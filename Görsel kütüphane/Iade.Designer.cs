
namespace Görsel_kütüphane
{
    partial class Iade
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKontrol = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnIade = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtIade = new System.Windows.Forms.DateTimePicker();
            this.cbKitap = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOgrenci = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKontrol
            // 
            this.btnKontrol.Location = new System.Drawing.Point(622, 189);
            this.btnKontrol.Margin = new System.Windows.Forms.Padding(2);
            this.btnKontrol.Name = "btnKontrol";
            this.btnKontrol.Size = new System.Drawing.Size(77, 36);
            this.btnKontrol.TabIndex = 39;
            this.btnKontrol.Text = "Kontrol Et";
            this.btnKontrol.UseVisualStyleBackColor = true;
            this.btnKontrol.Click += new System.EventHandler(this.btnKontrol_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(79, 251);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(643, 156);
            this.dataGridView1.TabIndex = 38;
            // 
            // btnIade
            // 
            this.btnIade.Location = new System.Drawing.Point(344, 191);
            this.btnIade.Margin = new System.Windows.Forms.Padding(2);
            this.btnIade.Name = "btnIade";
            this.btnIade.Size = new System.Drawing.Size(107, 32);
            this.btnIade.TabIndex = 28;
            this.btnIade.Text = "İade";
            this.btnIade.UseVisualStyleBackColor = true;
            this.btnIade.Click += new System.EventHandler(this.btnIade_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "İade Tarihi";
            // 
            // dtIade
            // 
            this.dtIade.Location = new System.Drawing.Point(329, 135);
            this.dtIade.Margin = new System.Windows.Forms.Padding(2);
            this.dtIade.Name = "dtIade";
            this.dtIade.Size = new System.Drawing.Size(164, 20);
            this.dtIade.TabIndex = 24;
            // 
            // cbKitap
            // 
            this.cbKitap.FormattingEnabled = true;
            this.cbKitap.Location = new System.Drawing.Point(329, 83);
            this.cbKitap.Margin = new System.Windows.Forms.Padding(2);
            this.cbKitap.Name = "cbKitap";
            this.cbKitap.Size = new System.Drawing.Size(152, 21);
            this.cbKitap.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Kitap";
            // 
            // cbOgrenci
            // 
            this.cbOgrenci.FormattingEnabled = true;
            this.cbOgrenci.Location = new System.Drawing.Point(329, 43);
            this.cbOgrenci.Margin = new System.Windows.Forms.Padding(2);
            this.cbOgrenci.Name = "cbOgrenci";
            this.cbOgrenci.Size = new System.Drawing.Size(152, 21);
            this.cbOgrenci.TabIndex = 32;
            this.cbOgrenci.SelectedIndexChanged += new System.EventHandler(this.cbOgrenci_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Öğrenci";
            // 
            // Iade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKontrol);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnIade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtIade);
            this.Controls.Add(this.cbKitap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbOgrenci);
            this.Controls.Add(this.label1);
            this.Name = "Iade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iade";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKontrol;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnIade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtIade;
        private System.Windows.Forms.ComboBox cbKitap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOgrenci;
        private System.Windows.Forms.Label label1;
    }
}