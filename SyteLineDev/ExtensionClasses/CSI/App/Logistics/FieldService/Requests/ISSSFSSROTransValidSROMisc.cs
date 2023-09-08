//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransValidSROMisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransValidSROMisc
	{
		(int? ReturnCode, int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		DateTime? PostDate,
		string PartnerID,
		string PartnerCurrCode,
		string Dept,
		string Whse,
		string BillCode,
		string MiscCode,
		string MiscCodeDesc,
		decimal? UnitCost,
		decimal? UnitPrice,
		string TaxCode1,
		string TaxCode2,
		string VatLabel,
		string PriceCurrCode,
		string Prompt,
		string PromptButtons,
		decimal? Disc,
		string Infobar,
		string CurAmtFormat,
		string CurCstPrcFormat,
		string ReimbTaxCode1,
		string ReimbTaxCode2,
		string ReimbMethod) SSSFSSROTransValidSROMiscSp(string Table,
		string Level,
		string SRONum,
		int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		DateTime? PostDate,
		string PartnerID,
		string PartnerCurrCode,
		string Dept,
		string Whse,
		string BillCode,
		string MiscCode,
		string MiscCodeDesc,
		decimal? UnitCost,
		decimal? UnitPrice,
		string TaxCode1,
		string TaxCode2,
		string VatLabel,
		string PriceCurrCode,
		string Prompt,
		string PromptButtons,
		decimal? Disc,
		string Infobar,
		string CurAmtFormat,
		string CurCstPrcFormat,
		string Type = "A",
		string ReimbTaxCode1 = null,
		string ReimbTaxCode2 = null,
		string ReimbMethod = null);
	}
}

