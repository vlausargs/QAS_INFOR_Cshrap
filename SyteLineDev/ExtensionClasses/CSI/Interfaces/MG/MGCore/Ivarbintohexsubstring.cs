using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface Ivarbintohexsubstring
	{
		string varbintohexsubstringFn(bool? fsetprefix = true,
		byte[] pbinin = null,
		int? startoffset = 1,
		int? cbytesin = 0);
	}
}
