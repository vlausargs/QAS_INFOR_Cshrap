//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransCstPrcTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransCstPrcTax
	{
		(int? ReturnCode, decimal? DefCost,
		decimal? DefPrice,
		decimal? Disc,
		string TaxCode1,
		string TaxCode2,
		string Infobar,
		string RefType) SSSFSSROTransCstPrcTaxSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string Item,
		string Whse,
		string Loc,
		string Lot,
		string BillCode,
		DateTime? TransDate,
		string Pricecode,
		decimal? Qty,
		string PartnerId,
		string UM,
		decimal? DefCost,
		decimal? DefPrice,
		decimal? Disc,
		string TaxCode1,
		string TaxCode2,
		string Infobar,
		decimal? Cost = null,
		string CustItem = null,
		string RefType = null);
	}
}

