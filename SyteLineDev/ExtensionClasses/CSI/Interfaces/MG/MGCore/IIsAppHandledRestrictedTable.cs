using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IIsAppHandledRestrictedTable
	{
		int? IsAppHandledRestrictedTableFn(string TableName);
	}
}
