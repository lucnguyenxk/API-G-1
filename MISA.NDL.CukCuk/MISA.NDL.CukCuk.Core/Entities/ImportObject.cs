using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NDL.CukCuk.Core.Entities
{
     public class ImportObject<T>
    {
        public int SuccedRecord { get; set; }
        public int ErrRecord { get; set; }
        public List<T> ListRecord { get; set; }
        public ImportObject( int succedRecord ,  int errRecord, List<T> listRecord)
        {
            SuccedRecord = succedRecord;
            ErrRecord = errRecord;
            ListRecord = listRecord;
        }
    }
}
