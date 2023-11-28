namespace DemCuu
{
    partial class formBai4
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBai4));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblKhoiLuongLong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKhoiLuong = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvSheepsDetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconIML = new System.Windows.Forms.ImageList(this.components);
            this.pbSheepColor = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSheepColor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtSoluong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(293, 15);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(212, 15);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(131, 15);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(62, 17);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(63, 20);
            this.txtSoluong.TabIndex = 1;
            this.txtSoluong.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbSheepColor);
            this.groupBox2.Controls.Add(this.lblKhoiLuongLong);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblKhoiLuong);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblStt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblKhoiLuongLong
            // 
            this.lblKhoiLuongLong.AutoSize = true;
            this.lblKhoiLuongLong.Location = new System.Drawing.Point(420, 20);
            this.lblKhoiLuongLong.Name = "lblKhoiLuongLong";
            this.lblKhoiLuongLong.Size = new System.Drawing.Size(0, 13);
            this.lblKhoiLuongLong.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Khối lượng lông:";
            // 
            // lblKhoiLuong
            // 
            this.lblKhoiLuong.AutoSize = true;
            this.lblKhoiLuong.Location = new System.Drawing.Point(265, 20);
            this.lblKhoiLuong.Name = "lblKhoiLuong";
            this.lblKhoiLuong.Size = new System.Drawing.Size(0, 13);
            this.lblKhoiLuong.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Khối lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Màu sắc:";
            // 
            // lblStt
            // 
            this.lblStt.AutoSize = true;
            this.lblStt.Location = new System.Drawing.Point(48, 20);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(0, 13);
            this.lblStt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "STT:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvSheepsDetail);
            this.groupBox3.Location = new System.Drawing.Point(12, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(483, 313);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lvSheepsDetail
            // 
            this.lvSheepsDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvSheepsDetail.GridLines = true;
            this.lvSheepsDetail.HideSelection = false;
            this.lvSheepsDetail.Location = new System.Drawing.Point(7, 20);
            this.lvSheepsDetail.Name = "lvSheepsDetail";
            this.lvSheepsDetail.Size = new System.Drawing.Size(470, 287);
            this.lvSheepsDetail.TabIndex = 0;
            this.lvSheepsDetail.UseCompatibleStateImageBehavior = false;
            this.lvSheepsDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Khối lượng";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Màu sắc";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Khối lượng lông";
            this.columnHeader4.Width = 120;
            // 
            // iconIML
            // 
            this.iconIML.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconIML.ImageStream")));
            this.iconIML.TransparentColor = System.Drawing.Color.Transparent;
            this.iconIML.Images.SetKeyName(0, "den.png");
            this.iconIML.Images.SetKeyName(1, "trang.png");
            this.iconIML.Images.SetKeyName(2, "xam.png");
            // 
            // pbSheepColor
            // 
            this.pbSheepColor.Location = new System.Drawing.Point(146, 19);
            this.pbSheepColor.Name = "pbSheepColor";
            this.pbSheepColor.Size = new System.Drawing.Size(30, 18);
            this.pbSheepColor.TabIndex = 9;
            this.pbSheepColor.TabStop = false;
            // 
            // formBai4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "formBai4";
            this.Text = "Bài 4";
            this.Load += new System.EventHandler(this.formBai4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSheepColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKhoiLuongLong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKhoiLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvSheepsDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ImageList iconIML;
        private System.Windows.Forms.PictureBox pbSheepColor;
    }
}

