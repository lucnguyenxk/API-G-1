using MISA.NDL.CukCuk.Core.Common.Attribute;
using MISA.NDL.CukCuk.Core.Common.NdlException;
using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using MISA.NDL.CukCuk.Core.Services;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public ICustomerRepository iCustomerRepository;
        public CustomerService(ICustomerRepository _iBaseRepository) : base(_iBaseRepository)
        {
            iCustomerRepository = _iBaseRepository;
        }


    }
    
}
