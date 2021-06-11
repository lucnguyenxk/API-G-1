using MISA.NDL.CukCuk.Core.Common.Attribute;
using MISA.NDL.CukCuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin khách hàng 
    /// </summary>
    /// created by : ndLuc(19/05/2021)
    public class Customer
    {
        #region Property
        /// <summary>
        /// Id khách hàng
        /// </summary>
        ///  created by : ndluc(19/05/2021)
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        /// created by : ndLuc(19/05/2021)
        [NonDuplicate("CustomerPhoneNumberNonDuplicate")]
        [NonEmpty("CustomerCodeNonEmpty")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        /// created by : ndLuc(19/05/2021)
        public string FullName { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public string MemberCode { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        /// created by : ndluc(19/05/2021)
        [NonDuplicate("CustomerCodeNonDuplicate")]
        [NonEmpty("PhoneNumberNonEmpty")]
        public string  PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Tên công ty
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public string CompanyName { get; set; }

        /// <summary>
        /// Id nhóm khách hàng
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public Gender? Gender { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public string  Address { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// người tạo thông tin
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public string CreatedBy { get; set; }

        /// <summary>
        /// người sửa thông tin
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public string ModifiedBy { get; set; }

        /// <summary>
        /// ghi chú
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public string Note { get; set; }

        /// <summary>
        /// Mã công ty
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        /// created by : ndluc(19/05/2021)
        [CheckExists("CustomerGroupNameNotExists")]
        public string CustomerGroupName  { get; set; }

        /// <summary>
        /// Đối tượng khách hàng có hợp lệ hay không
        /// </summary>
        /// created by : ndluc(27/05/2021)
        public bool IsInvalid { get; set; } = true;

        /// <summary>
        /// trạng thái của đối tượng
        /// </summary>
        /// created by : ndluc(27/05/2021)
        public List<string> Notification { get; set; }

        /// <summary>
        /// Trạng thái của object
        /// </summary>
        /// created by : ndluc(19/05/2021)
        public EntityState EntityState { get; set; } = EntityState.Add;
        #endregion


        #region Constructor
        /// <summary>
        /// Hàm khởi tạo đối tượng
        /// </summary>
        /// created by ndluc(27/05/2021)
        public Customer()
        {
            this.Notification = new List<string>();
        }
        #endregion

    }
}
