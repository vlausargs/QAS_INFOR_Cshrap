//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroCopyOneTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroCopyOneTrans
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroCopyOneTransSp(
			string ToSroNum,
			int? ToSroLine,
			int? ToSroOper,
			string CompItem,
			decimal? CompQtyOrd,
			int? ConfigCompId,
			int? OperUseEst,
			string TypeOfTrans,
			string TypeOfToTrans,
			string CustNum,
			string CurrCode,
			int? UseSroWhse,
			int? ExtendMatl,
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
			string Infobar,
			int? Level = 0,
			string CustItem = null,
			DateTime? TransDate = null);
	}
}

