using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Web.Controllers
{
    
    public class EmployeeController : BaseController<Employee>
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public EmployeeController(IEmployeeService iEmployeeService , IEmployeeRepository iEmployeeRepository, IHostingEnvironment hostingEnvironment) : base(iEmployeeService, iEmployeeRepository)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("Export")]
        [Obsolete]
        public IActionResult Export(CancellationToken cancellationToken) 
        {
            string folder = _hostingEnvironment.WebRootPath;
            string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
            string downloadUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, excelName);
            FileInfo file = new FileInfo(Path.Combine(folder, excelName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(folder, excelName));
            }

            // query data from database  
            //await Task.Yield();

            var list = new List<Employee>()
            {
                new Employee { EmployeeCode = "NV-001", FullName = "NDL" },
                new Employee { EmployeeCode = "NV-002", FullName = "PAP"  },
            };

            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }
            return Ok(downloadUrl);
        }
    }
}
