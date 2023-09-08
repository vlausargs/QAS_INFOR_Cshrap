using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IDataTypeString
	{
		string DataTypeStringFn(string Domain,
		string Type,
		int? Length,
		int? Precision,
		int? Scale);
	}
}
