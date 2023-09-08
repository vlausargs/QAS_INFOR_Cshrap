using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IGetTimeByDateTime
	{
		string GetTimeByDateTimeFn(DateTime? InputDateTime,
		int? Use24Hour = 0);
	}
}
