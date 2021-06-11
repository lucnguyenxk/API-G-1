using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin nhóm khách hàng
    /// </summary>
    /// created by ndluc(19/02/2021)
    public class CustomerGroup
    {
        #region Property
        /// <summary>
        /// id nhóm khách hàng
        /// </summary>
        /// created by ndluc(19/02/2021)
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        ///Tên nhóm khách hàng
        /// </summary>
        /// created by ndluc(19/02/2021)
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        /// created by ndluc(19/02/2021)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// người tạo
        /// </summary>
        /// created by ndluc(19/02/2021)
        public string CreatedBy { get; set; }

        /// <summary>
        /// người sửa
        /// </summary>
        /// created by ndluc(19/02/2021)
        public string ModifiedBy { get; set; }

        /// <summary>
        /// ngày sửa
        /// </summary>
        /// created by ndluc(19/02/2021)
        public DateTime? ModifiedDate { get; set; }

        #endregion

    }
}
