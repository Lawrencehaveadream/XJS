using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HzControl.Communal.Tools;
using System.Reflection;
using System.ComponentModel;

namespace HZZH.Database
{
    public partial class Product
    {
        public readonly string Path = AppDomain.CurrentDomain.BaseDirectory + "db\\";
        private static AppConfig AppConfig;

        public static Product Inst { get; }

        static Product()
        {
            Inst = new Product();
            if (Directory.Exists(Inst.Path) == false)
            {
                Directory.CreateDirectory(Inst.Path);
            }

            AppConfig = new AppConfig();
            AppConfig.Load(Inst.Path + "app.config");
            if (string.IsNullOrWhiteSpace(AppConfig.CurrentProductName)==false)
            {
                Inst.Load(AppConfig.CurrentProductName);
            }
        }

        public ProductInfo Info { get; set; }

        public event EventHandler SaveEvent;
        public event EventHandler LoadEvent;

        public void Save(string productName)
        {
            this.Info.Name = productName;
            this.Info.Modify = DateTime.Now;
            string filePath = Path + productName + "\\";
            foreach (var item in this.GetType().GetProperties())
            {
                if (typeof(ProductBase).IsAssignableFrom(item.PropertyType))
                {
                    ProductBase pro = item.GetValue(this) as ProductBase;
                    pro.Save(filePath + item.Name);
                }
            }

            AppConfig.CurrentProductName = productName;
            AppConfig.Save(Inst.Path + "app.config");

            if (SaveEvent != null)
            {
                SaveEvent(this, EventArgs.Empty);
            }
        }

        public void Save()
        {
            this.Save(this.Info.Name);
        }

        public void Load(string productName)
        {
            string filePath = Path + productName + "\\";
            foreach (var item in this.GetType().GetProperties())
            {
                if (typeof(ProductBase).IsAssignableFrom(item.PropertyType))
                {
                    ProductBase pro = item.GetValue(this) as ProductBase;
                    if (pro == null)
                    {
                        object[] customAttributes = item.GetCustomAttributes(typeof(DefaultValueAttribute), false);
                        if (customAttributes.Length > 0)
                        {
                            DefaultValueAttribute attribute = (DefaultValueAttribute)customAttributes[0];
                            item.SetValue(this, attribute.Value);
                        }
                        else
                        {
                            object obj = item.PropertyType.Assembly.CreateInstance(item.PropertyType.FullName);
                            item.SetValue(this, obj);
                        }
                        pro = item.GetValue(this) as ProductBase;
                    }

                    pro.Load(filePath + item.Name);
                }
            }
            AppConfig.CurrentProductName = productName;
            AppConfig.Save(Inst.Path + "app.config");

            if (LoadEvent != null)
            {
                LoadEvent(this, EventArgs.Empty);
            }
        }

        public static ProductInfo ReadFile(string productName)
        {
            string filePath = Product.Inst.Path + productName + "\\Info";
            ProductInfo productInfo = new ProductInfo();
            productInfo.Load(filePath);
            return productInfo;
        }

    }

    /// <summary>
    /// 产品信息
    /// </summary>
    [Serializable]
    public class ProductInfo: ProductBase
    {
        /// <summary>
        /// 产品名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime Modify { get; set; }

        public ProductInfo()
        {
            Name = "新建工单";
        }
    }

    [Serializable]
    public class AppConfig: ProductBase
    {
        public string CurrentProductName { get; set; }
    }


 
    [Serializable]
    public class ProductBase
    {
        public virtual void Load(string fileName)
        {
            object obj = Serialization.LoadFromXml(this.GetType(), fileName);
            CopyValue(this, obj);
        }

        protected static void CopyValue(object obj, object value)
        {
            if (value != null)
            {
                foreach (FieldInfo info in obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                {
                    if (info.FieldType.IsValueType || info.FieldType== typeof(string))
                    {
                        info.SetValue(obj, info.GetValue(value));
                    }
                    else
                    {
                        CopyValue(info.GetValue(obj), info.GetValue(value));
                    }
                }
            }
        }

        public virtual void Save(string fileName)
        {
            Serialization.SaveToXml(this, fileName);
        }
    }


}
