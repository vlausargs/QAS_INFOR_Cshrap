//PROJECT NAME: CSICustomer
//CLASS NAME: AU_CalculateCoLineReleasePrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IAU_CalculateCoLineReleasePrice
	{
		(int? ReturnCode, string ItemUM, decimal? PriceConv, string Infobar, byte? DispMsg, decimal? LineDisc, byte? TaxInPriceDiff) AU_CalculateCoLineReleasePriceSp(string CoNum,
		string CustNum,
		string Item,
		string ItemUM,
		string CustItem,
		string ShipSite,
		DateTime? OrderDate,
		DateTime? DueDate,
		decimal? InQtyConv,
		string CurrCode,
		string ItemPriceCode,
		decimal? PriceConv,
		string Infobar,
		short? CoLine,
		byte? DispMsg = (byte)0,
		string ItemWhse = null,
		decimal? LineDisc = 0,
		byte? TaxInPriceDiff = (byte)0,
		string PromotionCode = null);
	}
	
	public class AU_CalculateCoLineReleasePrice : IAU_CalculateCoLineReleasePrice
	{
		readonly IApplicationDB appDB;
		
		public AU_CalculateCoLineReleasePrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ItemUM, decimal? PriceConv, string Infobar, byte? DispMsg, decimal? LineDisc, byte? TaxInPriceDiff) AU_CalculateCoLineReleasePriceSp(string CoNum,
		string CustNum,
		string Item,
		string ItemUM,
		string CustItem,
		string ShipSite,
		DateTime? OrderDate,
		DateTime? DueDate,
		decimal? InQtyConv,
		string CurrCode,
		string ItemPriceCode,
		decimal? PriceConv,
		string Infobar,
		short? CoLine,
		byte? DispMsg = (byte)0,
		string ItemWhse = null,
		decimal? LineDisc = 0,
		byte? TaxInPriceDiff = (byte)0,
		string PromotionCode = null)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			UMType _ItemUM = ItemUM;
			ItemType _CustItem = CustItem;
			SiteType _ShipSite = ShipSite;
			GenericDateType _OrderDate = OrderDate;
			GenericDateType _DueDate = DueDate;
			QtyUnitType _InQtyConv = InQtyConv;
			CurrCodeType _CurrCode = CurrCode;
			PriceCodeType _ItemPriceCode = ItemPriceCode;
			AmountType _PriceConv = PriceConv;
			Infobar _Infobar = Infobar;
			CoLineType _CoLine = CoLine;
			ListYesNoType _DispMsg = DispMsg;
			WhseType _ItemWhse = ItemWhse;
			LineDiscType _LineDisc = LineDisc;
			ListYesNoType _TaxInPriceDiff = TaxInPriceDiff;
			PromotionCodeType _PromotionCode = PromotionCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_CalculateCoLineReleasePriceSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InQtyConv", _InQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceCode", _ItemPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispMsg", _DispMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemWhse", _ItemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineDisc", _LineDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxInPriceDiff", _TaxInPriceDiff, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromotionCode", _PromotionCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemUM = _ItemUM;
				PriceConv = _PriceConv;
				Infobar = _Infobar;
				DispMsg = _DispMsg;
				LineDisc = _LineDisc;
				TaxInPriceDiff = _TaxInPriceDiff;
				
				return (Severity, ItemUM, PriceConv, Infobar, DispMsg, LineDisc, TaxInPriceDiff);
			}
		}
	}
}
