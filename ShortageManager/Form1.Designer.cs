using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShortageManager
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        private Panel panel1;
        private Panel panel2;

        private OpenFileDialog openFileDialog;

        private GroupBox groupBox1;
        private GroupBox groupBox2;

        private Button button1;
        private Button button2;
        private Button button3;

        private Font bold_font;
        private Font standard_font;

        private int recent_position = 0;

        private bool createdPosition1 = false;
        private bool createdPosition2 = false;
        private bool createdPosition3 = false;

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.standard_font = new Font ("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
            this.bold_font = new Font ("MS UI Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)));

            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = bold_font;
            this.button1.Location = new System.Drawing.Point(50, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "欠品検索";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.DispShortage);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = bold_font;
            this.button2.Location = new System.Drawing.Point(50, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 0;
            this.button2.Text = "売れ筋検索";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.DispHotSeller);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = bold_font;
            this.button3.Location = new System.Drawing.Point(50, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "データ登録";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.DispInsertData);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 500);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 500);
            this.panel2.TabIndex = 1;

            BaseFrameSearch();
            ShowShortageFrame();

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion



        private Label label1;       // 検索期間
        private Label label2;       // ～
        private Label label3;       // 部門
        private TextBox textBox1;   // 部門用テキストボックス
        private DateTimePicker dateTimePicker1; // 開始期間
        private DateTimePicker dateTimePicker2; // 終了期間

        // 検索画面用コントロールのインスタンス化
        protected void BaseFrameSearch ()
        {
            this.groupBox1 = new GroupBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.textBox1 = new TextBox();
            this.dateTimePicker1 = new DateTimePicker();
            this.dateTimePicker2 = new DateTimePicker();

            // 
            // groupBox1
            // 
            this.groupBox1.Location = new Point ( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size ( 580, 480 );
            this.groupBox1.TabStop = true;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = bold_font;
            this.label1.Location = new Point ( 48, 130 );
            this.label1.Name = "label1";
            this.label1.Size = new Size ( 25, 16 );
            this.label1.Text = "検索期間　:";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = bold_font;
            this.label2.Location = new Point(314, 130);
            this.label2.Name = "label1";
            this.label2.Size = new Size(25, 16);
            this.label2.Text = "～";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = bold_font;
            this.label3.Location = new Point(48, 204);
            this.label3.Name = "label1";
            this.label3.Size = new Size(25, 16);
            this.label3.Text = " 部 門　:";
            //
            // dateTimePicker1
            //
            this.dateTimePicker1.CalendarFont = standard_font;
            this.dateTimePicker1.Location = new Point ( 155, 128 );
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size ( 130, 19 );
            this.dateTimePicker1.TabIndex = 0;
            //
            // dateTimePicker2
            //
            this.dateTimePicker2.CalendarFont = standard_font;
            this.dateTimePicker2.Location = new Point ( 366, 130);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size ( 130, 19 );
            this.dateTimePicker2.TabIndex = 1;
            //
            // textBox1
            //
            this.textBox1.Font = standard_font;
            this.textBox1.Location = new Point ( 155, 204 );
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size ( 68, 23 );
            this.textBox1.TabIndex = 2;
            this.textBox1.TextAlign = HorizontalAlignment.Right;
            this.textBox1.KeyPress += new KeyPressEventHandler ( this.textBox_KeyPress );
        }


        // 欠品検索用コントロールのインスタンス化
        private void CreateInstanceForShortage ()
        {
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.textBox2 = new TextBox();
            this.textBox3 = new TextBox();
            this.button4 = new Button();

            //
            // label4
            //
            this.label4.AutoSize = false;
            this.label4.Font = new Font ( "MS UI Gothic", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)) );
            this.label4.Location = new Point ( 234, 30 );
            this.label4.Name = "label4";
            this.label4.Size = new Size ( 100, 20 );
            this.label4.Text = "欠品検索";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = bold_font;
            this.label5.Location = new Point ( 266, 204 );
            this.label5.Name = "label5";
            this.label5.Size = new Size ( 93, 20 );
            this.label5.Text = "　ＪＡＮ　:";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = bold_font;
            this.label6.Location = new Point ( 48, 278 );
            this.label6.Name = "label6";
            this.label6.Size = new Size ( 87, 16 );
            this.label6.Text = "　商品名　:";
            //
            // textBox2
            //
            this.textBox2.Font = standard_font;
            this.textBox2.Location = new Point ( 350, 204 );
            this.textBox2.Size = new Size ( 146, 23 );
            this.textBox2.MaxLength = 13;
            this.textBox2.Name = "textBox2";
            this.textBox2.TabIndex = 3;
            this.textBox2.TextAlign = HorizontalAlignment.Right;
            this.textBox2.KeyPress += new KeyPressEventHandler ( this.textBox_KeyPress );
            //
            // textBox3
            //
            this.textBox3.Font = standard_font;
            this.textBox3.Location = new Point ( 155, 278 );
            this.textBox3.Size = new Size ( 340, 23 );
            this.textBox3.Name = "textBox3";
            this.textBox3.TabIndex = 4;
            //
            // button4
            //
            this.button4.BackColor = SystemColors.ControlDarkDark;
            this.button4.Location = new Point(225, 408);
            this.button4.Name = "button4";
            this.button4.Size = new Size(75, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "検索";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new EventHandler ( this.SearchShortageButton );
        }

        // 売れ筋検索用コントロールのインスタンス化
        private void CreateInstanceForHotSeller ()
        {
            this.button5 = new Button();
            this.label7 = new Label();

            //
            // button5
            //
            this.button5.BackColor = SystemColors.ControlDarkDark;
            this.button5.Location = new Point(225, 408);
            this.button5.Name = "button4";
            this.button5.Size = new Size(75, 35);
            this.button5.TabIndex = 5;
            this.button5.Text = "検索";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new EventHandler ( this.SearchHotSellerButton );
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new Font("MS UI Gothic", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new Point(234, 30);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 20);
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.Text = "売れ筋検索";

        }

        // データ入力画面用コントロールのインスタンス化
        private void CreateInstanceForInsertData()
        {
            this.groupBox2 = new GroupBox();
            this.openFileDialog = new OpenFileDialog();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.textBox4 = new TextBox();
            this.button6 = new Button();
            this.button7 = new Button();

            // 
            // groupBox2
            // 
            this.groupBox2.Location = new Point(10, 10);
            this.groupBox2.Name = "groupBox1";
            this.groupBox2.Size = new Size(580, 480);
            this.groupBox2.TabStop = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xlsx";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "(*.csv)|*.csv";
            //
            // label8
            //
            this.label8.AutoSize = false;
            this.label8.Font = new Font("MS UI Gothic", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new Point(234, 30);
            this.label8.Name = "label4";
            this.label8.Size = new Size(100, 20);
            this.label8.Text = "データ入力";
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Font = bold_font;
            this.label9.Location = new Point(48, 130);
            this.label9.Name = "label1";
            this.label9.Size = new Size(25, 16);
            this.label9.Text = "　日　付　:";
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.Font = bold_font;
            this.label10.Location = new Point(48, 204);
            this.label10.Name = "label1";
            this.label10.Size = new Size(25, 16);
            this.label10.Text = " ファイル　:";
            //
            // textBox4
            //
            this.textBox4.Font = standard_font;
            this.textBox4.Location = new Point ( 155, 200 );
            this.textBox4.Size = new Size ( 200, 16 );
            this.textBox4.Name = "textBox4";
            this.textBox4.TabIndex = 1;
            //
            // button6
            //
            this.button6.BackColor = SystemColors.ControlDarkDark;
            this.button6.Font = bold_font;
            this.button6.Location = new Point(225, 408);
            this.button6.Name = "button4";
            this.button6.Size = new Size(75, 35);
            this.button6.TabIndex = 5;
            this.button6.Text = "登録";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new EventHandler ( this.InsertDataButton );
            //
            // button7  ファイル出力ダイアログ用
            //
            this.button7.BackColor = SystemColors.ControlDarkDark;
            this.button7.Font = bold_font;
            this.button7.Location = new Point( 360, 196 );
            this.button7.Size = new Size ( 30, 27 );
            this.button7.Name = "button7";
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.TabIndex = 2;
            this.button7.Click += new EventHandler ( this.OpenFile_Click );
        }

        private void AddControlsForShortage ()
        {
            this.groupBox1.Controls.Add( label1 );
            this.groupBox1.Controls.Add( label2 );
            this.groupBox1.Controls.Add( label3 );
            this.groupBox1.Controls.Add( label4 );
            this.groupBox1.Controls.Add( label5 );
            this.groupBox1.Controls.Add( label6 );
            this.groupBox1.Controls.Add( textBox1 );
            this.groupBox1.Controls.Add( textBox2 );
            this.groupBox1.Controls.Add( textBox3 );
            this.groupBox1.Controls.Add( dateTimePicker1 );
            this.groupBox1.Controls.Add( dateTimePicker2 );
            this.groupBox1.Controls.Add( button4);
        }

        private void AddControlsForHotSeller()
        {
            this.groupBox1.Controls.Add ( label1 );
            this.groupBox1.Controls.Add ( label2 );
            this.groupBox1.Controls.Add ( label3 );
            this.groupBox1.Controls.Add ( label7 );
            this.groupBox1.Controls.Add ( textBox1 );
            this.groupBox1.Controls.Add ( dateTimePicker1 );
            this.groupBox1.Controls.Add ( dateTimePicker2 );
            this.groupBox1.Controls.Add ( button5 );
        }


        private void AddControlsForInsertData()
        {
            this.groupBox2.Controls.Add ( label8 );
            this.groupBox2.Controls.Add ( label9 );
            this.groupBox2.Controls.Add ( label10 );
            this.groupBox2.Controls.Add ( textBox4 );
            this.groupBox2.Controls.Add ( dateTimePicker1 );
            this.groupBox2.Controls.Add ( button6 );
            this.groupBox2.Controls.Add ( button7 );
        }

        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button4;

        // 欠品検索画面   position = 1
        protected void ShowShortageFrame()
        {
            if (!createdPosition1)
            {
                CreateInstanceForShortage();
                createdPosition1 = true;
            }

            switch ( recent_position )
            {
                case 1:
                    return;
                case 2:
                    this.groupBox1.Controls.Clear();
                    AddControlsForShortage();
                    break;
                default:
                    this.panel2.Controls.Clear();
                    this.groupBox1.Controls.Clear();
                    AddControlsForShortage();
                    this.panel2.Controls.Add ( groupBox1 );
                    break;
            }

            this.panel2.Controls.Add(groupBox1);

            recent_position = 1;
            Console.WriteLine ( "recent_position = " + recent_position );
        }


        private Label label7;
        private Button button5;

        // 売れ筋検索画面  position = 2
        protected void ShowSellerFrame()
        {
            if (!createdPosition2)
            {
                CreateInstanceForHotSeller();
                createdPosition2 = true;
            }

            switch (recent_position)
            {
                case 1:
                    this.groupBox1.Controls.Clear();
                    AddControlsForHotSeller();
                    break;
                case 2:
                    return;
                case 3:
                    this.panel2.Controls.Clear();
                    this.groupBox1.Controls.Clear();
                    AddControlsForShortage();
                    this.panel2.Controls.Add(groupBox1);
                    break;
                default:
                    Console.WriteLine("想定外の値が入力されています。");
                    break;
            }

            this.groupBox1.Controls.Clear();
            AddControlsForHotSeller();
            
            recent_position = 2;
            Console.WriteLine ( "recent_position = " + recent_position );
        }


        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox4;
        private Button button6;
        private Button button7;

        // データ入力画面 position = 3
        protected void ShowInsertFrame()
        {
            if (recent_position == 3) return;

            if (!createdPosition3)
            {
                CreateInstanceForInsertData();
                this.createdPosition3 = true;
            }

            this.panel2.Controls.Clear();
            AddControlsForInsertData();
            this.panel2.Controls.Add ( groupBox2 );

            recent_position = 3;
            Console.WriteLine ("recent_position = " + recent_position);
        }


        private void textBox_KeyPress ( object sender, KeyPressEventArgs e )
        {
            if ( char.IsControl ( e.KeyChar ) )
            {
                e.Handled = false;
                return;
            }
            if ( char.IsDigit ( e.KeyChar ) )
            {
                e.Handled = false;
                return;
            }

            e.Handled = true;
        }
    }
}

