//PROJECT NAME: CSICustomer
//CLASS NAME: CalculateEdiCoitemPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICalculateEdiCoitemPrice
	{
		(int? ReturnCode, decimal? PriceConv, string Infobar, decimal? LineDisc) CalculateEdiCoitemPriceSp(string CoNum,
		string CustNum,
		string Item,
		string ItemUM,
		string CustItem,
		DateTime? OrderDate,
		decimal? InQtyConv,
		string CurrCode,
		string PriceCode,
		decimal? PriceConv,
		string Infobar,
		short? CoLine,
		string ItemWhse = null,
		decimal? LineDisc = 0);
	}
	
	public class CalculateEdiCoitemPrice : ICalculateEdiCoitemPrice
	{
		readonly IApplicationDB appDB;
		
		public CalculateEdiCoitemPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PriceConv, string Infobar, decimal? LineDisc) CalculateEdiCoitemPriceSp(string CoNum,
		string CustNum,
		string Item,
		string ItemUM,
		string CustItem,
		DateTime? OrderDate,
		decimal? InQtyConv,
		string CurrCode,
		string PriceCode,
		decimal? PriceConv,
		string Infobar,
		short? CoLine,
		string ItemWhse = null,
		decimal? LineDisc = 0)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			UMType _ItemUM = ItemUM;
			ItemType _CustItem = CustItem;
			GenericDateType _OrderDate = OrderDate;
			QtyUnitType _InQtyConv = InQtyConv;
			CurrCodeType _CurrCode = CurrCode;
			PriceCodeType _PriceCode = PriceCode;
			AmountType _PriceConv = PriceConv;
			Infobar _Infobar = Infobar;
			CoLineType _CoLine = CoLine;
			WhseType _ItemWhse = ItemWhse;
			LineDiscType _LineDisc = LineDisc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalculateEdiCoitemPriceSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InQtyConv", _InQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemWhse", _ItemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineDisc", _LineDisc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriceConv = _PriceConv;
				Infobar = _Infobar;
				LineDisc = _LineDisc;
				
				return (Severity, PriceConv, Infobar, LineDisc);
			}
		}
	}
}
