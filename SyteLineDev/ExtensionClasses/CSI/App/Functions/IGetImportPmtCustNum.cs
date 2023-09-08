//PROJECT NAME: Data
//CLASS NAME: IGetImportPmtCustNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetImportPmtCustNum
	{
		(int? ReturnCode,
			string CustNum,
			string Infobar) GetImportPmtCustNumSp(
			decimal? BatchId,
			int? HeaderNum,
			string RoutingNum,
			string AccountNum,
			string CustNum,
			string Infobar);
	}
}

