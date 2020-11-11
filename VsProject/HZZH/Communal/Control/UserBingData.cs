using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HzControl.Communal.Controls
{
    [ProvideProperty("BindingName", typeof(Control))]
    public class UserBingData : Component, IExtenderProvider
    {
        private static readonly Timer readValueTimer = new Timer();

        static UserBingData()
        {
            readValueTimer.Interval = 200;
            readValueTimer.Start();
        }

        public UserBingData()
        {
            readValueTimer.Tick += ReadValueTimer_Tick;
            this.Disposed += UserBingData_Disposed;
        }

        public UserBingData(IContainer container) : this()
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Add(this);
        }

        public bool CanExtend(object extendee)
        {
            return extendee is NumericUpDown || extendee is MyTextBox;
        }

        private Hashtable hashtable = new Hashtable();

        public string GetBindingName(Control numeric)
        {
            if (hashtable.Contains(numeric))
                return (string)hashtable[numeric];
            else
                return string.Empty;
        }

        public void SetBindingName(Control numeric, string name)
        {
            if (numeric == null) return;
            hashtable[numeric] = name;
        }


        public static object GetBindingDataSource(object source, string propertyName)
        {
            Debug.Assert(source != null);
            Debug.Assert(propertyName != null);

            string[] name = SplitBindingName(propertyName);
            object propertyValue = source.GetType().GetProperty(name[0]).GetValue(source);
            if (name.Length > 1)
            {
                string propertyName2 = CombineBindingName(name.Skip(1).ToArray());
                return GetBindingDataSource(propertyValue, propertyName2);
            }
            else
            {
                return propertyValue;
            }
        }

        public static string[] SplitBindingName(string propertyName)
        {
            char[] split = new char[] { '.' };
            string[] str = propertyName.Split(split);
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].Trim();
            }
            return str;
        }

        public static string CombineBindingName(string[] propertyName)
        {
            bool flag = false;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in propertyName)
            {
                if (flag == true)
                {
                    stringBuilder.Append('.');
                }
                stringBuilder.Append(item);
                flag = true;
            }
            return stringBuilder.ToString();
        }

        public static T[] GetControls<T>(Control control) where T : Control
        {
            List<T> list = new List<T>();
            Queue<Control> controls = new Queue<Control>();
            controls.Enqueue(control);
            while (controls.Count > 0)
            {
                Control ctrl = controls.Dequeue();
                for (int i = 0; i < ctrl.Controls.Count; i++)
                {
                    controls.Enqueue(ctrl.Controls[i]);
                }

                if (ctrl is T)
                {
                    list.Add((T)ctrl);
                }
            }
            return list.ToArray();
        }

        public static void SetBinding(Control ctrl, string propertyName, object obj, string name)
        {
            if (ctrl.DataBindings[propertyName] != null)
            {
                ctrl.DataBindings.Remove(ctrl.DataBindings[propertyName]);
                ctrl.DataBindings[propertyName].BindingComplete -= UserBingData_BindingComplete;
            }
            ctrl.DataBindings.Add(propertyName, obj, name, true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
            ctrl.DataBindings[propertyName].BindingComplete += UserBingData_BindingComplete;
            if (ctrl is MyTextBox && ((MyTextBox)ctrl).InputType == MyTextBox.eInputType.Float)
            {
                ctrl.DataBindings[propertyName].FormattingEnabled = true;
                ctrl.DataBindings[propertyName].FormatString = "F2";// ((MyTextBox)ctrl).Format;
            }
        }

        private static void UserBingData_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Success && e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            {
                //var va = e.Binding.DataSource;
                //va.GetType().GetFields()[0].tye
            }
        }

        /// <summary>
        /// 按照设置的属性路径绑定对象中的各属性
        /// </summary>
        /// <param name="dataSource"></param>
        public void SetBindingDataSource(object dataSource)
        {
            foreach (Control item in hashtable.Keys)
            {
                string bindingString = GetBindingName(item);
                if (string.IsNullOrWhiteSpace(bindingString))
                {
                    continue;
                }

                string[] strs = SplitBindingName(bindingString);
                if (strs.Length == 1)
                {
                    SetBinding(item, "Text", dataSource, strs[0]);
                }
                else
                {
                    string sourceName = CombineBindingName(strs.Take(strs.Length - 1).ToArray());
                    object source = GetBindingDataSource(dataSource, sourceName);
                    SetBinding(item, "Text", source, strs.Last());
                }
            }
        }

        /// <summary>
        /// 从数据源中读取值
        /// </summary>
        public void ReadValue()
        {
            foreach (Control item in hashtable.Keys)
            {
                if (item.DataBindings.Count > 0)
                {
                    item.DataBindings[0].ReadValue();
                }
            }
        }


        private void UserBingData_Disposed(object sender, EventArgs e)
        {
            readValueTimer.Tick -= ReadValueTimer_Tick;
        }

        private void ReadValueTimer_Tick(object sender, EventArgs e)
        {
            foreach (Control item in hashtable.Keys)
            {
                if (item.FindForm().Visible == true&& item.DataBindings.Count > 0)
                {
                    if (item.Focused==false)
                    {
                        item.DataBindings[0].ReadValue();
                    }
                }
            }
        }


    }
}
