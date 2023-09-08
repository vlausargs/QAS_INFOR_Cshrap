//PROJECT NAME: Production
//CLASS NAME: PP_GetItemInfoAndPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_GetItemInfoAndPrice : IPP_GetItemInfoAndPrice
	{
		readonly IApplicationDB appDB;
		
		
		public PP_GetItemInfoAndPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ItemItem,
		string ItemUM,
		decimal? ItemLengthLinearDimension,
		decimal? ItemWidthLinearDimension,
		decimal? ItemHeightLinearDimension,
		string ItemLinearDimensionUM,
		decimal? ItemWeight,
		string ItemWeightUM,
		decimal? ItemPrice) PP_GetItemInfoAndPriceSp(string Item,
		string CustNum,
		decimal? ItemQtyOrdered,
		string MaterialSource,
		string PaperSource,
		string ItemItem,
		string ItemUM,
		decimal? ItemLengthLinearDimension,
		decimal? ItemWidthLinearDimension,
		decimal? ItemHeightLinearDimension,
		string ItemLinearDimensionUM,
		decimal? ItemWeight,
		string ItemWeightUM,
		decimal? ItemPrice)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			QtyUnitType _ItemQtyOrdered = ItemQtyOrdered;
			PP_MatlPaperSourceType _MaterialSource = MaterialSource;
			PP_MatlPaperSourceType _PaperSource = PaperSource;
			ItemType _ItemItem = ItemItem;
			UMType _ItemUM = ItemUM;
			PP_OperationDimensionType _ItemLengthLinearDimension = ItemLengthLinearDimension;
			PP_OperationDimensionType _ItemWidthLinearDimension = ItemWidthLinearDimension;
			PP_OperationDimensionType _ItemHeightLinearDimension = ItemHeightLinearDimension;
			UMType _ItemLinearDimensionUM = ItemLinearDimensionUM;
			AmountType _ItemWeight = ItemWeight;
			UMType _ItemWeightUM = ItemWeightUM;
			CostPrcType _ItemPrice = ItemPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_GetItemInfoAndPriceSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemQtyOrdered", _ItemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialSource", _MaterialSource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaperSource", _PaperSource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLengthLinearDimension", _ItemLengthLinearDimension, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemWidthLinearDimension", _ItemWidthLinearDimension, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemHeightLinearDimension", _ItemHeightLinearDimension, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLinearDimensionUM", _ItemLinearDimensionUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemWeight", _ItemWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemWeightUM", _ItemWeightUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemPrice", _ItemPrice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemItem = _ItemItem;
				ItemUM = _ItemUM;
				ItemLengthLinearDimension = _ItemLengthLinearDimension;
				ItemWidthLinearDimension = _ItemWidthLinearDimension;
				ItemHeightLinearDimension = _ItemHeightLinearDimension;
				ItemLinearDimensionUM = _ItemLinearDimensionUM;
				ItemWeight = _ItemWeight;
				ItemWeightUM = _ItemWeightUM;
				ItemPrice = _ItemPrice;
				
				return (Severity, ItemItem, ItemUM, ItemLengthLinearDimension, ItemWidthLinearDimension, ItemHeightLinearDimension, ItemLinearDimensionUM, ItemWeight, ItemWeightUM, ItemPrice);
			}
		}
	}
}
