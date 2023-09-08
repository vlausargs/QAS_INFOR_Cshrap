//PROJECT NAME: Logistics
//CLASS NAME: IGetParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetParms
	{
		(int? ReturnCode, decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string PEFTBankCode,
		string PEFTFormat,
		string PEFTUserName,
		string PEFTUserNumber,
		int? PPrintManualRemitAdvice,
		int? PPrintEFTRemitAdvice,
		int? PPrintWireRemitAdvice,
		int? PPrintDraftRemitAdvice) GetParmsSp(decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string PEFTBankCode,
		string PEFTFormat,
		string PEFTUserName,
		string PEFTUserNumber,
		int? PPrintManualRemitAdvice,
		int? PPrintEFTRemitAdvice,
		int? PPrintWireRemitAdvice,
		int? PPrintDraftRemitAdvice);
	}
}

