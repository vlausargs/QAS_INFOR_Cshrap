//PROJECT NAME: Finance
//CLASS NAME: IInitPeriodsTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IInitPeriodsTable
	{
		(int? ReturnCode, int? pAllowInsertForSite) InitPeriodsTableSp(int? pAllowInsertForSite);
	}
}

