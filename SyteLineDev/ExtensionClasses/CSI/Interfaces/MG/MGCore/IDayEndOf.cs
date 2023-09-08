using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IDayEndOf
	{
        DateTime? DayEndOfFn(DateTime? Date);
    }
}
