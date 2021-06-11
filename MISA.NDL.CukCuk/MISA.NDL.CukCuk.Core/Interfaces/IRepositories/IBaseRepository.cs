using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Interfaces.IRepositories
{

    /// <summary>
    /// BaseRepository
    /// </summary>
    /// <typeparam name="MISAEntities"></typeparam>
    /// created by ndLuc(19/05/2021)
    public interface IBaseRepository<MISAEntities> where MISAEntities : class
    {
        /// <summary>
        /// lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>
        /// danh sách các đối tượng lấy được
        /// </returns>
        /// created by ndLuc(19/05/2021)
        public IEnumerable<MISAEntities> GetAll();

        /// <summary>
        /// lấy đối tượng theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>đối tượng tìm kiếm đc theo id</returns>
        /// created by : ndLuc(19/05/2021)
        public MISAEntities GetById(Guid entityId);

        /// <summary>
        /// thêm  đối tượng
        /// </summary>
        /// <param name="entity"> đối tượng cần thêm</param>
        /// <returns> số lượng dối tượng được thêm</returns>
        /// created by : ndLuc(19/05/2021)
        public int Insert(MISAEntities entity);

        /// <summary>
        /// cập nhật đối tượng
        /// </summary>
        /// <param name="id"> id đối tượng cần cập nhật</param>
        /// <param name="entity"> thông tin cần cập nhật</param>
        /// <returns>số đối tượng được cập nhật</returns>
        /// created by : ndLuc(19/05/2021)
        public int Update(Guid id,MISAEntities entity);

        /// <summary>
        /// xóa bỏ đối tượng theo id
        /// </summary>
        /// <param name="entityId"> id đối tượng cần xóa bỏ</param>
        /// <returns> số lượng đối tượng bị xóa</returns>
        /// created by : ndLuc(19/05/2021)
        public int Delete(Guid entityId);

        /// <summary>
        /// Kiểm tra việc bị trùng mã đối tượng
        /// </summary>
        /// <param name="Code">Mã cần kiểm tra</param>
        /// <returns> kết quả trùng mã đúng hoặc sai</returns>
        /// created by : ndLuc(19/05/2021)
        public bool CheckExists(string ValueCheck ,string propertyName,string entityId = null);

        /// <summary>
        /// Lấy dữ liệu có phân trang
        /// </summary>
        /// <param name="PageNumber"> vị trí trang</param>
        /// <param name="PageSize"> số bản ghi một trang</param>
        /// <param name="SearchString"> từ khóa tìm kiếm</param>
        /// <returns> dữ liệu nhận về</returns>
        /// created by : ndLuc(11/06/2021)
        public IEnumerable<MISAEntities> GetPaging(int PageNumber, int PageSize, string SearchString);

        /// <summary>
        /// Lấy mã mới cho đối tượng
        /// </summary>
        /// <returns>
        /// mã mới ứng với đối tượng tương úng
        /// </returns>
        /// created by : ndLuc(11/06/2021)
        public string GetNewCode();


    }
}
