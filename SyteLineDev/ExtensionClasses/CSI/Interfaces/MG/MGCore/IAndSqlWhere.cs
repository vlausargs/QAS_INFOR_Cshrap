using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IAndSqlWhere
	{
		string AndSqlWhereFn(string TableAlias,
		string ColumnName,
		int? UseQuotes,
		string LowValue,
		string HighValue);
	}
}
