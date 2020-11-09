using HZZH.UI2.锡膏印刷;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2.锡膏印刷
{
    public partial class ParamForm : BottomForm
    {
        public ParamForm()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag != null)
            {
                FrmMgr.Show(((Button)sender).Tag.ToString());
            }
        }
    }
}
