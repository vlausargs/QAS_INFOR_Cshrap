//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCreateAdjustment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCreateAdjustment
	{
		(int? ReturnCode,
			string Infobar) SSSPOSCreateAdjustmentSp(
			decimal? AdjAmt,
			string PosPayTypeBankCode,
			DateTime? AdjustmentPostingDate,
			string CashDrawer,
			string CurrCode,
			string Infobar);
	}
}

