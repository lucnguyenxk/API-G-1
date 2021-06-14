using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Web.Controllers
{
    /// <summary>
    /// Api của nhân viên 
    /// </summary>
    /// created bt ndluc(12/06/2021)
    public class EmployeeController : BaseController<Employee>
    {
        #region Property and Constructor
        public IEmployeeService iEmployeeService;

        public EmployeeController(IEmployeeService _iEmployeeService, IEmployeeRepository _iEmployeeRepository) : base(_iEmployeeService, _iEmployeeRepository)
        {
            iEmployeeService = _iEmployeeService;
        }
        #endregion

        #region Method
        /// <summary>
        /// api xuất khẩu danh sách nhân viên ra file excek
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns> file excel danh sách nhân viên
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// </returns>
        /// created by ndluc(12/06/2021)
        [HttpGet("Export")]
        public IActionResult Export(CancellationToken cancellationToken)
        {
            // thông tin danh sách lấy từ service
            var stream = iEmployeeService.Export(cancellationToken);
            // tên file
            string excelName = "Danh sach nhan vien.xlsx";
            // file trả về
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
        #endregion
    }
}
