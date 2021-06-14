using MISA.NDL.CukCuk.Core.Common.Attribute;
using MISA.NDL.CukCuk.Core.Common.NdlException;
using MISA.NDL.CukCuk.Core.Enums;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Services
{
    public class BaseService<MISAEntities> : IBaseService<MISAEntities> where MISAEntities :class
    {
        /// <summary>
        /// Khởi tạo đối tượng
        /// </summary>
        #region Properties
        IBaseRepository<MISAEntities> iBaseRepository;
        #endregion

        public BaseService(IBaseRepository<MISAEntities> _iBaseRepository)
        {
            iBaseRepository = _iBaseRepository;
        }

        #region Methods
        public int Insert(MISAEntities entity)
        {
            Validate(entity);
            var res = iBaseRepository.Insert(entity);
            return res;
        }

        public int Update(Guid id, MISAEntities entity)
        {
            var properties = typeof(MISAEntities).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == "EntityState")
                {
                    property.SetValue(entity, EntityState.Update);
                }
            }
            Validate(entity);
            var res = iBaseRepository.Update(id, entity);
            return res;
        }

        public virtual string GetNewCode()
        {
            var result = iBaseRepository.GetNewCode();
            var lenght = result.Length;
            string res = result.Substring(0,3);
            int i = 3;
            while (result[i] == '0' && i < lenght)
            {
                res = res + '0';
                i++;
            }
            int rest = lenght - i;
            string restConvert = result.Substring(lenght - rest, rest);
            int Convert = int.Parse(restConvert);
            Convert += 1;
            res = res + Convert.ToString();
            return res;
        }

        /// <summary>
        /// Validate thông tin đối tượng chung cho base
        /// </summary>
        /// created by ndluc(20/05/2021)
        protected void Validate(MISAEntities entity)
        {
            var properties = typeof(MISAEntities).GetProperties();
            var entityState = properties[properties.Length - 1].GetValue(entity).ToString();
            var entityId = properties[0].GetValue(entity).ToString();
            foreach (var property in properties)
            {
                var nonDuplicate = property.GetCustomAttributes(typeof(NonDuplicate), true);
                var nonEmpty = property.GetCustomAttributes(typeof(NonEmpty), true);
               // Check trùng dữ liệu đối tượng
                if (nonDuplicate.Length > 0)
                {
                    var checkRes = true;

                    var propertyValue = property.GetValue(entity).ToString();
                    if (entityState == EntityState.Update.ToString())
                    {
                        checkRes = iBaseRepository.CheckExists(propertyValue, property.Name, entityId);
                    }
                    else
                    {
                        checkRes = iBaseRepository.CheckExists(propertyValue, property.Name);
                    };
                    if (checkRes)
                    {
                        var ErrMsg = String.Format((nonDuplicate[0] as NonDuplicate).ErrMsg,propertyValue);
                        throw new ValidateException(ErrMsg, entity.GetType().GetProperty(property.Name).Name);
                      
                    }
                }
                //check dữ liệu gửi lên bị bỏ trống.
                if (nonEmpty.Length > 0)
                {
                    if (property.GetValue(entity).ToString() == "")
                    {
                        var errmsg = (nonEmpty[0] as NonEmpty).ErrMsg;
                        throw new ValidateException(errmsg, entity.GetType().GetProperty(property.Name).Name);
                    }
                }
            }
            CustomValidate(entity);
        }

        public IEnumerable<MISAEntities> GetPaging(int PageNumber, int PageSize, string SearchString)
        {
            if(SearchString == null) {
                SearchString = "";
            }
            var entities = iBaseRepository.GetPaging(PageNumber, PageSize, SearchString);
            return entities;
        }


        /// <summary>
        /// validate thông tin của riêng các đối tượng
        /// </summary>
        /// <param name="entity"> đối tượng cần validate</param>
        /// created by ndluc(20/05/2021)
        protected virtual void CustomValidate(MISAEntities entity)
        {
            
        }

       
        #endregion

    }
}
