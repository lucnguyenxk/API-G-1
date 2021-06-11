using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NDL.CukCuk.Core.Common.NdlException;
using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Web.Controllers
{
   
    public class CustomerController : BaseController<Customer>
    {
        ICustomerService iCustomerService;
        public CustomerController( ICustomerService _iCustomerService, ICustomerRepository _iCustomerRepository) : base(_iCustomerService,_iCustomerRepository)
        {
            iCustomerService = _iCustomerService;
        }

        /// <summary>
        /// Import fỉle Excel vào trong CSDL
        /// </summary>
        /// <param name="formFile"> tên file</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// danh sách các bản ghi và trạng thái
        /// </returns>
        /// created by ndluc(27/05/2021)
        [HttpPost("ImportFileExcel")]
        public IActionResult Import(IFormFile formFile, CancellationToken cancellationToken)
        {
            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                throw new  ValidateException(Core.Properties.Resources.NotSupportFile);
            }
            using(var stream  = new MemoryStream())
            {
                formFile.CopyToAsync(stream, cancellationToken);
                using(var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var res = iCustomerService.Import(worksheet);
                    return Ok(res);

                }    
            }
        }

    }
}
