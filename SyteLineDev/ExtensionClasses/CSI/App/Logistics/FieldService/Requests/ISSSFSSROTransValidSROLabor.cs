//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransValidSROLabor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransValidSROLabor
	{
		(int? ReturnCode, int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		DateTime? PostDate,
		string PartnerID,
		int? PartnerReimbLabor,
		string Dept,
		string Whse,
		string BillCode,
		string WorkCode,
		string WorkCodeDesc,
		decimal? UnitCost,
		decimal? UnitRate,
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
		string ReimbMethod) SSSFSSROTransValidSROLaborSp(string Table,
		string Level,
		string SRONum,
		int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		DateTime? PostDate,
		string PartnerID,
		int? PartnerReimbLabor,
		string Dept,
		string Whse,
		string BillCode,
		string WorkCode,
		string WorkCodeDesc,
		decimal? UnitCost,
		decimal? UnitRate,
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

