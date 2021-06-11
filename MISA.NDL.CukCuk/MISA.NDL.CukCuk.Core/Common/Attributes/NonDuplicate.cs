using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Common.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    ///
    /// Kiểm tra việc trùng dữ liệu
    /// created by ndluc (24/05/2021)
    public class NonDuplicate : System.Attribute
    {
        public string ErrMsg;
        public NonDuplicate(string resourcesKey)
        {
            ErrMsg = Properties.Resources.ResourceManager.GetString(resourcesKey);
        }
    }

    /// <summary>
    /// Kiểm tra dữ liệu trống
    /// created by ndluc (24/05/2021)
    /// </summary>
    public class NonEmpty : System.Attribute
    {
        public string ErrMsg;
        public NonEmpty( string resourcesKey)
        {
            ErrMsg = Properties.Resources.ResourceManager.GetString(resourcesKey);

        }
    }
    /// <summary>
    /// Kiểm tra độ dài dữ liệu cho phép
    /// /// created by ndluc (24/05/2021)
    /// </summary>
    public class LenghtRequired : System.Attribute
    {
        public string ErrMsg;
        public int LenghtPro;
        public LenghtRequired(string errMsg , int lenghtPro)
        {
            ErrMsg = errMsg;
            LenghtPro = lenghtPro;
        }
    }
    /// <summary>
    /// Kiểm tra dữ liệu có tồn tại trong hệ thống không
    /// created by ndluc (28/05/2021)
    /// </summary>
    public class CheckExists : System.Attribute
    {
        public string ErrMsg;
        public CheckExists(string resourcesKey)
        {
            ErrMsg = Properties.Resources.ResourceManager.GetString(resourcesKey);


        }
    }
    
}
