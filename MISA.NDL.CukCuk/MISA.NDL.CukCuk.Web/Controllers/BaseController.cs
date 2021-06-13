using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NDL.CukCuk.Core.Common.NdlException;
using MISA.NDL.CukCuk.Core.Enums;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Web.Controllers
{
    /// <summary>
    /// Api base
    /// </summary>
    /// created by ndluc(20/05/2021)
    /// <typeparam name="MISAEntities"></typeparam>
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<MISAEntities> : ControllerBase where MISAEntities : class
    {
        /// <summary>
        /// Khởi tạo các đối tượng cần sử dụng
        /// </summary>
        /// created by ndluc(20/05/2021)
        #region Property and Constructor
        IBaseService<MISAEntities> iBaseService;
        IBaseRepository<MISAEntities> iBaseRepository;
        public BaseController(IBaseService<MISAEntities> _iBaseService, IBaseRepository<MISAEntities> _iBaseRepository)
        {
            iBaseRepository = _iBaseRepository;
            iBaseService = _iBaseService;
        }
        #endregion


        #region Methods
        /// <summary>
        /// lấy toàn bộ dữ liệu
        /// </summary>
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// <returns>Danh sách tất cả đối tượng</returns>
        /// created by ndluc(20/05/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = iBaseRepository.GetAll();
            if (res.Count() > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }

        }

        /// <summary>
        /// Lấy đội tượng theo id
        /// </summary>
        /// <param name="id">id đối tượng cần lấy</param>
        /// <returns> đối tượng cần lấy</returns>
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// created by ndluc(20/05/2021)
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var res = iBaseRepository.GetById(id);
            if (res != null)
                return Ok(res);
            else
                return NoContent();
        }

        /// <summary>
        /// api thêm đối tượng
        /// </summary>/// 
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// <param name="entity"> đối tượng cần thêm</param>
        /// <returns> số lượng đối tượng cần thêm</returns>
        /// created by ndluc(20/05/2021)
        [HttpPost]
        public IActionResult Insert([FromBody] MISAEntities entity)
        {
            var res = iBaseService.Insert(entity);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }

        }



        /// <summary>
        /// api cập nhật đối tượng theo id
        /// </summary>
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// <param name="id"> id đối tượng cần cập nhật</param>
        /// <param name="entity"> thông tin đối tượng cần cập nhật</param>
        /// <returns> số lượng đối tượng được cập nhật</returns>
        /// created by ndluc(20/05/2021)
        [HttpPut("{id}")]
        public IActionResult Uppdate(Guid id, MISAEntities entity)
        {
            var res = iBaseService.Update(id, entity);
            if (res > 0)
            {
                return Ok(res);
            }
            else return NoContent();
        }

        /// <summary>
        /// api xóa đối tượng
        /// </summary>
        /// <param name="id"> id đối tượng cần xóa</param>
        /// <returns> số lượng đối tượng bị xóa</returns>
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// created by ndluc(20/05/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var res = iBaseRepository.Delete(id);
            if (res > 0)
            {
                return Ok(res);
            }
            else return NoContent();
        }

        /// <summary>
        /// api lấy mã mới cho đối tượng
        /// </summary>
        /// <returns> Mã mới cho đối tượng tương ứng</returns>
        /// /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// created by ndluc(11/06/2021)
        [HttpGet("GetNewCode")]
        public IActionResult GetNewCode()
        {
            var res = iBaseService.GetNewCode();
            return Ok(res);
        }
        /// <summary>
        /// Lấy dữ liệu theo phân trang
        /// </summary>
        /// <param name="PageNumber">vị trí trang</param>
        /// <param name="PageSize">kích cỡ trang</param>
        /// <param name="SearchString">khóa tìm kiếm</param>
        /// <returns>Dữ liệu trả về có phân trang
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// </returns>
        /// created by ndluc(12/06/2021)
        [HttpGet("GetPaging")]
        public IActionResult GetPaging(int PageNumber, int PageSize, string SearchString)
        {
            var res = iBaseService.GetPaging(PageNumber, PageSize, SearchString);
            if(res.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(res);
            }    
        }

        
        #endregion

    }
}
