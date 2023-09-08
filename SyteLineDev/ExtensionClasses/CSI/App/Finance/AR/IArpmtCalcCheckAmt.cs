//PROJECT NAME: Finance
//CLASS NAME: IArpmtCalcCheckAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtCalcCheckAmt
	{
		(int? ReturnCode,
			decimal? POutCheckAmt,
			string Infobar) ArpmtCalcCheckAmtSp(
			decimal? PExchRate,
			decimal? PInCheckAmt,
			string PCustCurr,
			DateTime? PRecptDate,
			int? PToCustomer,
			decimal? POutCheckAmt,
			string Infobar);
	}
}

