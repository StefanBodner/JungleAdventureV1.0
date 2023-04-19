namespace WorldCreator
{
    partial class frm_creator
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.cb_lifes = new System.Windows.Forms.ComboBox();
            this.cb_bullets = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_12 = new System.Windows.Forms.PictureBox();
            this.pb_13 = new System.Windows.Forms.PictureBox();
            this.pb_14 = new System.Windows.Forms.PictureBox();
            this.pb_15 = new System.Windows.Forms.PictureBox();
            this.pb_11 = new System.Windows.Forms.PictureBox();
            this.pb_02 = new System.Windows.Forms.PictureBox();
            this.pb_03 = new System.Windows.Forms.PictureBox();
            this.pb_04 = new System.Windows.Forms.PictureBox();
            this.pb_05 = new System.Windows.Forms.PictureBox();
            this.pb_06 = new System.Windows.Forms.PictureBox();
            this.pb_07 = new System.Windows.Forms.PictureBox();
            this.pb_08 = new System.Windows.Forms.PictureBox();
            this.pb_09 = new System.Windows.Forms.PictureBox();
            this.pb_10 = new System.Windows.Forms.PictureBox();
            this.pb_01 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6400, 480);
            this.panel1.TabIndex = 21;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 64;
            this.hScrollBar1.Location = new System.Drawing.Point(145, 562);
            this.hScrollBar1.Maximum = 5788;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(564, 17);
            this.hScrollBar1.SmallChange = 32;
            this.hScrollBar1.TabIndex = 24;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(931, 496);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(81, 93);
            this.btn_save.TabIndex = 26;
            this.btn_save.Text = "Save World";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(12, 496);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(79, 93);
            this.btn_exit.TabIndex = 27;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // cb_lifes
            // 
            this.cb_lifes.FormattingEnabled = true;
            this.cb_lifes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cb_lifes.Location = new System.Drawing.Point(778, 519);
            this.cb_lifes.Name = "cb_lifes";
            this.cb_lifes.Size = new System.Drawing.Size(121, 21);
            this.cb_lifes.TabIndex = 28;
            // 
            // cb_bullets
            // 
            this.cb_bullets.FormattingEnabled = true;
            this.cb_bullets.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cb_bullets.Location = new System.Drawing.Point(778, 570);
            this.cb_bullets.Name = "cb_bullets";
            this.cb_bullets.Size = new System.Drawing.Size(121, 21);
            this.cb_bullets.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(775, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Lifes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(775, 554);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Bullets";
            // 
            // pb_12
            // 
            this.pb_12.Location = new System.Drawing.Point(563, 519);
            this.pb_12.Name = "pb_12";
            this.pb_12.Size = new System.Drawing.Size(32, 32);
            this.pb_12.TabIndex = 20;
            this.pb_12.TabStop = false;
            this.pb_12.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_13
            // 
            this.pb_13.Location = new System.Drawing.Point(601, 519);
            this.pb_13.Name = "pb_13";
            this.pb_13.Size = new System.Drawing.Size(32, 32);
            this.pb_13.TabIndex = 19;
            this.pb_13.TabStop = false;
            this.pb_13.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_14
            // 
            this.pb_14.Location = new System.Drawing.Point(639, 519);
            this.pb_14.Name = "pb_14";
            this.pb_14.Size = new System.Drawing.Size(32, 32);
            this.pb_14.TabIndex = 18;
            this.pb_14.TabStop = false;
            this.pb_14.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_15
            // 
            this.pb_15.Location = new System.Drawing.Point(677, 519);
            this.pb_15.Name = "pb_15";
            this.pb_15.Size = new System.Drawing.Size(32, 32);
            this.pb_15.TabIndex = 17;
            this.pb_15.TabStop = false;
            this.pb_15.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_11
            // 
            this.pb_11.Location = new System.Drawing.Point(525, 519);
            this.pb_11.Name = "pb_11";
            this.pb_11.Size = new System.Drawing.Size(32, 32);
            this.pb_11.TabIndex = 11;
            this.pb_11.TabStop = false;
            this.pb_11.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_02
            // 
            this.pb_02.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pb_02.Location = new System.Drawing.Point(183, 519);
            this.pb_02.Name = "pb_02";
            this.pb_02.Size = new System.Drawing.Size(32, 32);
            this.pb_02.TabIndex = 10;
            this.pb_02.TabStop = false;
            this.pb_02.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_03
            // 
            this.pb_03.Location = new System.Drawing.Point(221, 519);
            this.pb_03.Name = "pb_03";
            this.pb_03.Size = new System.Drawing.Size(32, 32);
            this.pb_03.TabIndex = 9;
            this.pb_03.TabStop = false;
            this.pb_03.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_04
            // 
            this.pb_04.Location = new System.Drawing.Point(259, 519);
            this.pb_04.Name = "pb_04";
            this.pb_04.Size = new System.Drawing.Size(32, 32);
            this.pb_04.TabIndex = 8;
            this.pb_04.TabStop = false;
            this.pb_04.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_05
            // 
            this.pb_05.Location = new System.Drawing.Point(297, 519);
            this.pb_05.Name = "pb_05";
            this.pb_05.Size = new System.Drawing.Size(32, 32);
            this.pb_05.TabIndex = 7;
            this.pb_05.TabStop = false;
            this.pb_05.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_06
            // 
            this.pb_06.Location = new System.Drawing.Point(335, 519);
            this.pb_06.Name = "pb_06";
            this.pb_06.Size = new System.Drawing.Size(32, 32);
            this.pb_06.TabIndex = 6;
            this.pb_06.TabStop = false;
            this.pb_06.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_07
            // 
            this.pb_07.Location = new System.Drawing.Point(373, 519);
            this.pb_07.Name = "pb_07";
            this.pb_07.Size = new System.Drawing.Size(32, 32);
            this.pb_07.TabIndex = 5;
            this.pb_07.TabStop = false;
            this.pb_07.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_08
            // 
            this.pb_08.Location = new System.Drawing.Point(411, 519);
            this.pb_08.Name = "pb_08";
            this.pb_08.Size = new System.Drawing.Size(32, 32);
            this.pb_08.TabIndex = 4;
            this.pb_08.TabStop = false;
            this.pb_08.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_09
            // 
            this.pb_09.Location = new System.Drawing.Point(449, 519);
            this.pb_09.Name = "pb_09";
            this.pb_09.Size = new System.Drawing.Size(32, 32);
            this.pb_09.TabIndex = 3;
            this.pb_09.TabStop = false;
            this.pb_09.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_10
            // 
            this.pb_10.Location = new System.Drawing.Point(487, 519);
            this.pb_10.Name = "pb_10";
            this.pb_10.Size = new System.Drawing.Size(32, 32);
            this.pb_10.TabIndex = 2;
            this.pb_10.TabStop = false;
            this.pb_10.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pb_01
            // 
            this.pb_01.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pb_01.Location = new System.Drawing.Point(145, 519);
            this.pb_01.Name = "pb_01";
            this.pb_01.Size = new System.Drawing.Size(32, 32);
            this.pb_01.TabIndex = 1;
            this.pb_01.TabStop = false;
            this.pb_01.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(0, 480);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 127);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frm_creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_bullets);
            this.Controls.Add(this.cb_lifes);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb_12);
            this.Controls.Add(this.pb_13);
            this.Controls.Add(this.pb_14);
            this.Controls.Add(this.pb_15);
            this.Controls.Add(this.pb_11);
            this.Controls.Add(this.pb_02);
            this.Controls.Add(this.pb_03);
            this.Controls.Add(this.pb_04);
            this.Controls.Add(this.pb_05);
            this.Controls.Add(this.pb_06);
            this.Controls.Add(this.pb_07);
            this.Controls.Add(this.pb_08);
            this.Controls.Add(this.pb_09);
            this.Controls.Add(this.pb_10);
            this.Controls.Add(this.pb_01);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_creator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_creator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pb_01;
        private System.Windows.Forms.PictureBox pb_10;
        private System.Windows.Forms.PictureBox pb_09;
        private System.Windows.Forms.PictureBox pb_08;
        private System.Windows.Forms.PictureBox pb_07;
        private System.Windows.Forms.PictureBox pb_06;
        private System.Windows.Forms.PictureBox pb_05;
        private System.Windows.Forms.PictureBox pb_04;
        private System.Windows.Forms.PictureBox pb_03;
        private System.Windows.Forms.PictureBox pb_02;
        private System.Windows.Forms.PictureBox pb_12;
        private System.Windows.Forms.PictureBox pb_13;
        private System.Windows.Forms.PictureBox pb_14;
        private System.Windows.Forms.PictureBox pb_15;
        private System.Windows.Forms.PictureBox pb_11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ComboBox cb_lifes;
        private System.Windows.Forms.ComboBox cb_bullets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

