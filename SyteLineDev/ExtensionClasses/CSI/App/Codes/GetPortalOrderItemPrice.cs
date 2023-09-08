//PROJECT NAME: CSICodes
//CLASS NAME: GetPortalOrderItemPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetPortalOrderItemPrice
	{
		int GetPortalOrderItemPriceSp(string CurrCode,
		                              string Item,
		                              decimal? OrderQtyConv,
		                              byte? GenericIfNoCustSpecific,
		                              string PricingPrecalRule,
		                              string ShipFromSite,
		                              string CustNum,
		                              string CustItem,
		                              ref string CustItemUM,
		                              ref decimal? CustPriceConv,
		                              ref string Infobar);
	}
	
	public class GetPortalOrderItemPrice : IGetPortalOrderItemPrice
	{
		readonly IApplicationDB appDB;
		
		public GetPortalOrderItemPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetPortalOrderItemPriceSp(string CurrCode,
		                                     string Item,
		                                     decimal? OrderQtyConv,
		                                     byte? GenericIfNoCustSpecific,
		                                     string PricingPrecalRule,
		                                     string ShipFromSite,
		                                     string CustNum,
		                                     string CustItem,
		                                     ref string CustItemUM,
		                                     ref decimal? CustPriceConv,
		                                     ref string Infobar)
		{
			CurrCodeType _CurrCode = CurrCode;
			ItemType _Item = Item;
			QtyUnitNoNegType _OrderQtyConv = OrderQtyConv;
			ListYesNoType _GenericIfNoCustSpecific = GenericIfNoCustSpecific;
			PricingPrecalculationRuleType _PricingPrecalRule = PricingPrecalRule;
			SiteType _ShipFromSite = ShipFromSite;
			CustNumType _CustNum = CustNum;
			ItemType _CustItem = CustItem;
			UMType _CustItemUM = CustItemUM;
			CostPrcType _CustPriceConv = CustPriceConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPortalOrderItemPriceSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderQtyConv", _OrderQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenericIfNoCustSpecific", _GenericIfNoCustSpecific, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PricingPrecalRule", _PricingPrecalRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipFromSite", _ShipFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItemUM", _CustItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustPriceConv", _CustPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustItemUM = _CustItemUM;
				CustPriceConv = _CustPriceConv;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
