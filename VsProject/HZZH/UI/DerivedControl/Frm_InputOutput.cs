using System;
using System.Drawing;
using System.Windows.Forms;
using CommonRs;
using ConfigSpace;
using System.IO;
using System.Collections.Generic;
using System.Resources;
using System.ComponentModel;
using System.Reflection;

namespace MyControl
{
    public partial class InputOutput : Form, IDisposable
    {
        public InputOutput(Device.MotionCardDef movedriverZm, string InputCsvName, string OutputCsvName)
        {
            InitializeComponent();
            this.movedriverZm = movedriverZm;
            ConfigInput = new ConfigInputDef(InputCsvName);
            ConfigOutput = new ConfigOutputDef(OutputCsvName);
            Initializel();

            DoubleBufferedDataGirdView(dataGridViewIN, true);
            DoubleBufferedDataGirdView(dataGridViewOUT, true);
            dataGridViewIN.ClearSelection();
            dataGridViewOUT.ClearSelection();
        }

        Color clrSignalOFF = Color.Gray;
        Color clrSignalON = Color.Green;
        ConfigInputDef ConfigInput;
        ConfigOutputDef ConfigOutput;
        void Initializel()
        {
            dataGridViewIN.ColumnCount = 2;
            dataGridViewIN.Columns[0].Name = "输入";
            //dataGridViewIN.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Blue;
            //dataGridViewIN.Columns[0].DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridViewIN.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewIN.Columns[1].Name = "值";
            dataGridViewIN.Columns[1].DefaultCellStyle.ForeColor = clrSignalOFF;
            dataGridViewIN.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewIN.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewIN.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewIN.Columns[1].DefaultCellStyle.Font = new Font(this.dataGridViewOUT.Font.FontFamily, 10, FontStyle.Bold);
            dataGridViewIN.Columns[1].Width = 50;
            //dataGridViewIN.Columns[1].DefaultCellStyle.SelectionBackColor = Color.LightGray;
            //dataGridViewIN.Columns[1].DefaultCellStyle.SelectionForeColor = Color.Blue;

            DataGridViewImageColumn icINSensor = new DataGridViewImageColumn();
            icINSensor.HeaderText = "状态";
            icINSensor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            icINSensor.Image = imageList1.Images["Gray.png"];
            icINSensor.Name = "";
            icINSensor.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewIN.Columns.Add(icINSensor);
            //dataGridViewIN.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            for (int i = 0; i < ConfigInput.InputNamelist.Count; i++)
            {
                dataGridViewIN.Rows.Add(new string[] { ConfigInput.InputNamelist[i], "OFF" });
                dataGridViewIN.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                dataGridViewIN.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                this.dataGridViewIN.Rows[i].DefaultCellStyle.BackColor = i % 2 == 0 ? SystemColors.Control : SystemColors.ControlLight;
                this.dataGridViewIN.Rows[i].DefaultCellStyle.SelectionBackColor = i % 2 == 0 ? SystemColors.Control : SystemColors.ControlLight;
            }
           

            dataGridViewOUT.ColumnCount = 1;
            dataGridViewOUT.Columns[0].Name = "输出";
            dataGridViewOUT.Columns[0].ReadOnly = true;
            dataGridViewOUT.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewOUT.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewOUT.Columns[0].DefaultCellStyle.ForeColor = Color.Black;

            //dataGridViewOUT.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            //dataGridViewOUT.Columns[1].Name = "值";
            //dataGridViewOUT.Columns[1].DefaultCellStyle.ForeColor = clrSignalOFF;
            //dataGridViewOUT.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridViewOUT.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridViewOUT.Columns[1].DefaultCellStyle.Font = new Font(this.dataGridViewOUT.Font.FontFamily, 10, FontStyle.Bold);
            //dataGridViewOUT.Columns[1].Width = 50;

            DataGridViewImageColumn icOUTSensor1 = new DataGridViewImageColumn();
            icOUTSensor1.HeaderText = "按钮";
            icOUTSensor1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            icOUTSensor1.Image = imageList2.Images["buttonOFF.png"];
            icOUTSensor1.Name = "";
            icOUTSensor1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOUT.Columns.Add(icOUTSensor1);
         


            DataGridViewImageColumn icOUTSensor2 = new DataGridViewImageColumn();
            icOUTSensor2.HeaderText = "状态";
            icOUTSensor2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            icOUTSensor2.Image = imageList1.Images["Gray.png"];
            icOUTSensor2.Name = "";
            icOUTSensor2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewOUT.Columns.Add(icOUTSensor2);



            dataGridViewOUT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOUT.EnableHeadersVisualStyles = false;


            for (int i = 0; i < ConfigOutput.OutputNamelist.Count; i++)
            {
                dataGridViewOUT.Rows.Add(new string[] { ConfigOutput.OutputNamelist[i]});
                dataGridViewOUT.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Blue;
                dataGridViewOUT.Rows[i].DefaultCellStyle.SelectionBackColor= Color.Pink;
                this.dataGridViewOUT.Rows[i].DefaultCellStyle.BackColor = i % 2 == 0 ? SystemColors.Control : SystemColors.ControlLight;
            }
        }
        private Device.MotionCardDef movedriverZm;
        public void ValueChangedRefresh()
        {
            //dataGridViewOUT.SuspendLayout();
            DIDOStatus_ValueChanged();
        }

        void DIDOStatus_ValueChanged()
        {
            for (int i = 0; i < ConfigInput.InputBit.Count; i++)
            {
                if (movedriverZm.MotionFun.InputGet(i))
                {
                    if (String.Equals(dataGridViewIN.Rows[i].Cells[1].Value, "ON") == false)
                    {
                        dataGridViewIN.Rows[i].Cells[1].Value = "ON";
                        dataGridViewIN.Rows[i].Cells[1].Style.ForeColor = clrSignalON;
                        dataGridViewIN.Rows[i].Cells[2].Value = imageList1.Images["Green.png"];
                    }
                }
                else
                {
                    if (String.Equals(dataGridViewIN.Rows[i].Cells[1].Value, "OFF") == false)
                    {
                        dataGridViewIN.Rows[i].Cells[1].Value = "OFF";
                        dataGridViewIN.Rows[i].Cells[1].Style.ForeColor = clrSignalOFF;
                        dataGridViewIN.Rows[i].Cells[2].Value = imageList1.Images["Gray.png"];
                    }
                }
            }
            dataGridViewIN.Refresh();


            for (int i = 0; i < ConfigOutput.OutputBit.Count; i++)
            {
                if (movedriverZm.MotionFun.OutputGetSta(i))
                {
                    if (dataGridViewOUT.Rows[i].Cells[1].Style.ForeColor != clrSignalON)
                    {
                        dataGridViewOUT.Rows[i].Cells[1].Value = imageList2.Images["buttonON.png"];
                        dataGridViewOUT.Rows[i].Cells[1].Style.ForeColor = clrSignalON;
                        dataGridViewOUT.Rows[i].Cells[2].Value = imageList1.Images["Green.png"];
                    }
                }
                else
                {
                    if (dataGridViewOUT.Rows[i].Cells[1].Style.ForeColor != clrSignalOFF)
                    {
                        dataGridViewOUT.Rows[i].Cells[1].Value = imageList2.Images["buttonOFF.png"];
                        dataGridViewOUT.Rows[i].Cells[1].Style.ForeColor = clrSignalOFF;
                        dataGridViewOUT.Rows[i].Cells[2].Value = imageList1.Images["Gray.png"];
                    }
                }
            }
            dataGridViewOUT.Refresh();
        }
        private void dataGridViewOUT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            int columnindex = e.ColumnIndex;
            if (rowindex < 0 || columnindex < 2) return;
            if (movedriverZm.MotionFun.OutputGetSta(rowindex))
            {
                movedriverZm.MotionFun.OutputOFF(rowindex);
                dataGridViewOUT.Rows[rowindex].Cells[1].Value = imageList2.Images["buttonOFF.png"];
                dataGridViewOUT.Rows[rowindex].Cells[2].Value = imageList1.Images["Gray.png"];
            }
            else
            {
                movedriverZm.MotionFun.OutputON(rowindex);
                dataGridViewOUT.Rows[rowindex].Cells[1].Value = imageList2.Images["buttonON.png"];
                dataGridViewOUT.Rows[rowindex].Cells[1].Style.ForeColor = clrSignalON;
                dataGridViewOUT.Rows[rowindex].Cells[2].Value = imageList1.Images["Green.png"];
            }
        }

        private static void DoubleBufferedDataGirdView(DataGridView dgv, bool flag)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, flag, null);
        }

 

        private void dataGridViewIN_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewIN.ClearSelection();
        }

        int selectRowIndex = 0;
        private void dataGridViewOUT_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (selectRowIndex == e.RowIndex)
            {

            }
            else
            {
                selectRowIndex = e.RowIndex;
                return;
            }

            int rowindex = e.RowIndex;
            int columnindex = e.ColumnIndex;
            if (rowindex < 0 || columnindex != 1) return;


            if (movedriverZm.MotionFun.OutputGetSta(rowindex))
            {
                movedriverZm.MotionFun.OutputOFF(rowindex);
                dataGridViewOUT.Rows[rowindex].Cells[1].Value = imageList2.Images["buttonOFF.png"];
                dataGridViewOUT.Rows[rowindex].Cells[2].Value = imageList1.Images["Gray.png"];
            }
            else
            {
                movedriverZm.MotionFun.OutputON(rowindex);
                dataGridViewOUT.Rows[rowindex].Cells[1].Value = imageList2.Images["buttonON.png"];
                dataGridViewOUT.Rows[rowindex].Cells[1].Style.ForeColor = clrSignalON;
                dataGridViewOUT.Rows[rowindex].Cells[2].Value = imageList1.Images["Green.png"];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ValueChangedRefresh();
        }

    }


    class ConfigInputDef : Config
    {
        //报警配置文件的相对路径
        private  string _configName ;

        public ConfigInputDef(string name)
        {
            _configName = string.Format("{0}", ConfigDirectory + "\\" + name);
            try
            {
                if (!File.Exists(_configName))
                {
                    //StartUpdate.SendStartMsg("输入配置文件加载失败");
                }
                else
                {
                    List<string[]> InputArrayList = Functions.CsvToStringArray(_configName, 0);
                    for (int i = 1; i < InputArrayList.Count; i++)
                    {
                        if (InputArrayList[i][2] != "")
                        {
                            inputNamelist.Add(InputArrayList[i][1] + " -> " + InputArrayList[i][2]);
                            inputBit.Add(i - 1);
                        }
                    }
                }
                //StartUpdate.SendStartMsg("输入配置文件加载成功");
            }
            catch (Exception ex)
            {
                StartUpdate.SendStartMsg("输入配置文件加载失败");
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件[{0}]失败!\n异常描述:{1}\n时间：{2}", name, ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }


        private List<string> inputNamelist = new List<string>();
        private List<int> inputBit = new List<int>();

        /// <summary>
        /// 输入口名称
        /// </summary>
        public List<string> InputNamelist
        {
            get
            {
                return inputNamelist;
            }
        }
        /// <summary>
        /// 输入口对应的bit位
        /// </summary>
        public List<int> InputBit
        {
            get
            {
                return inputBit;
            }
        }

    }

     class ConfigOutputDef : Config
    {
        //报警配置文件的相对路径
        private  string _configName;

        public ConfigOutputDef(string name)
        {
            _configName = string.Format("{0}", ConfigDirectory + "\\" + name);
            try
            {
                if (!File.Exists(_configName))
                {
                    //StartUpdate.SendStartMsg("输出配置文件加载失败");
                }
                else
                {
                    List<string[]> InputArrayList = Functions.CsvToStringArray(_configName, 0);
                    for (int i = 1; i < InputArrayList.Count; i++)
                    {
                        if (InputArrayList[i][2] != "")
                        {
                            outputNamelist.Add(InputArrayList[i][1] + " -> " + InputArrayList[i][2]);
                            outputBit.Add(i - 1);
                        }
                    }
                }
                //StartUpdate.SendStartMsg("输出配置文件加载成功");
            }
            catch (Exception ex)
            {
                StartUpdate.SendStartMsg("输出配置文件加载失败");
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件[{0}]失败!\n异常描述:{1}\n时间：{2}", name, ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }


        private List<string> outputNamelist = new List<string>();
        private List<int> outputBit = new List<int>();

        /// <summary>
        /// 输入口名称
        /// </summary>
        public List<string> OutputNamelist
        {
            get
            {
                return outputNamelist;
            }
        }
        /// <summary>
        /// 输入口对应的bit位
        /// </summary>
        public List<int> OutputBit
        {
            get
            {
                return outputBit;
            }
        }

    }
}
