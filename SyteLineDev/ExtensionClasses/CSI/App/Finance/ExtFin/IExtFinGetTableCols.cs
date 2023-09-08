//PROJECT NAME: Finance
//CLASS NAME: IExtFinGetTableCols.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinGetTableCols
	{
		(int? ReturnCode, string Infobar,
		string ColNames,
		int? AllColsAppended) ExtFinGetTableColsSp(string PTableName,
		string LastColReturned,
		string Infobar,
		string ColNames,
		int? AllColsAppended);
	}
}

