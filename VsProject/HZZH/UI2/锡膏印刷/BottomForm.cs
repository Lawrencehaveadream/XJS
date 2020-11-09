using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HzControl.Communal.Controls;
using HZZH.UI2;

namespace HZZH.UI2.锡膏印刷
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
            foreach (var item in UserBingData.GetControls<Button>(this.panel1))
            {
                if (item.Tag.ToString() == this.GetType().Name)
                {
                    item.BackColor = Color.CadetBlue;
                    item.Focus();
                }
            }
        }

        protected override void OnHide()
        {
            base.OnHide();
            foreach (var item in UserBingData.GetControls<Button>(this.panel1))
            {
                item.BackColor = SystemColors.Control;
                SelectButton(item);
            }
        }

  

        private static void SelectButton(Button button)
        {
            System.Reflection.MethodInfo methodinfo = button.GetType().GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            methodinfo.Invoke(button, System.Reflection.BindingFlags.NonPublic, null, new object[] { ControlStyles.Selectable, false }, null);
        }
    }
}
