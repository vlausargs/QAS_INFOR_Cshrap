using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IMinDate
	{
		DateTime? MinDateFn(DateTime? Date1,
		DateTime? Date2);
	}
}
