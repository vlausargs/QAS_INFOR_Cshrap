using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IIndexIncludeColumnString
	{
		string IndexIncludeColumnStringFn(string IndexName,
		string TableName);
	}
}
