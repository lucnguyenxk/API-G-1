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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Services
{
    /// <summary>
    /// Service nhân viên
    /// </summary>
    /// created by ndluc(12/06/2021)
    public class EmployeeService : BaseService<Employee> , IEmployeeService
    {
        #region Property and Constructor
        IEmployeeRepository iEmployeeRepository;
        public EmployeeService(IEmployeeRepository _iEmployeeRepository) : base(_iEmployeeRepository)
        {
            iEmployeeRepository = _iEmployeeRepository;
        }
        #endregion


        #region Method
        /// <summary>
        /// Service xuất khẩu file excel
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns> danh sách các nhân viên trong file</returns>
        /// created by ndluc(12/06/2021)
        public MemoryStream Export(CancellationToken cancellationToken)
        {
            var listEmployees = iEmployeeRepository.GetAll().ToList();
            var properties = typeof(Employee).GetProperties();
            var memberInfors = new List<MemberInfo>();
            foreach (var property in properties)
            {
                var displayNameAtrribute = property.GetCustomAttribute(typeof(DisplayNameAttribute), true);
                if (displayNameAtrribute != null)
                {
                    memberInfors.Add(property);
                }
            }
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(listEmployees, true, OfficeOpenXml.Table.TableStyles.Light1, BindingFlags.Public, memberInfors.ToArray());
                package.Save();
            }
            stream.Position = 0;

            return stream;
        }
        #endregion



    }
}
