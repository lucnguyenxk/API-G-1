using MISA.NDL.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Interfaces.IRepositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public Guid GetValue(string value, string propertyName);
        public int Import(Customer customer);

    }
}
