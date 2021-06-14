using Microsoft.Extensions.Configuration;
using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration iConfigruation) : base(iConfigruation)
        {

        }
    }
}
