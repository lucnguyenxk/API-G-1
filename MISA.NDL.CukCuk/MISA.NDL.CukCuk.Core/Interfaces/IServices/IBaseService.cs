using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Interfaces.IServices
{
    public interface IBaseService<NdlEntities> where NdlEntities:class
    {
        /// <summary>
        /// thêm đối tượng 
        /// </summary>
        /// <param name="entity"> đối tượng cần thêm</param>
        /// <returns> số lượng đối tượng được thêm</returns>
        /// created by : ndLuc(19/02/2021)
        public int Insert(NdlEntities entity);

        /// <summary>
        /// Sửa đối tượng
        /// </summary>
        /// <param name="id"> id đối tượng cần sửa</param>
        /// <param name="entity"> thông tin đối tượng cấn sửa</param>
        /// <returns>số lượng đối tượng được sửa</returns>
        /// created by : ndLuc(19/02/2021)
        public int Update(Guid id, NdlEntities entity);

        /// <summary>
        /// Lấy mã mới cho đối tượng
        /// </summary>
        /// <returns>
        /// Mã mới ứng với đối tượng tương ứng</returns>
        public string GetNewCode();
    }
}
