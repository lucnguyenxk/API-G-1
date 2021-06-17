using MISA.NDL.CukCuk.Core.Common.Attribute;
using MISA.NDL.CukCuk.Core.Enums;
using MISA.NDL.CukCuk.Core.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// số thứ tự khi lấy dữ liêu ra
        /// </summary>
        /// created by ndluc(17/06/2021)
        [DisplayName("STT")]
        public int Sort { get; set; }


        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// created by ndluc(25/02/2021)
        [NonDuplicate("NotiDuplicateEmployeeCode")]
        [NonEmpty("NonEmptyEmployeeCode")]
        [DisplayName("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// created by ndluc(25/02/2021)
        [DisplayName("Tên nhân viên")]
        [NonEmpty("NonEmptyFullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Id Phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// created by ndluc(14/06/2021)
        public string DepartmentName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        /// created by ndluc(25/02/2021)
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// created by ndluc(25/02/2021)
        [DisplayName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        /// created by ndluc(25/02/2021)
        public Gender?  Gender { get; set; }

        /// <summary>
        /// Tên giới tính
        /// </summary>
        /// created by ndluc(25/02/2021)
        [DisplayName("Giới tính")]
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case Enums.Gender.Male:
                        return Resources.Male;
                    case Enums.Gender.FeMale:
                        return Resources.FeMale;
                    case Enums.Gender.Other:
                        return Resources.Other;
                    default:
                        return "";
                }
               
            }
        }

        /// <summary>
        /// Email
        /// </summary>
        /// created by ndluc(25/02/2021)
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// created by ndluc(25/02/2021)
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        /// <summary>
        /// Chức vụ
        /// </summary>
        /// created by ndluc(25/02/2021)
        [DisplayName("Vị trí")]
        public string Position { get; set; }

        /// <summary>
        /// Số CMND
        /// </summary>
        /// created by ndluc(25/02/2021)
        [DisplayName("Số CMND")]
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
