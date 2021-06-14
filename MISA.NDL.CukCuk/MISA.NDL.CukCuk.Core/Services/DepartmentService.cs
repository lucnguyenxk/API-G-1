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
    public class DepartmentService :BaseService<Department> , IDepartmentService
    {
        public DepartmentService(IDepartmentRepository iDepartmentRepository) : base(iDepartmentRepository)
        {

        }
    }
}
