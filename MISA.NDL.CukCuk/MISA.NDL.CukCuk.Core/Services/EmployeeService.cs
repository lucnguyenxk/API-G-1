using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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


        #region MethodO
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
            //lựa chọn các thuộc tính cần đưa dữ liệu ra file excel
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
                // tạo tiêu đề và format tiêu đề cho file
                var columNumbers = memberInfors.Count(); 
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells[1, 1].Value = Properties.Resources.NameOfFileExcel;
                workSheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                workSheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                workSheet.Cells[1, 1].Style.Font.Size = 16;
                workSheet.Cells[1, 1].Style.Font.Bold = true;
                workSheet.Cells[1, 1].Style.Border.Bottom.Style = ExcelBorderStyle.None;
                workSheet.Cells[1, 1, 1, columNumbers].Merge = true;
                workSheet.Cells[2, 1, 2, columNumbers].Merge = true;

                // đánh số thứ tự cho các bản ghi
                var sort = 1;
                foreach(var employee in listEmployees)
                {
                    employee.Sort = sort;
                    sort++;
                }

                // load dữ liệu ra file
                workSheet.Cells["A3"].LoadFromCollection(listEmployees, true, OfficeOpenXml.Table.TableStyles.None, BindingFlags.Public, memberInfors.ToArray());
                
                // format các cột trong bảng excel
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                workSheet.Cells[workSheet.Dimension.Address].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[workSheet.Dimension.Address].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[workSheet.Dimension.Address].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[workSheet.Dimension.Address].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[3, 1, 3, columNumbers].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[3, 1, 3, columNumbers].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                workSheet.Cells[3, 1, 3, columNumbers].Style.Font.Bold = true;
                package.Save();
            }
            stream.Position = 0;

            return stream;
        }
        #endregion



    }
}
