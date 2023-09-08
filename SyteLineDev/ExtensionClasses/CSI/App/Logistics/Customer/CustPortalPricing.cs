//PROJECT NAME: Logistics
//CLASS NAME: CustPortalPricing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustPortalPricing : ICustPortalPricing
	{
		readonly IApplicationDB appDB;
		
		
		public CustPortalPricing(IApplicationDB appDB)
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
		decimal? ContactPrice,
		string ISOCurrCode,
		string Infobar) CustPortalPricingSp(string CustNum,
		string Item,
		string ItemIndicator,
		decimal? BrkQty1,
		decimal? BrkQty2,
		decimal? BrkQty3,
		decimal? BrkQty4,
		decimal? BrkQty5,
		decimal? UnitPrice1,
		decimal? UnitPrice2,
		decimal? UnitPrice3,
		decimal? UnitPrice4,
		decimal? UnitPrice5,
		decimal? ContactPrice,
		string ISOCurrCode,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			StringType _ItemIndicator = ItemIndicator;
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
			CostPrcType _ContactPrice = ContactPrice;
			CurrCodeType _ISOCurrCode = ISOCurrCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustPortalPricingSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemIndicator", _ItemIndicator, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "ContactPrice", _ContactPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ISOCurrCode", _ISOCurrCode, ParameterDirection.InputOutput);
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
				ContactPrice = _ContactPrice;
				ISOCurrCode = _ISOCurrCode;
				Infobar = _Infobar;
				
				return (Severity, BrkQty1, BrkQty2, BrkQty3, BrkQty4, BrkQty5, UnitPrice1, UnitPrice2, UnitPrice3, UnitPrice4, UnitPrice5, ContactPrice, ISOCurrCode, Infobar);
			}
		}
	}
}
