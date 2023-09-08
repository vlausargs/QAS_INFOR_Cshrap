//PROJECT NAME: Finance
//CLASS NAME: IFinRptLinRmtSiteTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptLinRmtSiteTrans
	{
		int? FinRptLinRmtSiteTransSp(
			string FullTextSql);
	}
}

