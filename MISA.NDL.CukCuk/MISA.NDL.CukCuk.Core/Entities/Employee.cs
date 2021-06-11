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
    /// Thông tin nhân viên
    /// </summary>
    /// created by ndluc(25/02/2021)
    public class Employee
    {
        #region Properties

        /// <summary>
        /// Id của nhân viên
        /// </summary>
        /// created by ndluc(25/02/2021)
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// created by ndluc(25/02/2021)
        [NonDuplicate("Mã nhân viên đã tồn tại trong hệ thống, vui lòng kiểm tra lại!")]
        [NonEmpty("Mã nhân viên không được bỏ trống!")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string FullName { get; set; }

        /// <summary>
        /// Id Phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        /// created by ndluc(25/02/2021)
        [NonDuplicate("Số điện thoại đã tồn tại trong hệ thống, vui lòng kiểm tra lại!")]
        [NonEmpty("Số điện thoại không được để trống!")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// created by ndluc(25/02/2021)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        /// created by ndluc(25/02/2021)
        public Gender?  Gender { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string Address { get; set; }

        /// <summary>
        /// Chức vụ
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string Position { get; set; }

        /// <summary>
        /// Số CMND
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string IdentityCardNumber { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string BankAccountNumber  { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string BankName { get; set; }

        /// <summary>
        /// Ngày Tạo
        /// </summary>
        /// created by ndluc(25/02/2021)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string CreatedBy { get; set; }

        /// <summary>
        /// Tổng số các đối tượng khi lấy phân trang
        /// </summary>
        /// created by ndluc(25/02/2021)
        public int TotalRecord { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        /// created by ndluc(25/02/2021)
        public string Note { get; set; }

        /// <summary>
        /// trạng thái đối tượng
        /// </summary>
        /// created by ndluc(25/02/2021)
        public EntityState EntityState { get; set; } = EntityState.Add;

        #endregion

    }
}
