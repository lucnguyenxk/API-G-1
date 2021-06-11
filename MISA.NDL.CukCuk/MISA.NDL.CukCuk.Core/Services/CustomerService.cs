using MISA.NDL.CukCuk.Core.Common.Attribute;
using MISA.NDL.CukCuk.Core.Common.NdlException;
using MISA.NDL.CukCuk.Core.Entities;
using MISA.NDL.CukCuk.Core.Interfaces.IRepositories;
using MISA.NDL.CukCuk.Core.Interfaces.IServices;
using MISA.NDL.CukCuk.Core.Services;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Service
{
    public class CustomerService :BaseService<Customer>, ICustomerService
    {
        public ICustomerRepository iCustomerRepository;
        public CustomerService(ICustomerRepository _iBaseRepository) : base(_iBaseRepository)
        {
            iCustomerRepository = _iBaseRepository;
        }


        /// <summary>
        /// thực hiện lấy dữ liệu từ file và thêm danh sách dữ liệu vào db
        /// validate dữ liệu
        /// </summary>
        /// <param name="worksheet"> file đầu vào</param>
        /// <returns> Trả về danh sách dữ liệu và trạng thái của từng đối tượng</returns>
        /// created by ndluc(27/05/2021)
        public ImportObject<Customer> Import(ExcelWorksheet worksheet)
        {
            var properties = typeof(Customer).GetProperties();
            List<Customer> list = new List<Customer>();
            Hashtable map = new Hashtable();

            // lấy dữ liệu trong file
            list = GetList(worksheet);


            var lenght = list.Count();
            var numberOfObjectInvalid = lenght;
            var numberOfObjectInsert = 0;
            
            //Kiểm tra dữ liệu bị trùng trong file
            #region kiểm tra dữ liệu bị trùng trong file
            
            //foreach (var customer in list)
            //{
            //    foreach (var property in properties)
            //    {
            //        if (property.GetCustomAttributes(typeof(NonDuplicate), true).Length > 0)
            //        {
            //            var propValue = property.GetValue(customer);
            //            if (propValue != null)
            //            {
            //                if (map[propValue.ToString()] == null || (int)map[propValue.ToString()] == 0)
            //                {
            //                    map.Add(propValue, 1);
            //                }
            //                else
            //                {
            //                    var newValue = (int)map[propValue.ToString()];
            //                    newValue += 1;
            //                    map.Remove(propValue.ToString());
            //                    map.Add(propValue.ToString(), newValue);
            //                }
            //            }
            //        }

            //    }
            //}
            #endregion
            #region Validate dữ liệu

            //validate dữ liệu.
            foreach (var customer in list)
            {
                foreach (var property in properties)
                {
                    var propValue = property.GetValue(customer);
                    //Check dữ liệu để trống
                    var nonEmpty = property.GetCustomAttributes(typeof(NonEmpty), true);
                    if (nonEmpty.Length > 0)
                    {

                        if (propValue == null)
                        {
                            customer.IsInvalid = false;
                            customer.Notification.Add((nonEmpty[0] as NonEmpty).ErrMsg);
                        }
                    }

                    // check trùng dữ liệu 
                    var nonDuplicate = property.GetCustomAttributes(typeof(NonDuplicate), true);
                    if (nonDuplicate.Length > 0 && propValue != null)
                    {
                        var proName = property.Name.ToString();
                        var checkDuplicateInFile = false;
                        //check trùng dữ liệu trong tệp nhập khẩu
                        if (map[propValue.ToString()] == null || (int)map[propValue.ToString()] == 0)
                        {
                            map.Add(propValue, 1);
                        }
                        else if ((int)map[propValue.ToString()] == 1)
                        {
                            customer.IsInvalid = false;
                            customer.Notification.Add(ConvertProNameToString(proName));
                            checkDuplicateInFile = true;
                        }

                        // check trùng trong csdl
                        if (checkDuplicateInFile == false)
                        {
                            var CheckDuplicateInData = iCustomerRepository.CheckExists(property.GetValue(customer).ToString(), proName);
                            if (CheckDuplicateInData)
                            {
                                customer.IsInvalid = false;
                                customer.Notification.Add((nonDuplicate[0] as NonDuplicate).ErrMsg);
                            }
                        }
                    }
                    // Check tên nhóm có tồn tại trong hệ thống hay không 
                    var CheckExist = property.GetCustomAttributes(typeof(CheckExists), true);
                    if (CheckExist.Length > 0)
                    {
                        var Id = iCustomerRepository.GetValue(propValue.ToString(), property.Name);
                        if (Id != Guid.Empty)
                        {
                            customer.CustomerGroupId = Id;
                        }
                        else
                        {
                            customer.IsInvalid = false;
                            customer.Notification.Add((CheckExist[0] as CheckExists).ErrMsg);
                        }
                    }
                }
                // kiểm tra đối tượng có hợp lệ hay không sau khi validate.
                if (customer.IsInvalid)
                {
                    // nếu đối tượng hợp lệ thì thêm ngay vào DB
                    var res = iCustomerRepository.Import(customer);
                    numberOfObjectInsert += res;
                    customer.Notification.Add(Properties.Resources.NotiInvalid);
                }
                else
                {
                    numberOfObjectInvalid--;
                }

            }
            #endregion

            //trả về danh sách đối tượng và trạng thái của từng đối tượng
            ImportObject<Customer> Result = new ImportObject<Customer>(numberOfObjectInvalid, lenght-numberOfObjectInsert,list);
            return Result;
        }


        

        /// <summary>
        /// Định nghĩa câu thông báo
        /// </summary>
        /// <param name="proName"> Chuỗi</param>
        /// created by ndluc(28/05/2021)

        private string ConvertProNameToString(string proName)
        {
            var propertyName = Properties.Resources.ResourceManager.GetString(proName);
            return propertyName +" " +Properties.Resources.Sentence1 +" "+ propertyName +" " +Properties.Resources.Sentence2;
        }

        /// <summary>
        /// Chuyển đối dữ liệu trong file sang danh sánh đối tượng
        /// </summary>
        /// <param name="worksheet"> file dữ liệu</param>
        /// <returns>
        /// danh sách đối tượng nhận được
        /// </returns>
        /// created by ndluc(29/05/2021)
        public List<Customer> GetList(ExcelWorksheet worksheet)
        {
            
            var properties = typeof(Customer).GetProperties();
            List<Customer> list = new List<Customer>();
            if (worksheet.Dimension != null)
            {
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;
                Hashtable map1 = new Hashtable();
                for (int col = 1; col <= colCount; col++)
                {
                    var cellName = worksheet.Cells[1, col].Value.ToString();
                    foreach (var property in properties)
                    {
                        var str = Properties.Resources.ResourceManager.GetString(property.Name.ToString());
                        if(str != null)
                        {
                            if (cellName.Contains(str))
                            {
                                map1.Add(property.Name, col);
                                break;
                            }
                        }
                        
                    }
                }
                for (int row = 2; row <= rowCount; row++)
                {
                    Customer customer = new Customer();
                    foreach (var property in properties)
                    {
                        var col = map1[property.Name];
                        if (col != null)
                        {
                            var value = worksheet.Cells[row, (int)col].Value;
                            //var NonDuplicate = property.GetCustomAttributes(typeof(NonDuplicate), true);
                            //if(NonDuplicate.Length >0)
                            //{
                            //    //kiểm tra trùng trong tệp
                            //}
                            if (property.PropertyType == typeof(string) && value != null)
                            {
                                property.SetValue(customer, worksheet.Cells[row, (int)col].Value.ToString());
                                //kiểm tra trùng trong tệp; 
                                // kiểm tra trùng trong cơ sở dữ liệu;
                            }
                            else if(value !=null)
                            {
                                DateTime valueDOB;
                                if (DateTime.TryParseExact(value.ToString(), new string[] { "dd/MM/yyyy", "yyyy", "MM/yyyy", "d/MM/yyyy", "M/yyyy", "d/M/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out valueDOB))
                                {
                                    property.SetValue(customer, valueDOB);
                                }
                                else
                                {
                                    throw new ValidateException(Properties.Resources.NotiDatetimeNotValid);
                                }

                            }
                        }
                    }
                    list.Add(customer);
                }
            }
            else
            {
                throw new ValidateException(Core.Properties.Resources.EmtyFile);
            }
            return list;

        }

        /// <summary>
        /// Hàm map tên các cột ứng với thuộc tính của đối tượng
        /// </summary>
        /// <param name="columName"> tên cột cần map</param>
        /// <returns> tên thuộc tính theo tiếng việt để map</returns>
        /// created by ndluc(27/05/2021)
        private string MapColumNameToProperty(string columName)
        {
            string result = "";
            switch (columName)
            {
                case "CustomerCode":
                    result = Core.Properties.Resources.CustomerCode;
                    break;
                case "FullName":
                    result = Core.Properties.Resources.CustomerFullName;
                    break;
                case "MemberCode":
                    result = Core.Properties.Resources.MemberCode;
                    break;
                case "PhoneNumber":
                    result = Core.Properties.Resources.PhoneNumber;
                    break;
                case "DateOfBirth":
                    result = Core.Properties.Resources.DateOfBirth;
                    break;
                case "CompanyName":
                    result = Core.Properties.Resources.CompanyName;
                    break;
                case "Email":
                    result = Core.Properties.Resources.Email;
                    break;
                case "Address":
                    result = Core.Properties.Resources.Address;
                    break;
                case "CustomerGroupName":
                    result = Core.Properties.Resources.CustomerGroupName;
                    break;
                case "Note":
                    result = Core.Properties.Resources.Note;
                    break;
                default:
                    result = "Không khớp";
                    break;
            }
            return result;
        }
    }
}
