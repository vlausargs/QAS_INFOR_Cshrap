//PROJECT NAME: Data
//CLASS NAME: IItemCc2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemCc2
	{
		(int? ReturnCode,
			decimal? Tot,
			Guid? MatltranRowPointer,
			string Infobar,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			int? last_seq,
			decimal? TransNum,
			int? TransSeq) ItemCc2Sp(
			int? Ccp,
			Guid? RowPointer,
			string Item,
			decimal? Tot,
			decimal? MatlAdj,
			decimal? LbrAdj,
			decimal? FovhdAdj,
			decimal? VovhdAdj,
			decimal? OutAdj,
			Guid? MatltranRowPointer,
			string Infobar,
			string RefStr = "INV CHGM",
			string Lot = null,
			int? ParmsPostJour = null,
			int? CurrencyPlaces = null,
			string DomCurrCode = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			int? AccountsValidated = 0,
			string CurUserCode = null,
			int? last_seq = null,
			string ProcName = null,
			decimal? TransNum = null,
			int? TransSeq = null);
	}
}

