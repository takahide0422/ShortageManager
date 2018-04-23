using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortageManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DispShortage ( object sender, EventArgs e )
        {
            ShowShortageFrame();
        }

        public void DispHotSeller ( object sender, EventArgs e )
        {
            ShowSellerFrame();
        }

        public void DispInsertData ( object sender, EventArgs e )
        {
            ShowInsertFrame();
        }
    }
}
