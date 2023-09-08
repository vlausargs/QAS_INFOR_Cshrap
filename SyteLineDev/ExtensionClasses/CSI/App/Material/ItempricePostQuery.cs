//PROJECT NAME: Material
//CLASS NAME: ItempricePostQuery.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItempricePostQuery : IItempricePostQuery
	{
		readonly IApplicationDB appDB;
		
		
		public ItempricePostQuery(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? DerUnitPrice1,
		decimal? DerUnitPrice2,
		decimal? DerUnitPrice3,
		decimal? DerUnitPrice4,
		decimal? DerUnitPrice5) ItempricePostQuerySp(decimal? UnitPrice1,
		decimal? UnitPrice2,
		decimal? UnitPrice3,
		decimal? UnitPrice4,
		decimal? UnitPrice5,
		decimal? UnitPrice6,
		decimal? UnitCost,
		string CurItem,
		string CurCurrCode,
		DateTime? CurEffectDate,
		string DolPercent1,
		string DolPercent2,
		string DolPercent3,
		string DolPercent4,
		string DolPercent5,
		string BaseCode1,
		string BaseCode2,
		string BaseCode3,
		string BaseCode4,
		string BaseCode5,
		decimal? BrkQty1,
		decimal? BrkQty2,
		decimal? BrkQty3,
		decimal? BrkQty4,
		decimal? BrkQty5,
		decimal? BrkPrice1,
		decimal? BrkPrice2,
		decimal? BrkPrice3,
		decimal? BrkPrice4,
		decimal? BrkPrice5,
		decimal? DerUnitPrice1,
		decimal? DerUnitPrice2,
		decimal? DerUnitPrice3,
		decimal? DerUnitPrice4,
		decimal? DerUnitPrice5)
		{
			CostPrcType _UnitPrice1 = UnitPrice1;
			CostPrcType _UnitPrice2 = UnitPrice2;
			CostPrcType _UnitPrice3 = UnitPrice3;
			CostPrcType _UnitPrice4 = UnitPrice4;
			CostPrcType _UnitPrice5 = UnitPrice5;
			CostPrcType _UnitPrice6 = UnitPrice6;
			CostPrcType _UnitCost = UnitCost;
			ItemType _CurItem = CurItem;
			CurrCodeType _CurCurrCode = CurCurrCode;
			Date4Type _CurEffectDate = CurEffectDate;
			ListAmountPercentType _DolPercent1 = DolPercent1;
			ListAmountPercentType _DolPercent2 = DolPercent2;
			ListAmountPercentType _DolPercent3 = DolPercent3;
			ListAmountPercentType _DolPercent4 = DolPercent4;
			ListAmountPercentType _DolPercent5 = DolPercent5;
			PriceBaseCodeType _BaseCode1 = BaseCode1;
			PriceBaseCodeType _BaseCode2 = BaseCode2;
			PriceBaseCodeType _BaseCode3 = BaseCode3;
			PriceBaseCodeType _BaseCode4 = BaseCode4;
			PriceBaseCodeType _BaseCode5 = BaseCode5;
			QtyUnitType _BrkQty1 = BrkQty1;
			QtyUnitType _BrkQty2 = BrkQty2;
			QtyUnitType _BrkQty3 = BrkQty3;
			QtyUnitType _BrkQty4 = BrkQty4;
			QtyUnitType _BrkQty5 = BrkQty5;
			CostPrcType _BrkPrice1 = BrkPrice1;
			CostPrcType _BrkPrice2 = BrkPrice2;
			CostPrcType _BrkPrice3 = BrkPrice3;
			CostPrcType _BrkPrice4 = BrkPrice4;
			CostPrcType _BrkPrice5 = BrkPrice5;
			CostPrcType _DerUnitPrice1 = DerUnitPrice1;
			CostPrcType _DerUnitPrice2 = DerUnitPrice2;
			CostPrcType _DerUnitPrice3 = DerUnitPrice3;
			CostPrcType _DerUnitPrice4 = DerUnitPrice4;
			CostPrcType _DerUnitPrice5 = DerUnitPrice5;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItempricePostQuerySp";
				
				appDB.AddCommandParameter(cmd, "UnitPrice1", _UnitPrice1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice2", _UnitPrice2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice3", _UnitPrice3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice4", _UnitPrice4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice5", _UnitPrice5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice6", _UnitPrice6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurItem", _CurItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurCurrCode", _CurCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurEffectDate", _CurEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DolPercent1", _DolPercent1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DolPercent2", _DolPercent2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DolPercent3", _DolPercent3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DolPercent4", _DolPercent4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DolPercent5", _DolPercent5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseCode1", _BaseCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseCode2", _BaseCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseCode3", _BaseCode3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseCode4", _BaseCode4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseCode5", _BaseCode5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQty1", _BrkQty1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQty2", _BrkQty2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQty3", _BrkQty3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQty4", _BrkQty4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQty5", _BrkQty5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkPrice1", _BrkPrice1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkPrice2", _BrkPrice2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkPrice3", _BrkPrice3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkPrice4", _BrkPrice4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkPrice5", _BrkPrice5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerUnitPrice1", _DerUnitPrice1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerUnitPrice2", _DerUnitPrice2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerUnitPrice3", _DerUnitPrice3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerUnitPrice4", _DerUnitPrice4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerUnitPrice5", _DerUnitPrice5, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DerUnitPrice1 = _DerUnitPrice1;
				DerUnitPrice2 = _DerUnitPrice2;
				DerUnitPrice3 = _DerUnitPrice3;
				DerUnitPrice4 = _DerUnitPrice4;
				DerUnitPrice5 = _DerUnitPrice5;
				
				return (Severity, DerUnitPrice1, DerUnitPrice2, DerUnitPrice3, DerUnitPrice4, DerUnitPrice5);
			}
		}
	}
}
