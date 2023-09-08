//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransMiscCstPrcTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransMiscCstPrcTax
	{
		(int? ReturnCode, decimal? DefCost,
		decimal? DefPrice,
		string TaxCode1,
		string TaxCode2,
		string Infobar) SSSFSSROTransMiscCstPrcTaxSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string MiscCode,
		string BillCode,
		DateTime? TransDate,
		string PartnerId,
		decimal? Qty,
		decimal? DefCost,
		decimal? DefPrice,
		string TaxCode1,
		string TaxCode2,
		string Infobar);
	}
}

