using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Entities
{
    /// <summary>
    /// Đối tượng phòng ban
    /// </summary>
    /// created by ndluc(11/06/2021)
    public class Departmernt 
    {
        #region Property
        /// <summary>
        /// id phòng ban
        /// </summary>
        /// created by ndluc(11/06/2021)
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        /// created by ndluc(11/06/2021)
        public string DepartmentName { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        /// created by ndluc(11/06/2021)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        ///người tạo
        /// </summary>
        /// created by ndluc(11/06/2021)
        public string CreatedBy { get; set; }
        #endregion

    }


}
