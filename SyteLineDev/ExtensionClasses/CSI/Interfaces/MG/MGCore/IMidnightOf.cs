using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IMidnightOf
	{
		DateTime? MidnightOfFn(DateTime? Date);
		DateTime? MidnightOfSp(DateTime? Date);
	}
}
