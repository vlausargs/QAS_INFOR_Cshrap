//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransLaborCstPrcTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransLaborCstPrcTax
	{
		(int? ReturnCode, decimal? DefCost,
		decimal? DefPrice,
		string TaxCode1,
		string TaxCode2,
		string Infobar) SSSFSSROTransLaborCstPrcTaxSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string WorkCode,
		string BillCode,
		DateTime? TransDate,
		string PartnerId,
		decimal? HrsWorked,
		decimal? HrsToBill,
		decimal? DefCost,
		decimal? DefPrice,
		string TaxCode1,
		string TaxCode2,
		string Infobar);
	}
}

