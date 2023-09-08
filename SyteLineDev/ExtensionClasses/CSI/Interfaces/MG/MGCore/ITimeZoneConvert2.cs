using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface ITimeZoneConvert2
	{
        DateTime? TimeZoneConvert2Fn(DateTime? inDate,
        string fromTZ,
        string toTZ);
    }
}
