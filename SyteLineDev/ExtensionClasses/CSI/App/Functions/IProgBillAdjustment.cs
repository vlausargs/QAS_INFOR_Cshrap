//PROJECT NAME: Data
//CLASS NAME: IProgBillAdjustment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProgBillAdjustment
	{
		(int? ReturnCode,
			decimal? AmountPosted,
			string Infobar) ProgBillAdjustmentSp(
			string InvNum,
			int? InvSeq,
			DateTime? InvDate,
			string CustNum,
			string CustaddrCurrCode,
			string ArinvType,
			decimal? ArinvExchRate,
			string TId,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? AmountPosted,
			string Infobar,
			int? IsControlNumberCreated = 0,
			DateTime? ArinvInvDate = null);
	}
}

