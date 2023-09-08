//PROJECT NAME: Logistics
//CLASS NAME: CalculateCoitemPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CalculateCoitemPrice : ICalculateCoitemPrice
	{
		readonly IApplicationDB appDB;
		
		
		public CalculateCoitemPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ItemUM,
		decimal? PriceConv,
		string Infobar,
		int? DispMsg,
		decimal? LineDisc,
		int? TaxInPriceDiff) CalculateCoitemPriceSp(string CoNum,
		string CustNum,
		string Item,
		string ItemUM,
		string CustItem,
		string ShipSite,
		DateTime? OrderDate,
		decimal? InQtyConv,
		string CurrCode,
		string ItemPriceCode,
		decimal? PriceConv,
		string Infobar,
		int? CoLine,
		int? DispMsg = 0,
		string ItemWhse = null,
		decimal? LineDisc = 0,
		int? TaxInPriceDiff = 0,
		string PromotionCode = null,
		string AUContractPriceMethod = null,
		string ConTractID = null)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			UMType _ItemUM = ItemUM;
			ItemType _CustItem = CustItem;
			SiteType _ShipSite = ShipSite;
			GenericDateType _OrderDate = OrderDate;
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
			AU_ContractPriceMethodType _AUContractPriceMethod = AUContractPriceMethod;
			AU_ContractIDType _ConTractID = ConTractID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalculateCoitemPriceSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "AUContractPriceMethod", _AUContractPriceMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConTractID", _ConTractID, ParameterDirection.Input);
				
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
