﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShortageManager.model;

namespace ShortageManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // button1
        public void DispShortage ( object sender, EventArgs e )
        {
            Console.WriteLine ( sender.ToString() );
            ShowShortageFrame();
        }

        // button2
        public void DispHotSeller ( object sender, EventArgs e )
        {
            Console.WriteLine ( sender.ToString() );
            ShowSellerFrame();
        }

        // button3
        public void DispInsertData ( object sender, EventArgs e )
        {
            Console.WriteLine ( sender.ToString() );
            ShowInsertFrame();
        }

        // button4
        public void SearchShortageButton ( object sender, EventArgs e )
        {
            Console.WriteLine ( sender.ToString() );
        }

        // button5
        public void SearchHotSellerButton ( object sender, EventArgs e )
        {
            Console.WriteLine ( sender.ToString() );
        }

        // button6
        public void InsertDataButton ( object sender, EventArgs e )
        {
            Console.WriteLine ( sender.ToString() );
        }

        // button7
        public  void OpenFile_Click ( object sender, EventArgs e )
        {
            if ( openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox4.Clear();
                textBox4.Text = openFileDialog.FileName;
            }
            else
            {
                return;
            }


        }

        private void testMethod ()
        {
        }
    }
}
