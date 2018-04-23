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
        private Button button1;
        private Button button2;
        private Button button3;

        private Font button_font;
        private Font standard_font;


        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_font = new Font ( "MS UI Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)) );
            this.standard_font = new Font ( "MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)) );
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.panel1 = new Panel();
            this.SuspendLayout();

            // 
            // panel1
            // 
            this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.panel1.BackColor = SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 500);
            this.panel1.Controls.Add ( button1 );
            this.panel1.Controls.Add ( button2 );
            this.panel1.Controls.Add ( button3 );
            //
            // button1
            //
            this.button1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.button1.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Font = button_font;
            this.button1.Location = new Point ( 50, 50 );
            this.button1.Name = "button1";
            this.button1.Size = new Size ( 100, 30 );
            this.button1.TabIndex = 0;
            this.button1.Text = "欠品検索";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler ( this.DispShortage );
            //
            // button2
            //
            this.button2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.button2.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.Font = button_font;
            this.button2.Location = new Point ( 50, 130 );
            this.button2.Name = "button2";
            this.button2.Size = new Size(100, 30);
            this.button2.TabIndex = 0;
            this.button2.Text = "売れ筋検索";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler ( this.DispHotSeller );
            //
            // button3
            //
            this.button3.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.button3.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            this.button3.FlatStyle = FlatStyle.Flat;
            this.button3.Font = button_font;
            this.button3.Location = new Point ( 50, 210 );
            this.button3.Name = "button3";
            this.button3.Size = new Size(100, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "データ登録";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new EventHandler ( this.DispInsertData );

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout ( false );
            this.ResumeLayout(false);

        }



        #endregion



        private Label label1;       // 検索期間
        private Label label2;       // ～
        private Label label3;       // 部門
        private TextBox textBox1;   // 部門用テキストボックス
        private DateTimePicker dateTimePicker1; // 開始期間
        private DateTimePicker dateTimePicker2; // 終了期間

        protected void BaseFrameSearch ()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.textBox1 = new TextBox();
            this.dateTimePicker1 = new DateTimePicker();
            this.dateTimePicker2 = new DateTimePicker();

            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = standard_font;
            this.label1.Location = new Point ( 46, 140 );
            this.label1.Name = "label1";
            this.label1.Size = new Size ( 25, 16 );
            this.label1.Text = "検索期間\t:";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = standard_font;
            this.label2.Location = new Point(46, 140);
            this.label2.Name = "label1";
            this.label2.Size = new Size(25, 16);
            this.label2.Text = "～";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = standard_font;
            this.label3.Location = new Point(46, 140);
            this.label3.Name = "label1";
            this.label3.Size = new Size(25, 16);
            this.label3.Text = " 部 門\t:";
            //
            // dateTimePicker1
            //
            this.dateTimePicker1.CalendarFont = standard_font;
            this.dateTimePicker1.Location = new Point ( 153, 140 );
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size ( 130, 19 );
            this.dateTimePicker1.TabIndex = 0;
            //
            // dateTimePicker2
            //
            this.dateTimePicker2.CalendarFont = standard_font;
            this.dateTimePicker2.Location = new Point ( 364, 140);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size ( 130, 19 );
            this.dateTimePicker2.TabIndex = 1;
            //
            // textBox1
            //
            this.textBox1.Font = standard_font;
            this.textBox1.Location = new Point ( 153, 214 );
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size ( 68, 23 );
            this.textBox1.TabIndex = 2;
            this.textBox1.TextAlign = HorizontalAlignment.Right;
            this.textBox1.KeyPress += new KeyPressEventHandler ( this.textBox_KeyPress );
        }

        private Panel panel2;
        private Button button4;
        
        protected void ShowShortageFrame()
        {

        }

        protected void ShowSellerFrame()
        {

        }

        protected void ShowInsertFrame()
        {

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

