//PROJECT NAME: Logistics
//CLASS NAME: GetItemPriceAndCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetItemPriceAndCost : IGetItemPriceAndCost
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemPriceAndCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PUnitPrice,
		decimal? PUnitCost,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		string Infobar,
		decimal? LineDisc) GetItemPriceAndCostSp(string PItem,
		string PCustNum,
		string PUM,
		string PCurrCode,
		decimal? PRate,
		int? PReprice,
		decimal? PQtyOrdered,
		DateTime? POrderDate,
		string PPriceCode,
		string PFeatStr,
		decimal? PUnitPrice,
		decimal? PUnitCost,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		string Infobar,
		string PCoNum,
		int? PCoLine,
		string PCustItem,
		decimal? LineDisc = 0)
		{
			ItemType _PItem = PItem;
			CustNumType _PCustNum = PCustNum;
			UMType _PUM = PUM;
			CurrCodeType _PCurrCode = PCurrCode;
			ExchRateType _PRate = PRate;
			Flag _PReprice = PReprice;
			QtyUnitType _PQtyOrdered = PQtyOrdered;
			DateType _POrderDate = POrderDate;
			PriceCodeType _PPriceCode = PPriceCode;
			FeatStrType _PFeatStr = PFeatStr;
			CostPrcType _PUnitPrice = PUnitPrice;
			CostPrcType _PUnitCost = PUnitCost;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _POutCost = POutCost;
			Infobar _Infobar = Infobar;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CustItemType _PCustItem = PCustItem;
			LineDiscType _LineDisc = LineDisc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemPriceAndCostSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRate", _PRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReprice", _PReprice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderDate", _POrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPriceCode", _PPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFeatStr", _PFeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitPrice", _PUnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitCost", _PUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustItem", _PCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineDisc", _LineDisc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUnitPrice = _PUnitPrice;
				PUnitCost = _PUnitCost;
				PMatlCost = _PMatlCost;
				PLbrCost = _PLbrCost;
				PFovhdCost = _PFovhdCost;
				PVovhdCost = _PVovhdCost;
				POutCost = _POutCost;
				Infobar = _Infobar;
				LineDisc = _LineDisc;
				
				return (Severity, PUnitPrice, PUnitCost, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, Infobar, LineDisc);
			}
		}
	}
}
