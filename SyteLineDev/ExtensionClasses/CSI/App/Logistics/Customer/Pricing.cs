//PROJECT NAME: Logistics
//CLASS NAME: Pricing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Pricing : IPricing
	{
		readonly IApplicationDB appDB;
		
		
		public Pricing(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? BrkQty1,
		decimal? BrkQty2,
		decimal? BrkQty3,
		decimal? BrkQty4,
		decimal? BrkQty5,
		decimal? UnitPrice1,
		decimal? UnitPrice2,
		decimal? UnitPrice3,
		decimal? UnitPrice4,
		decimal? UnitPrice5,
		decimal? ContPrice,
		string PricingBasis,
		string Infobar) PricingSP(string CustNum,
		string Item,
		string CustItem = null,
		string CurrCode = null,
		decimal? BrkQty1 = null,
		decimal? BrkQty2 = null,
		decimal? BrkQty3 = null,
		decimal? BrkQty4 = null,
		decimal? BrkQty5 = null,
		decimal? UnitPrice1 = null,
		decimal? UnitPrice2 = null,
		decimal? UnitPrice3 = null,
		decimal? UnitPrice4 = null,
		decimal? UnitPrice5 = null,
		decimal? ContPrice = null,
		string PricingBasis = null,
		string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			CustItemType _CustItem = CustItem;
			CurrCodeType _CurrCode = CurrCode;
			QtyUnitType _BrkQty1 = BrkQty1;
			QtyUnitType _BrkQty2 = BrkQty2;
			QtyUnitType _BrkQty3 = BrkQty3;
			QtyUnitType _BrkQty4 = BrkQty4;
			QtyUnitType _BrkQty5 = BrkQty5;
			CostPrcType _UnitPrice1 = UnitPrice1;
			CostPrcType _UnitPrice2 = UnitPrice2;
			CostPrcType _UnitPrice3 = UnitPrice3;
			CostPrcType _UnitPrice4 = UnitPrice4;
			CostPrcType _UnitPrice5 = UnitPrice5;
			CostPrcType _ContPrice = ContPrice;
			InfobarType _PricingBasis = PricingBasis;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PricingSP";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQty1", _BrkQty1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQty2", _BrkQty2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQty3", _BrkQty3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQty4", _BrkQty4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQty5", _BrkQty5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice1", _UnitPrice1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice2", _UnitPrice2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice3", _UnitPrice3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice4", _UnitPrice4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice5", _UnitPrice5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContPrice", _ContPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PricingBasis", _PricingBasis, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BrkQty1 = _BrkQty1;
				BrkQty2 = _BrkQty2;
				BrkQty3 = _BrkQty3;
				BrkQty4 = _BrkQty4;
				BrkQty5 = _BrkQty5;
				UnitPrice1 = _UnitPrice1;
				UnitPrice2 = _UnitPrice2;
				UnitPrice3 = _UnitPrice3;
				UnitPrice4 = _UnitPrice4;
				UnitPrice5 = _UnitPrice5;
				ContPrice = _ContPrice;
				PricingBasis = _PricingBasis;
				Infobar = _Infobar;
				
				return (Severity, BrkQty1, BrkQty2, BrkQty3, BrkQty4, BrkQty5, UnitPrice1, UnitPrice2, UnitPrice3, UnitPrice4, UnitPrice5, ContPrice, PricingBasis, Infobar);
			}
		}
	}
}
