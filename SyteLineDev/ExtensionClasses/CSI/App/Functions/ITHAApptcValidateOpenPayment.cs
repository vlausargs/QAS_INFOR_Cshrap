//PROJECT NAME: Data
//CLASS NAME: ITHAApptcValidateOpenPayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcValidateOpenPayment
	{
		(int? ReturnCode,
			int? POpenPay,
			decimal? PForCheckAmt,
			decimal? PDomCheckAmt,
			decimal? PExchRate,
			DateTime? PCheckDate,
			string PRef,
			string Infobar) THAApptcValidateOpenPaymentSp(
			string PVendNum,
			int? PCheckNum,
			int? POpenPay,
			decimal? PForCheckAmt,
			decimal? PDomCheckAmt,
			decimal? PExchRate,
			DateTime? PCheckDate,
			string PRef,
			string Infobar);
	}
}

