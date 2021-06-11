using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Services
{
    public class CustomerGroupService : BaseService<CustomerGroup> , ICustomerGroupService
    {
        public CustomerGroupService(ICustomerGroupRepository iCustomerGroupRepository ) : base(iCustomerGroupRepository)
        {
           
        }
    }
}
