using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CommonRs;
using ConfigSpace;
using MyControl;
using HZZH.Common.Config;
using System.Threading;
using HZZH.Logic.Commmon;

using HZZH.UI.DerivedControl;



using System.Runtime.InteropServices;
using System.Timers;
using LicenseManagement;
using ApiClass;
using HZZH;
using HzControl.Communal.Control;
using HZZH.Logic.UI;

namespace UI
{
    public partial class FormMain : Form
	{
        
        public FormMain()
		{
            try
            {                
                InitializeComponent();
                StartUpdate.SendStartMsg("应用程序启动 请稍等>>>");
                ConfigSpace.ConfigHandle.Instance.Load();
                InitializeControl();
                //VisionProject.Instance.InitVisionProject();



                StartUpdate.SendStartMsg("正在进入系统>>>");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

				timer1.Interval = 200;
                timer1.Enabled = true;
            }

            HZZH.Logic.LogicMain.TaskMain.Init();
            HzControl.Logic.TaskManager.Show(0);

        }

        #region 用户

        public static User CurrentUser = new User();
        private void btnload()
        {
            toolStripButton1.Enabled = toolStripButton2.Enabled = toolStripButton3.Enabled =
            toolStripButton4.Enabled = 主页Bt.Enabled = toolStripButton8.Enabled = toolStripButton10.Enabled
            = toolStripButton12.Enabled = toolStripButton13.Enabled = toolStripButton9.Enabled = 日志Bt.Enabled
            = toolStripDropDownButton2.Enabled = toolStripButton5.Enabled = toolStripButton6.Enabled =
            toolStripButton11.Enabled = toolStripButton16.Enabled = toolStripButton25.Enabled = false;
            skinTabControl1.Enabled = 修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled
            = 用户管理ToolStripMenuItem.Enabled = false;

        }

        private void btnlog()
        {
            toolStripButton1.Enabled = toolStripButton2.Enabled = toolStripButton3.Enabled =
            toolStripButton4.Enabled = 主页Bt.Enabled = toolStripButton10.Enabled
            = toolStripButton12.Enabled = toolStripButton13.Enabled = toolStripButton9.Enabled = 日志Bt.Enabled
            = toolStripDropDownButton2.Enabled = toolStripButton5.Enabled = toolStripButton6.Enabled =
            toolStripButton11.Enabled = toolStripButton16.Enabled = toolStripButton25.Enabled =
            skinTabControl1.Enabled = 修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled
            = 用户管理ToolStripMenuItem.Enabled = true;
            登录ToolStripMenuItem.Enabled = false;
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin frm = new UserLogin();
            if (DialogResult.OK == frm.ShowDialog())
            {
                UserMgrLogos(frm.GetCurrentUser());
                userInfo.GetUserList(frm.GetCurrentUser());
            }
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserPwd frm_ChangePwd = new ChangeUserPwd();
            frm_ChangePwd.SetUser(CurrentUser);
            if (DialogResult.OK == frm_ChangePwd.ShowDialog(this))
            {
                CurrentUser = frm_ChangePwd.GetCurrentUser();
            }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMgrIntialize();
            skinTabControl1.SelectedTab = 主页Tag;
            btnload();
        }
        private void UserMgrIntialize()
        {
            修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled =
            用户管理ToolStripMenuItem.Enabled = false;

            登录ToolStripMenuItem.Enabled = true;

            CurrentUser = null;
            //tsslbl_loginUserMsg.Text = "";
        }
        private void UserMgrLogos(User user1)
        {
            try
            {
                if (user1.Type != "")
                {
                   
                    CurrentUser = user1;
                    
                    
                    switch (user1.Type)
                    {
                        case "0": 
                            btnlog();
                            toolStripButton8.Enabled = false;
                            
                            break;
                        case "1":  
                            btnlog();
                    
                            toolStripButton8.Enabled = false;
                            break;
                        case "2":
                       
                            btnlog();
                            toolStripButton8.Enabled = true;
                            break;
                        case "3":                     
                            break;
                        default:
                            break;
                    }


                    修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled = true;

                    登录ToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #endregion

        #region 菜单
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton toolbtn = sender as ToolStripButton;            
            if (toolbtn.Tag != null)
            {
                switch (toolbtn.Tag.ToString())
                {
                    case "主页":
                        skinTabControl1.SelectedTab = 主页Tag;
                        break;

                    case "用户管理":
                        skinTabControl1.SelectedTab = 用户管理Tag;
                        userInfo.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                        userInfo.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                        userInfo.Size = this.panel11.Size;
                        userInfo.Parent = this.panel11;//指定子窗体显示的容器
                        userInfo.Dock = DockStyle.Fill;
                        userInfo.Show();
                        userInfo.Activate();
                        break;
                    case "电机":
                        skinTabControl1.SelectedTab = 电机参数Tag;
                        Frm_Machine.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                        Frm_Machine.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                        Frm_Machine.Size = this.panel9.Size;
                        Frm_Machine.Parent = this.panel9;//指定子窗体显示的容器
                        Frm_Machine.Dock = DockStyle.Fill;
                        Frm_Machine.Show();
                        Frm_Machine.Activate();
                        break;
                    case "IO":
                        skinTabControl1.SelectedTab = IO控制Tag;
                        if (IOControl == null || IOControl.IsDisposed || IOControl.Disposing)
                        {
                            IOControl = new InputOutput(DeviceRsDef.MotionCard, "INPUTDEFINE.csv", "OUTPUTDEFINE.csv");
                        }
                            IOControl.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                            IOControl.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                            IOControl.Size = this.panel3.Size;
                            IOControl.Parent = this.panel3;//指定子窗体显示的容器
                            IOControl.Dock = DockStyle.Fill;
                            IOControl.Show();
                            IOControl.Activate();
                        break;
                    case "日志":
                        skinTabControl1.SelectedTab = 日志Tag;
                        frmLog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                        frmLog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                        frmLog.Size = this.panel6.Size;
                        frmLog.Parent = this.panel6;//指定子窗体显示的容器
                        frmLog.Dock = DockStyle.Fill;
                        frmLog.Loadshow();
                        frmLog.Show();
                        frmLog.Activate();
                        break;
                    case "退出":
                        if (MessageBox.Show("是否退出软件", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                        {
                            //ConfigSpace.ConfigHandle.Instance.Save();
                            Application.Exit();
                        }
                        else
                        {
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void btn_PrjFileControl_Click(object sender, EventArgs e)
        {
            ConfigSpace.ConfigHandle.Instance.Save();
            ToolStripButton toolbtn = sender as ToolStripButton;
            if (toolbtn.Tag != null)
            {
                switch (toolbtn.Tag.ToString())
                {
                    case "PrjFileOpen":
                        btn_PrjFileOpen();  
                        break;
                    case "PrjFileNew":
                        btn_PrjFileNew();
                        //VisionProject.Instance.NewTool();
                        break;
                    case "PrjFileSave":
                        toolStrip1.Focus();
                        DeviceRsDef.MotionCard.MotionFun.MotionData.AxisConfigPara.Save();
                        btn_PrjFileSave();
                        //VisionProject.Instance.SaveMachineTool();
                        break;
                    case "PrjFileSaveAs":
                        btn_PrjFileSaveAs();
                        break;
                    default:
                        break;
                }
            }
        }
        
        #endregion 

        #region  窗体事件

        private void Form_SubMain_Load(object sender, EventArgs e)
        {
            try
            {
                //if (ConfigHandle.Instance.SystemDefine.ProjectDirectory != null && ConfigHandle.Instance.SystemDefine.ProjectDirectory != "")
                //{
                //    OpenProject(ConfigHandle.Instance.SystemDefine.ProjectDirectory);
                //    //frm_Stick.DataBingdings();
                //    btnload();

                //}
                //toolStripButton_Click(主页Bt, null);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
#if DEBUG
                ChcekLicense();
#endif
            }
            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {          

        }

        #endregion

        #region 常用事件

        private void DataBingdings()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据绑定有问题 " + ex.ToString());
            }

        }

        private InputOutput IOControl;
        private UserInfo userInfo;
        private FormLog frmLog;
        private Frm_Runing frm_Stick;

        private Frm_MotorParam Frm_Machine;

        public void InitializeControl()
        {
            StartUpdate.SendStartMsg("初始化控件");
            frmLog = new FormLog();
            userInfo = new UserInfo();
            frm_Stick = new Frm_Runing();

            Frm_Machine = new Frm_MotorParam();

            frm_Stick.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            frm_Stick.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            frm_Stick.Size = this.panel1.Size;
            frm_Stick.Parent = this.panel1;//指定子窗体显示的容器
            frm_Stick.Dock = DockStyle.Fill;
            frm_Stick.Show();
            frm_Stick.Activate();

            skinTabControl1.ItemSize = new Size(0, 1);
            skinTabControl1.Appearance = TabAppearance.FlatButtons;
            skinTabControl1.SizeMode = TabSizeMode.Fixed;
            skinTabControl1.SelectedTab = 主页Tag;
            StartUpdate.SendStartMsg("控件初始化完成");
        }

        #endregion

        #region 启动停止

        private void btn_FsmControl_Click(object sender, EventArgs e)
        {
            DeviceRsDef.MotionCard.MotionFun.OutputOFF(24);//照明灯运行时熄灭
            ToolStripButton toolbtn = sender as ToolStripButton;
            if (toolbtn.Tag != null)
            {
                //switch (toolbtn.Tag.ToString())
                //{
                //    case "FsmStart":
                //        if (FsmDef.AutoManualMode != AutoManual.Manual)
                //            TaskRun.Instance.FSM.Run();
                //        //DeviceRs.FSM.Run();
                //        //VisionProject.Instance.Run();
                //        break;
                //    case "FsmPause":
                //        TaskRun.Instance.FSM.Pause();
                //        //RunProcess.DeviceRs.FSM.Pause();
                //        break;
                //    case "FsmStop":
                //        TaskRun.Instance.FSM.Stop();
                //        //RunProcess.DeviceRs.FSM.Stop();
                //        //VisionProject.Instance.Stop();
                //        break;
                //    case "FsmReset":
                //        AlarmClear();
                //        TaskRun.Instance.FSM.Reset();
                //        //RunProcess.DeviceRs.FSM.Reset();
                //        break;
                //    default:
                //        break;
                //}
            }
        }

        #endregion

        #region 工程调度

        /// <summary>
        /// 工单文件存储的路径
        /// </summary>
        string pathRoad = null;

        /// <summary>
        /// 打开文件
        /// </summary>
        public void btn_PrjFileOpen()
        {
            VistaFolderBrowserDialog vistaFolder = new VistaFolderBrowserDialog();
            vistaFolder.SelectedPath = "D:\\程式\\";
            if (vistaFolder.ShowDialog() == DialogResult.OK)
            {
                OpenProject(vistaFolder.SelectedPath);
                //VisionProject.Instance.LoadTool(Path.Combine(Path.GetDirectoryName(vistaFolder.SelectedPath), Path.GetFileNameWithoutExtension(vistaFolder.SelectedPath)) + ".Vision");

                toolStripButton_Click(主页Bt, null);
            }
        }

        private void OpenProject(string path)
        {
            try
            {
                //pathRoad = path;
                //ConfigHandle.Instance.SystemDefine.ProjectDirectory = path;
                //ProjectData.Instance.OpenProject(path);
                //tsslbl_projectPath.Text = pathRoad.Substring(pathRoad.LastIndexOf('\\'));
                //frm_Stick.DataBingdings();

                //string filename = Path.Combine(path, Path.GetFileNameWithoutExtension(path)) + ".Vision";
                //VisionProject.Instance.LoadTool(filename);

                //TaskRun.Instance.InitLogicMain();

                //Rectangle2s.Length1 = ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Length1;
                //Rectangle2s.Length2 = ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Length2;
                //Rectangle2s.Phi = ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Phi;
                //VisionProject.Instance.SetMeasuRectangle(Rectangle2s.Length1, Rectangle2s.Length2, Rectangle2s.Deg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 新建文件
        /// </summary>
        public void btn_PrjFileNew()
        {
            GC.Collect();
            Frm_NewProject frm = new Frm_NewProject();
            DialogResult result = frm.ShowDialog(this);
            if (result == DialogResult.Cancel)
            {
                if (frm.bln_IsOk)
                {
                    string FilePath = "D:\\程式\\" + frm.str_proName;
                    if (IsValidFileName(frm.str_proName) == false || string.IsNullOrEmpty(frm.str_proName))
                    {
                        MessageBox.Show("名称不合法");
                        return;
                    }

                    if (Directory.Exists(FilePath))
                    {
                        //提示消息，如果确认，删除文件夹
                        if (MessageBox.Show(this, "已存在同名项目，您确定要覆盖该项目？", ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                            return;

                        Directory.Delete(FilePath, true);
                        this.pathRoad = FilePath;
                    }
                    else
                    {
                        Directory.CreateDirectory(FilePath);
                        this.pathRoad = FilePath;
                        this.tsslbl_projectPath.Text = "\\" + frm.str_proName;
                    }

                    //ProjectData.Instance.CreatProject();
                    //frm_Stick.DataBingdings();
                    //TaskRun.Instance.InitLogicMain();
                }
            }
        }

        /// <summary>
        /// 检查文件名是否合法.文字名中不能包含字符\/:*?"<>|
        /// </summary>
        /// <param name="fileName">文件名,不包含路径</param>
        /// <returns></returns>
        private bool IsValidFileName(string fileName)
        {
            bool isValid = true;
            string errChar = "\\/:*?\"<>|";  //
            if (string.IsNullOrEmpty(fileName))
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < errChar.Length; i++)
                {
                    if (fileName.Contains(errChar[i].ToString()))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            return isValid;
        }




        /// <summary>
        /// 保存文件
        /// </summary>
        public void btn_PrjFileSave()
        {
            try
            {
                //ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Length1 = Rectangle2s.Length1;
                //ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Length2 = Rectangle2s.Length2;
                //ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Phi = Rectangle2s.Phi;


                //if (pathRoad != null)
                //{
                //    ProjectData.Instance.SaveProject(pathRoad);
                //    VisionProject.Instance.SaveTool(Path.Combine(pathRoad, Path.GetFileNameWithoutExtension(pathRoad)) + ".Vision");
                //    MessageBox.Show("保存成功");
                //    return;
                //}

                VistaFolderBrowserDialog vistaFolder = new VistaFolderBrowserDialog();
                vistaFolder.SelectedPath = "D:\\程式\\";
                if (vistaFolder.ShowDialog() == DialogResult.OK)
                {
                    pathRoad = vistaFolder.SelectedPath;
                    string fileName = Path.GetFileName(pathRoad);
                    ConfigHandle.Instance.SystemDefine.ProjectDirectory = pathRoad;
                    //ProjectData.Instance.SaveProject(pathRoad);
                    tsslbl_projectPath.Text = pathRoad.Substring(pathRoad.LastIndexOf('\\'));
                    //VisionProject.Instance.SaveTool(Path.Combine(pathRoad, Path.GetFileNameWithoutExtension(pathRoad)) + ".Vision");
                }
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.ToString());
            }
        }
        /// <summary>
        /// 文件另存为
        /// </summary>
        public void btn_PrjFileSaveAs()
        {
            VistaFolderBrowserDialog SaveAs = new VistaFolderBrowserDialog();
            SaveAs.SelectedPath = "D:\\程式\\";
            if (SaveAs.ShowDialog() == DialogResult.OK)
            {
                //ProjectData.Instance.SaveProject(SaveAs.SelectedPath);
                //VisionProject.Instance.SaveTool(Path.Combine(SaveAs.SelectedPath, Path.GetFileNameWithoutExtension(SaveAs.SelectedPath)) + ".Vision");
            }
        }

        #endregion

        #region 定时器

        private int cnt = 0;
        private bool[,] b_statusError = new bool[20, 32];
        private bool netSucceedTerm = false;

        bool ShownForm = false;
        int count = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (ShownForm == false && count > 3)
            {
                toolStripButton_Click(主页Bt, null);
                ShownForm = true;
            }

            TimerCheck();
            if (IOControl != null)
            {
                IOControl.ValueChangedRefresh();
            }
            //控制器状态
            if (DeviceRsDef.MotionCard.netSucceed)
            {
                tlssll_ControllerStatus.Text = "板卡：ONLine" + "(" + DeviceRsDef.MotionCard.ScanfTime.ToString() + "ms" + ")";
                tlssll_ControllerStatus.BackColor = SystemColors.Control;
            }
            else
            {
                MachineAlarm.SetAlarm(AlarmLevelEnum.Level3, "控制器掉线");
                for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                {
                    DeviceRsDef.AxisList[i].MC_Stop();
                }
                tlssll_ControllerStatus.Text = "板卡：OFFLine";
                tlssll_ControllerStatus.BackColor = Color.Red;
            }

            //tlssll_CameraUp.Text = VisionProject.Instance.Camera[0].Connected ? "上相机：ONLine" : "上相机：OFFLine";
            //tlssll_CameraUp.BackColor = VisionProject.Instance.Camera[0].Connected ? SystemColors.Control : Color.Red;

            //tlssll_CameraDown.Text = VisionProject.Instance.Camera[1].Connected ? "下相机：ONLine" : "下相机：OFFLine";
            //tlssll_CameraDown.BackColor = VisionProject.Instance.Camera[1].Connected ? SystemColors.Control : Color.Red;

            cnt++;
            if (cnt >= 500)
            {
                cnt = 0;
                ClearMemory();
            }

            //tsslbl_AxisCurrpos1.Text = "X:" + DeviceRsDef.Axis_X.currPos.ToString("0.00");
            //tsslbl_AxisCurrpos2.Text = "Y:" + DeviceRsDef.Axis_Y.currPos.ToString("0.00");
            //tsslbl_AxisCurrpos3.Text = "Z1:" + DeviceRsDef.Axis_Z1.currPos.ToString("0.00");
            //tsslbl_AxisCurrpos4.Text = "Z2:" + DeviceRsDef.Axis_Z2.currPos.ToString("0.00");
            //tsslbl_AxisCurrpos5.Text = "R1:" + DeviceRsDef.Axis_R1.currPos.ToString("0.00");
            //tsslbl_AxisCurrpos6.Text = "R2:" + DeviceRsDef.Axis_R2.currPos.ToString("0.00");
            //tsslbl_AxisCurrpos7.Text = "X:" + DeviceRsDef.Axis_BeltFeed.currPos.ToString("0.00");
        }
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlarmClear();
        }

        //报警清除
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            AlarmClear();
            //TaskRun.Instance.FSM.Stop();
        }
        private void AlarmClear()
        {

            Thread.Sleep(50);
            ConfigHandle.Instance.AlarmDefine.ClearAlarmMessage(b_statusError);
            MachineAlarm.ClearAlarm();
            for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
            {
                DeviceRsDef.AxisList[i].MC_AlarmReset();
            }
            //frm_Stick.Clear();
        }
        #endregion

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            //GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                FormMain.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        #region  键盘事件

        /// <summary>
        /// 获取键盘事件
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Keys vKey);

        System.Timers.Timer m_TimerGetKey;

        private void MainForm_Shown(object sender, EventArgs e)
        {
            m_TimerGetKey = new System.Timers.Timer(100);
            m_TimerGetKey.Elapsed += M_TimerGetKey_Elapsed;
            m_TimerGetKey.Start();
        }
        private void M_TimerGetKey_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (this.IsDisposed || this.Disposing)
                {
                    m_TimerGetKey.Close();
                    return;
                }

                this.Invoke((Action)(() =>
                {
                    if ((GetAsyncKeyState(Keys.Up) != 0) || (GetAsyncKeyState(Keys.Down) != 0)
                    || (GetAsyncKeyState(Keys.Left) != 0) || (GetAsyncKeyState(Keys.Right) != 0))
                    {
                        this.Activate();
                    }

                }));
            }
            catch { }


        }

        //调用API
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow(); //获得本窗体的句柄

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体

        //定义变量,句柄类型
        public IntPtr Handle1;

        protected override bool ProcessDialogKey(Keys keydata)
        {
            //if (TaskRun.Instance.FSM.GetStatus !=  FsmStaDef.STOP) return false;

            if (keydata == Keys.Up || keydata == Keys.Down || keydata == Keys.Left || keydata == Keys.Right)
            {
                if (Handle1 != GetForegroundWindow()) //持续使该窗体置为最前,屏蔽该行则单次置顶
                {
                    SetForegroundWindow(Handle1);

                }
                return false;
            }
            else
                return base.ProcessDialogKey(keydata);

        }

        //bool Key_lock = false;
        //float _spd = 10;
        //protected override bool ProcessCmdKey(ref Message m, Keys keydata)
        //{

        //    if (Key_lock)
        //    {
        //        return false;
        //    }
        //    Key_lock = true;


        //    switch (keydata)
        //    {
        //        //case Keys.Up:
        //        //    DeviceRsDef.Axis_Y.MC_MoveSpd(1);//
        //        //    return true;

        //        //case Keys.Down:
        //        //    DeviceRsDef.Axis_Y.MC_MoveSpd(-1);//
        //        //    return true;

        //        //case Keys.Left:
        //        //    DeviceRsDef.Axis_X.MC_MoveSpd(-1);//
        //        //    return true;

        //        //case Keys.Right:
        //        //    DeviceRsDef.Axis_X.MC_MoveSpd(1);//
        //        //    return true;

        //        case Keys.End:
        //            if(_spd == 30)
        //                _spd = 10;
        //            else
        //                _spd = 30;
        //            return true;

        //        case Keys.W:
        //            Rectangle2s.Length2 += 10;
        //            if (Rectangle2s.Length2 < 1) Rectangle2s.Length2 = 1;
        //            VisionProject.Instance.SetMeasuRectangle(Rectangle2s.Length1, Rectangle2s.Length2, Rectangle2s.Deg);
        //            return true;

        //        case Keys.S:
        //            Rectangle2s.Length2 -= 10;
        //            if (Rectangle2s.Length2 < 1) Rectangle2s.Length2 = 1;
        //            VisionProject.Instance.SetMeasuRectangle(Rectangle2s.Length1, Rectangle2s.Length2, Rectangle2s.Deg);
        //            return true;

        //        case Keys.A:
        //            Rectangle2s.Length1 += 10;
        //            if (Rectangle2s.Length1 < 1) Rectangle2s.Length1 = 1;
        //            VisionProject.Instance.SetMeasuRectangle(Rectangle2s.Length1, Rectangle2s.Length2, Rectangle2s.Deg);
        //            return true;

        //        case Keys.D:
        //            Rectangle2s.Length1 -= 10;
        //            if (Rectangle2s.Length1 < 1) Rectangle2s.Length1 = 1;
        //            VisionProject.Instance.SetMeasuRectangle(Rectangle2s.Length1, Rectangle2s.Length2, Rectangle2s.Deg);
        //            return true;

        //        case Keys.Q:
        //            double phi = Rectangle2s.Deg;
        //            phi += 90;
        //            double p = phi % 90;
        //            phi -= p;
        //            if (phi > 180)
        //                phi = phi - 360;
        //            Rectangle2s.Deg = phi % 360;
        //            VisionProject.Instance.SetMeasuRectangle(Rectangle2s.Length1, Rectangle2s.Length2, Rectangle2s.Deg);
        //            return true;

        //        case Keys.E:
        //            double phi1 = Rectangle2s.Deg;
        //            phi1 -= 1;
        //            if (phi1 <= -180) phi1 = 0;
        //            Rectangle2s.Deg = phi1 % 360;
        //            VisionProject.Instance.SetMeasuRectangle(Rectangle2s.Length1, Rectangle2s.Length2, Rectangle2s.Deg);
        //            return true;

        //        case Keys.R:
        //            double phi2 = Rectangle2s.Deg;
        //            phi2 += 1;
        //            if (phi2 > 180) phi2 = 0;
        //            Rectangle2s.Deg = phi2 % 360;
        //            VisionProject.Instance.SetMeasuRectangle(Rectangle2s.Length1, Rectangle2s.Length2, Rectangle2s.Deg);
        //            return true;
        //        default:
        //            return base.ProcessCmdKey(ref m, keydata);
        //    }


        //}


        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || Key_lock)
            //{
            //    Key_lock = false;
            //    DeviceRsDef.Axis_Y.MC_Stop();
            //    DeviceRsDef.Axis_Y.MC_Stop();
            //    DeviceRsDef.Axis_X.MC_Stop();
            //    DeviceRsDef.Axis_X.MC_Stop();
            //}

            //Thread.Sleep(50);
        }
        #endregion

        #region 加密狗

        SoftReg m_termSoftReg = new SoftReg();
        LicenseMsg m_licenseMsg;

        bool b_IsUseTimeOver = true;
        DateTime _IssuingDate;//发行日期
        public static DateTime timeState;
        private void ChcekLicense()
        {
            string strdogmsg = Api.ReadDog(0, StartUpClass.handle);
            string strdogsmsg = Api.ReadDog(128, StartUpClass.handle);
            if ((strdogmsg == string.Empty) && (strdogsmsg == string.Empty))
            {
                this.txt_MachineID.Text = m_termSoftReg.GetMNum();
                this.txt_press.Text = m_termSoftReg.str_IssuingDate.ToShortDateString();
                this.txt_mature.Text = m_termSoftReg.str_InitPermitDate.ToShortDateString();

                Api.WriteDog(this.txt_MachineID.Text, 0, StartUpClass.handle);

                Thread.Sleep(2);
                strdogmsg = Api.ReadDog(0, StartUpClass.handle);
                DateTime dogDateTime = m_termSoftReg.Register(strdogmsg);
                timeState = new DateTime(dogDateTime.Year, dogDateTime.Month, dogDateTime.Day, 12, 0, 0);

                Thread.Sleep(2);
                int o3 = AESHelper.ConvertDateTimeInt(m_termSoftReg.str_IssuingDate);
                Api.WriteDog(o3.ToString(), 64, StartUpClass.handle);

                LicenseMsg.Save(AESHelper.EncryptStr(SoftReg.MachineID), @"armcc01_intr");

                m_licenseMsg = new LicenseMsg(SoftReg.MachineID, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0), m_termSoftReg.str_IssuingDate, m_termSoftReg.str_InitPermitDate);

                b_IsUseTimeOver = false;
            }
            else
            {
                this.txt_MachineID.Text = strdogmsg;                       //ID
                string strIssuingDate = Api.ReadDog(64, StartUpClass.handle);
                _IssuingDate = AESHelper.GetTime(strIssuingDate);
                this.txt_press.Text = _IssuingDate.ToShortDateString();                  //发行时间

                string term0 = AESHelper.Decrypt(strdogmsg, "qwertyuiop");
                string strend = term0.Substring(9, 10);

                if (strend.CompareTo("JJJ868JJJJ") == 0)
                {
                    txt_mature.Text = "无限期";
                    groupBox5_ma.Enabled = false;
                    b_IsUseTimeOver = false;
                    return;
                }

                DateTime nowDateTime = DateTime.Now;
                DateTime dogDateTime = m_termSoftReg.Register(strdogmsg);
                DateTime machineDateTime = m_termSoftReg.Register(strdogsmsg);

                this.txt_mature.Text = dogDateTime.ToShortDateString();                        //注册时间
                DateTime dogDateTime12 = timeState = new DateTime(dogDateTime.Year, dogDateTime.Month, dogDateTime.Day, 12, 0, 0);

                if (DateTime.Compare(nowDateTime, machineDateTime) <= 0)
                {
                    //系统时间错误,请联系厂家解决
                    lbl_msg.Text = "系统时间错误,请联系厂家解决:" + machineDateTime.ToString() + "/" + nowDateTime.ToString();
                    lbl_msg.BackColor = SystemColors.Control;
                    lbl_msg.ForeColor = Color.Red;
                    skinTabControl1.SelectedIndex = 7;
                }
                else
                {
                    if (DateTime.Compare(nowDateTime, dogDateTime12) >= 0)
                    {
                        //注册到期
                        skinTabControl1.SelectedIndex = 7;
                        lbl_msg.Text = "使用时间到期，请联系厂家";
                        lbl_msg.BackColor = SystemColors.Control;
                        lbl_msg.ForeColor = Color.Blue;
                    }
                    else
                    {
                        b_IsUseTimeOver = false;
                        m_licenseMsg = new LicenseMsg(SoftReg.GetDogNumber(StartUpClass.handle),
                            new DateTime(DateTime.Now.Year,
                            DateTime.Now.Month,
                            DateTime.Now.Day,
                            DateTime.Now.Hour, 0, 0), _IssuingDate, dogDateTime);
                        int days = (dogDateTime12 - nowDateTime).Days;
                        if (days <= 5)
                        {
                            //    pnl_SoftwaretrialInfo.Visible = true;
                            //    lbl_SoftwaretrialInfo.Visible = true;

                            if (days < 0)
                            {
                                MessageBox.Show("软件使用已到期，请注册！！！！！");
                                stateData = true;

                                //注册到期
                                skinTabControl1.SelectedIndex = 7;
                                lbl_msg.Text = "使用时间到期，请联系厂家";
                                lbl_msg.BackColor = SystemColors.Control;
                                lbl_msg.ForeColor = Color.Blue;
                                b_IsUseTimeOver = true;
                            }
                            else
                            {
                                // tabControl1.SelectedIndex = 0;
                                // MessageBox.Show("软件使用日期剩余：" + days + "天");
                                stateData = true;
                            }
                        }
                        else
                        {
                            // tabControl1.SelectedIndex = 0;
                        }
                    }
                }
            }

            if (Api.R1_Close(StartUpClass.handle) != 0)      //关闭Rockey1
            {
                throw new Exception("关闭加密狗......失败");
            }
        }


        bool m_userIsIndefinite = false;


        public static bool stateData = false;

        public void TimerCheck()
        {
            //if (stateData)
            //{
            //if ((timeState - DateTime.Now).Days < 0)
            //{
            //    lbl_SoftwaretrialInfo.Text = "软件使用已到期，请注册！！！！！";
            //    pnl_SoftwaretrialInfo.Visible = true;
            //    lbl_SoftwaretrialInfo.Visible = true;
            //    lbl_msg.Text = "软件使用已到期，请注册！！！！！";
            //    tabControl1.SelectedIndex = 5;
            //    b_IsUseTimeOver = true;
            //}
            //else
            //{
            //    lbl_SoftwaretrialInfo.Text = "软件使用日期剩余：" + (timeState - DateTime.Now).Days + "天";
            //    pnl_SoftwaretrialInfo.Visible = true;
            //    lbl_SoftwaretrialInfo.Visible = true;
            //}

            //lbl_SoftwaretrialInfo.Left -= 5;  //向左移动3个像素
            ////移动到窗体最左端后从最右端进入窗体
            //if (lbl_SoftwaretrialInfo.Right < 0)
            //{
            //    lbl_SoftwaretrialInfo.Left = pnl_SoftwaretrialInfo.Width;
            //}
            //}
            //else
            //{
            //    pnl_SoftwaretrialInfo.Visible = false;
            //    lbl_SoftwaretrialInfo.Visible = false;
            // }


            if (m_licenseMsg != null)
            {
                #region 系统时间错误重启
                if (m_licenseMsg.timeException != null)
                {
                    if (!b_IsUseTimeOver)
                    {
                        lbl_msg.Text = m_licenseMsg.timeException.Message;
                        lbl_msg.BackColor = SystemColors.Control;
                        lbl_msg.ForeColor = Color.Red;
                        skinTabControl1.SelectedIndex = 7;
                        b_IsUseTimeOver = true;
                    }
                }
                #endregion


                #region 系统时间错误不重启
                //if (m_licenseMsg.timeException != null)
                //{
                //    if (!b_IsUseTimeOver)
                //    {
                //        lbl_msg.Text = m_licenseMsg.timeException.Message;
                //        lbl_msg.BackColor = SystemColors.Control;
                //        lbl_msg.ForeColor = Color.Red;
                //       // tabControl1.SelectedIndex = 7;

                //        b_IsUseTimeOver = true;

                //    }
                //}
                //else
                //{
                //    if (b_IsUseTimeOver)
                //    {
                //        lbl_msg.Text = "加密软件";
                //        lbl_msg.BackColor = SystemColors.Control;
                //        lbl_msg.ForeColor = Color.MediumBlue;
                //       // tabControl1.SelectedIndex = 7;

                //        b_IsUseTimeOver = false;

                //    }
                //}
                #endregion

            }
        }



        #endregion


    }
}
