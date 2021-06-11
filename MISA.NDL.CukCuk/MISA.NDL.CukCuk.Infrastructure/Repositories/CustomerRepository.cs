using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration iConfigruation): base(iConfigruation)
        {

        }
        /// <summary>
        /// Thêm dữ liệu vào cơ sở dữ liệu
        /// </summary>
        /// <param name="list">Danh sách cần thêm</param>
        /// <returns> Số lượng bản ghi được thêm</returns>
        /// created by ndluc(27/05/2021)
        public int Import(Customer customer)
        {
            var res = 0;
            using( _dbConnection = new MySqlConnection(connectionString))
            {

                //var SqlCommand_1 = "Proc_GetCustomerGroupId";
                //var param = new DynamicParameters();
                //param.Add("m_CustomerGroupName", customer.CustomerGroupName);
                //customer.CustomerGroupId = _dbConnection.QueryFirstOrDefault<Guid>(SqlCommand_1, param: param, commandType: CommandType.StoredProcedure);
                var SqlCommand_2 = $"Proc_InsertCustomer";
                res = _dbConnection.Execute(SqlCommand_2, param: customer, commandType: CommandType.StoredProcedure);
                //foreach(var customer in list)
                //{
                //    if (customer.IsInvalid)
                //    {     
                //        var SqlCommand_1 = "Proc_GetCustomerGroupId";
                //        var param = new DynamicParameters();
                //        param.Add("m_CustomerGroupName", customer.CustomerGroupName);
                //        customer.CustomerGroupId =_dbConnection.QueryFirstOrDefault<Guid>(SqlCommand_1, param: param, commandType: CommandType.StoredProcedure);
                //        var SqlCommand_2 = $"Proc_InsertCustomer";
                //        var res = _dbConnection.Execute(SqlCommand_2, param: customer, commandType: CommandType.StoredProcedure);
                //        numberSucced += res;
                //    }
                //}
            }
            return res;
        }

        /// <summary>
        /// kiểm tra nhóm khách hàng tồn tại và lấy về id
        /// </summary>
        /// <param name="value"> giá trị kiểm tra</param>
        /// <param name="propertyName">tên thuộc tính</param>
        /// <returns>giá trị của id</returns>
        /// created by ndluc(30/05/2021)
        public Guid GetValue(string value, string propertyName)
        {
            using(_dbConnection = new MySqlConnection(connectionString))
            {
                var sqlCommand = $"Proc_Check{propertyName}Exists";
                var param = new DynamicParameters();
                param.Add($"m_{propertyName}", value);
                var Id = _dbConnection.QueryFirstOrDefault<Guid>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return Id;
            }
        }
    }
}
