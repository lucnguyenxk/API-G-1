using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Interfaces.IServices
{
    public interface IBaseService<MISAEntities> where MISAEntities:class
    {
        /// <summary>
        /// thêm đối tượng 
        /// </summary>
        /// <param name="entity"> đối tượng cần thêm</param>
        /// <returns> số lượng đối tượng được thêm</returns>
        /// created by : ndLuc(19/05/2021)
        public int Insert(MISAEntities entity);

        /// <summary>
        /// Sửa đối tượng
        /// </summary>
        /// <param name="id"> id đối tượng cần sửa</param>
        /// <param name="entity"> thông tin đối tượng cấn sửa</param>
        /// <returns>số lượng đối tượng được sửa</returns>
        /// created by : ndLuc(19/05/2021)
        public int Update(Guid id, MISAEntities entity);

        /// <summary>
        /// Lấy mã mới cho đối tượng
        /// </summary>
        /// <returns>
        /// Mã mới ứng với đối tượng tương ứng</returns>
        /// created by : ndLuc(12/06/2021)
        public string GetNewCode();

        /// <summary>
        /// lấy dữ liệu theo phân trang
        /// </summary>
        /// <param name="PageNumber"> vị trí trang</param>
        /// <param name="PageSize">kích cỡ trang</param>
        /// <param name="SearchString"> từ khóa tìm kiếm</param>
        /// <returns>
        /// dữ liệu phân trang 
        /// </returns>
        /// created by ndluc(12/06/2021)
        public IEnumerable<MISAEntities> GetPaging(int PageNumber, int PageSize, string SearchString);
    }
}
