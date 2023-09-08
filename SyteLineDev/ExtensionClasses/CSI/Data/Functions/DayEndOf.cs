using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
	public class DayEndOf : IDayEndOf
	{
        public DateTime? DayEndOfFn(DateTime? Date)
        {

            if (Date == null || Date == DateTime.MaxValue)
                return Date;
            
            var date = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, 23, 59, 59, 998);
            return date;
        }
    }
}
