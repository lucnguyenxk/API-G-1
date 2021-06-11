using Dapper;
using Microsoft.Extensions.Configuration;
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
    public class BaseRepository<MISAEntities> : IBaseRepository<MISAEntities> where MISAEntities : class
    {
        #region Property
        IConfiguration _iConfigruation;
        protected string connectionString;
        protected IDbConnection _dbConnection;
        #endregion


        public BaseRepository(IConfiguration iConfigruation)
        {
            _iConfigruation = iConfigruation;
            connectionString = _iConfigruation.GetConnectionString("DefaultConnection");
        }
        #region Methods
        public IEnumerable<MISAEntities> GetAll()
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var SqlCommand = $"Proc_Get{name}s";
                var entities = _dbConnection.Query<MISAEntities>(SqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public MISAEntities GetById(Guid id)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {

                var name = typeof(MISAEntities).Name;
                var param = new DynamicParameters();
                param.Add($"{name}Id", id.ToString());
                var SqlCommand = $"Proc_Get{name}ById";
                var entity = _dbConnection.QueryFirstOrDefault<MISAEntities>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public int Insert(MISAEntities entity)
        {

            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var param = new DynamicParameters();
                var SqlCommand = $"Proc_Insert{name}";
                var res = _dbConnection.Execute(SqlCommand, param: entity, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public int Update(Guid id, MISAEntities entity)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var SqlCommand = $"Proc_Update{name}";
                var result = _dbConnection.Execute(SqlCommand, param: entity, commandType: CommandType.StoredProcedure);
                return result;
            }

        }
        public int Delete(Guid id)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var param = new DynamicParameters();
                param.Add($"{name}Id", id.ToString());
                var SqlCommand = $"Proc_Delete{name}";
                var res = _dbConnection.Execute(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        public string GetNewCode()
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var SqlCommand = $"Proc_GetNew{name}Code";
                var result = _dbConnection.QueryFirstOrDefault<string>(SqlCommand, commandType: CommandType.StoredProcedure);

                return result;
            }

        }

        public IEnumerable<MISAEntities> GetPaging(int PageNumber, int PageSize, string SearchString)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var SqlCommand = $"Proc_GetPaging{name}s";
                var param = new DynamicParameters();
                param.Add("@PageNumber", PageNumber);
                param.Add("@PageSize", PageSize);
                param.Add("@SearchString", SearchString);
                var result = _dbConnection.Query<MISAEntities>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Kiểm tra trùng mã
        /// </summary>
        /// <param name="ValueCheck">giá trị cần kiểm tra</param>
        /// <param name="entityId">Id đối tượng cần kiểm tra</param>
        /// <param name="propertyName">thuộc tính cần kiểm tra</param>
        /// <returns>Có bị trùng hay không? Đúng|Sai</returns>
        /// created by ndluc(20/05/2021)

        public bool CheckExists(string ValueCheck, string propertyName, string entityId = null)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var param = new DynamicParameters();
                param.Add($"m_{propertyName}", ValueCheck);
                param.Add($"m_{name}Id", entityId);
                var SqlCommand = $"Proc_Check{name}{propertyName}Exists";
                var res = _dbConnection.QueryFirstOrDefault<bool>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        #endregion

    }
}
