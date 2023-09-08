//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroCopyOneTransLineMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroCopyOneTransLineMatl
	{
		(int? ReturnCode,
			string Infobar,
			Guid? TargetRowPointer) SSSFSSroCopyOneTransLineMatlSp(
			string ToSroNum,
			int? ToSroLine,
			string CustNum,
			string CurrCode,
			int? UseSroWhse,
			decimal? LineQty,
			Guid? OrigRowPointer,
			string BillCode,
			decimal? Cost,
			decimal? CostConv,
			string Loc,
			string Lot,
			string PartnerId,
			decimal? Price,
			decimal? PriceConv,
			string PriceCode,
			string Item,
			string Description,
			decimal? Qty,
			decimal? QtyConv,
			string UM,
			string Whse,
			string TransType,
			int? RtnToStock,
			int? NoteExists,
			string iDefTaxCode1,
			string iDefTaxCode2,
			string iDefBillCode,
			string iDept,
			decimal? iDisc,
			string iTaxCode1,
			string iTaxCode2,
			string iUsageType,
			decimal? iMatlCostConv,
			decimal? iLbrCostConv,
			decimal? iFovhdCostConv,
			decimal? iVovhdCostConv,
			decimal? iOutCostConv,
			string Infobar,
			Guid? TargetRowPointer,
			int? Level = 0,
			DateTime? iPostDate = null,
			DateTime? iTransDate = null,
			DateTime? iExchDate = null);
	}
}

