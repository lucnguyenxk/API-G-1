using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Interfaces.IServices
{
    public interface ICustomerService : IBaseService<Customer>
    {
        public ImportObject<Customer> Import(ExcelWorksheet worksheet);
    }
}
