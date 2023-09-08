//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransCstPrcTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransCstPrcTax : ISSSFSSROTransCstPrcTax
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROTransCstPrcTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? DefCost,
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
		string RefType = null)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			FSSROBillCodeType _BillCode = BillCode;
			DateType _TransDate = TransDate;
			PriceCodeType _Pricecode = Pricecode;
			QtyUnitType _Qty = Qty;
			FSPartnerType _PartnerId = PartnerId;
			UMType _UM = UM;
			CostPrcType _DefCost = DefCost;
			CostPrcType _DefPrice = DefPrice;
			LineDiscType _Disc = Disc;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			Infobar _Infobar = Infobar;
			CostPrcType _Cost = Cost;
			CustItemType _CustItem = CustItem;
			RefTypeIJKPRTType _RefType = RefType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransCstPrcTaxSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefCost", _DefCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefPrice", _DefPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DefCost = _DefCost;
				DefPrice = _DefPrice;
				Disc = _Disc;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				Infobar = _Infobar;
				RefType = _RefType;
				
				return (Severity, DefCost, DefPrice, Disc, TaxCode1, TaxCode2, Infobar, RefType);
			}
		}
	}
}
