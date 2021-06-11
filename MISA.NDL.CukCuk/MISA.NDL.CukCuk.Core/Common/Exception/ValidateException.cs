using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Common.NdlException
{
    /// <summary>
    /// Exception dùng để Validate đối tượng
    /// </summary>
    public class ValidateException : Exception
    {
        public ValidateException(string msg , object data = null) : base(msg)
        {
            var objectReturn = new
            {
                Msg = msg,
                FiledNotValid = data
            };
            this.Data.Add("1", objectReturn);

        }
    }
}
