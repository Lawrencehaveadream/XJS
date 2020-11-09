using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HzControl.Communal.Controls
{
    [ProvideProperty("BindingName", typeof(Control))]
    public class UserBingData : Component, IExtenderProvider
    {
        //private static Timer
        static UserBingData()
        {

        }

        public UserBingData()
        { 
        
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

            }
            ctrl.DataBindings.Add(propertyName, obj, name, true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
            //ctrl.DataBindings[propertyName].BindingComplete += UserBingData_BindingComplete;
        }

        private static void UserBingData_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SetBindingDataSource(object dataSource)
        {

        }
    }
}
