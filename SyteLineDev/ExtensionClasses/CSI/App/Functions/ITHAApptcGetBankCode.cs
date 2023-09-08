//PROJECT NAME: Data
//CLASS NAME: ITHAApptcGetBankCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcGetBankCode
	{
		(int? ReturnCode,
			string PBankCode,
			string Infobar) THAApptcGetBankCodeSp(
			string PPayType,
			int? PCheckNum,
			string PVendNum,
			DateTime? PCheckDate,
			decimal? PAmtPaid,
			string PBankCode,
			string Infobar);
	}
}

