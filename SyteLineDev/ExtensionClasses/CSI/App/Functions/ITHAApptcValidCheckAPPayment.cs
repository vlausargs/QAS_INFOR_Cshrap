//PROJECT NAME: Data
//CLASS NAME: ITHAApptcValidCheckAPPayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcValidCheckAPPayment
	{
		(int? ReturnCode,
			string PBankCode,
			int? POpenPay,
			decimal? PForCheckAmt,
			decimal? PDomCheckAmt,
			decimal? PExchRate,
			DateTime? PCheckDate,
			string PRef,
			string Infobar) THAApptcValidCheckAPPaymentSp(
			int? PNewRecord,
			int? PCheckNum,
			string PPayType,
			int? PReapplication,
			string PVendNum,
			string PBankCode,
			int? POpenPay,
			decimal? PForCheckAmt,
			decimal? PDomCheckAmt,
			decimal? PExchRate,
			DateTime? PCheckDate,
			string PRef,
			string Infobar);
	}
}

