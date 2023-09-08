//PROJECT NAME: Logistics
//CLASS NAME: IRmaitemLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaitemLog
	{
		(int? ReturnCode,
			string Infobar) RmaitemLogSp(
			string Action,
			decimal? OldQtyToReturnConv,
			decimal? NewQtyToReturnConv,
			decimal? OldUnitCreditConv,
			decimal? NewUnitCreditConv,
			string OldUM,
			string NewUM,
			string RmaitemRmaNum,
			int? RmaitemRmaLine,
			string RmaitemItem,
			string RmaitemCoNum,
			int? RmaitemCoLine,
			int? RmaitemCoRelease,
			decimal? UMConvFactor,
			string CustNum,
			int? CurrencyPlaces,
			string Infobar);
	}
}

