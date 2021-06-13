using MISA.NDL.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Interfaces.IServices
{
    public interface IEmployeeService : IBaseService<Employee> 
    {
        /// <summary>
        /// lấy thông tin danh sách nhân viên cần xuất ra file excel
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// danh sách thông tin nhân viên
        /// </returns>
        /// created by ndluc(12/06/2021)
        public MemoryStream Export(CancellationToken cancellationToken);
    }
}
