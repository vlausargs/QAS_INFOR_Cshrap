using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IWhereClauseLine
	{
		string WhereClauseLineFn(string WhereClause,
		string KeyName,
		string KeyValue,
		string TableAlias);
	}
}
