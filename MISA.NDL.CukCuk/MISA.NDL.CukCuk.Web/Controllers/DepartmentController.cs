using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Web.Controllers
{
    
    public class DepartmentController : BaseController<Department>
    {
        public DepartmentController(IDepartmentService iDepartmentService, IDepartmentRepository iDepartmentRepository) : base(iDepartmentService,iDepartmentRepository)
        {

        }
    }
}
