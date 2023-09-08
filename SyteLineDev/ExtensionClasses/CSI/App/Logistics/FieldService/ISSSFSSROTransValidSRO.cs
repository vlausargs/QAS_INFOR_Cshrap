//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransValidSRO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROTransValidSRO
	{
		(int? ReturnCode,
			string Item,
			int? SROLine,
			int? SROOper,
			DateTime? TransDate,
			DateTime? PostDate,
			string PartnerID,
			string Dept,
			string Whse,
			string BillCode,
			string TaxCode1,
			string TaxCode2,
			string VatLabel,
			string PriceCurrCode,
			string Prompt,
			string PromptButtons,
			string Infobar,
			string SROCustNum) SSSFSSROTransValidSROSp(
			string Table,
			string Level,
			string Item,
			string SRONum,
			int? SROLine,
			int? SROOper,
			DateTime? TransDate,
			DateTime? PostDate,
			string PartnerID,
			string Dept,
			string Whse,
			string BillCode,
			string TaxCode1,
			string TaxCode2,
			string VatLabel,
			string PriceCurrCode,
			string Prompt,
			string PromptButtons,
			string Infobar,
			string SROCustNum);
	}
}

