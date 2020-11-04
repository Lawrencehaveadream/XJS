using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2
{
    public partial class BottomForm : BaseSubForm
    {
        public BottomForm()
        {
            InitializeComponent();
        }

    

        private void Btn_SwitchSubFrom(object sender, EventArgs e)
        {
            if (((Button)sender).Tag != null)
            {
                FrmMgr.Show(((Button)sender).Tag.ToString());
            }
        }

      

        protected override void OnShown()
        {
            base.OnShown();
        }

        protected override void OnHide()
        {
            base.OnHide();
        }

    }
}
