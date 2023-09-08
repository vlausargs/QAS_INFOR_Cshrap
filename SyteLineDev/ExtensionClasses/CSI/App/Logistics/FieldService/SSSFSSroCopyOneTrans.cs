//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyOneTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroCopyOneTrans : ISSSFSSroCopyOneTrans
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopyOneTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			DateTime? TransDate = null)
		{
			FSSRONumType _ToSroNum = ToSroNum;
			FSSROLineType _ToSroLine = ToSroLine;
			FSSROOperType _ToSroOper = ToSroOper;
			ItemType _CompItem = CompItem;
			QtyUnitType _CompQtyOrd = CompQtyOrd;
			FSCompIdType _ConfigCompId = ConfigCompId;
			ListYesNoType _OperUseEst = OperUseEst;
			StringType _TypeOfTrans = TypeOfTrans;
			StringType _TypeOfToTrans = TypeOfToTrans;
			CustNumType _CustNum = CustNum;
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _UseSroWhse = UseSroWhse;
			ListYesNoType _ExtendMatl = ExtendMatl;
			QtyUnitType _LineQty = LineQty;
			RowPointerType _OrigRowPointer = OrigRowPointer;
			FSSROBillCodeType _BillCode = BillCode;
			CostPrcType _Cost = Cost;
			CostPrcType _CostConv = CostConv;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			FSPartnerType _PartnerId = PartnerId;
			CostPrcType _Price = Price;
			CostPrcType _PriceConv = PriceConv;
			PriceCodeType _PriceCode = PriceCode;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			QtyUnitType _Qty = Qty;
			QtyUnitType _QtyConv = QtyConv;
			UMType _UM = UM;
			WhseType _Whse = Whse;
			FSSROTransTypeType _TransType = TransType;
			ListYesNoType _RtnToStock = RtnToStock;
			ListYesNoType _NoteExists = NoteExists;
			InfobarType _Infobar = Infobar;
			IntType _Level = Level;
			CustItemType _CustItem = CustItem;
			DateType _TransDate = TransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopyOneTransSp";
				
				appDB.AddCommandParameter(cmd, "ToSroNum", _ToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSroLine", _ToSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSroOper", _ToSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompItem", _CompItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompQtyOrd", _CompQtyOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigCompId", _ConfigCompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperUseEst", _OperUseEst, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TypeOfTrans", _TypeOfTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TypeOfToTrans", _TypeOfToTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseSroWhse", _UseSroWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtendMatl", _ExtendMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineQty", _LineQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigRowPointer", _OrigRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RtnToStock", _RtnToStock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteExists", _NoteExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
