using HZZH.Database;
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
    public partial class 位置设置 : BottomForm
    {
        public 位置设置()
        {
            InitializeComponent();
        }

        private void 位置设置_Load(object sender, EventArgs e)
        {
            userBingData1.SetBindingDataSource(Product.Inst);
        }
    }
}
