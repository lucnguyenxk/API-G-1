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
    /// <summary>
    /// controller khách hàng
    /// created ndluc (21/05/2021)
    /// </summary>
   
    public class CustomerController : BaseController<Customer>
    {
        ICustomerService iCustomerService;
        public CustomerController( ICustomerService _iCustomerService, ICustomerRepository _iCustomerRepository) : base(_iCustomerService,_iCustomerRepository)
        {
            iCustomerService = _iCustomerService;
        }

       

    }
}
