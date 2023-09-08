//PROJECT NAME: POS
//CLASS NAME: ISSSPOSPostPmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSPostPmt
	{
		(int? ReturnCode,
			string Infobar) SSSPOSPostPmtSp(
			string POSNum,
			string CustNum,
			int? POSMCredit,
			string POSMDrawerOrderType,
			Guid? SessionID,
			decimal? UserID,
			string Infobar);
	}
}

