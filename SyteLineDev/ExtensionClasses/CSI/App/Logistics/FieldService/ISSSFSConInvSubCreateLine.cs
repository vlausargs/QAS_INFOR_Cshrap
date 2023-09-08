//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCreateLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCreateLine
	{
		(int? ReturnCode,
			string DeferredAcct,
			string DeferredAcctUnit1,
			string DeferredAcctUnit2,
			string DeferredAcctUnit3,
			string DeferredAcctUnit4,
			int? InvLine,
			int? InvSubLine,
			string Infobar) SSSFSConInvSubCreateLineSp(
			string InvNum,
			string SerNum,
			string Item,
			string Description,
			string Contract,
			int? ContLine,
			decimal? Rate,
			DateTime? StartDate,
			DateTime? EndDate,
			string BillFreq,
			DateTime? BilledThru,
			decimal? Qty,
			int? FirstInside,
			decimal? Amount,
			DateTime? BillStart,
			DateTime? BillEnd,
			string TaxCode1,
			string TaxCode2,
			string SalesAcct,
			string SalesAcctUnit1,
			string SalesAcctUnit2,
			string SalesAcctUnit3,
			string SalesAcctUnit4,
			int? CheckAmort,
			string CustNum,
			string ProductCode,
			string Whse,
			string ContPriceBasis,
			decimal? MeterRate,
			int? StartMeterAmt,
			int? EndMeterAmt,
			int? BillingStartMeterAmt,
			int? BillingEndMeterAmt,
			decimal? DateAmount,
			decimal? MeterAmount,
			int? InclWaiverCharge,
			string DeferredAcct,
			string DeferredAcctUnit1,
			string DeferredAcctUnit2,
			string DeferredAcctUnit3,
			string DeferredAcctUnit4,
			int? InvLine,
			int? InvSubLine,
			string Infobar);
	}
}

