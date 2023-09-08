//PROJECT NAME: Logistics
//CLASS NAME: PriceCal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPriceCal
	{
		(int? ReturnCode, decimal? PUnitPrice,
		decimal? PQtyList__1,
		decimal? PQtyList__2,
		decimal? PQtyList__3,
		decimal? PQtyList__4,
		decimal? PQtyList__5,
		decimal? PPriceList__1,
		decimal? PPriceList__2,
		decimal? PPriceList__3,
		decimal? PPriceList__4,
		decimal? PPriceList__5,
		string PPriceListType,
		string Infobar,
		byte? NeedToConvertPrice,
		decimal? LineDisc,
		string CustItemUM) PriceCalSp(byte? PShowMatrix,
		string PItem,
		string PCustNum,
		string PCustItem,
		DateTime? PEffDate,
		DateTime? PExpDate,
		decimal? PQtyOrdered,
		string POrderPriceCode,
		string PCurrCode,
		string PConfigString,
		decimal? PRate,
		decimal? PUnitPrice = null,
		decimal? PQtyList__1 = null,
		decimal? PQtyList__2 = null,
		decimal? PQtyList__3 = null,
		decimal? PQtyList__4 = null,
		decimal? PQtyList__5 = null,
		decimal? PPriceList__1 = null,
		decimal? PPriceList__2 = null,
		decimal? PPriceList__3 = null,
		decimal? PPriceList__4 = null,
		decimal? PPriceList__5 = null,
		string PPriceListType = null,
		string Infobar = null,
		string Site = null,
		string PCoNum = null,
		short? PCoLine = null,
		byte? ConvertPrice = (byte)1,
		byte? NeedToConvertPrice = (byte)0,
		string ItemUM = null,
		string ItemWhse = null,
		int? ShipTo = 0,
		decimal? LineDisc = 0,
		string CustItemUM = null,
		string PromotionCode = null,
		string CoNum = null);
	}
	
	public class PriceCal : IPriceCal
	{
		readonly IApplicationDB appDB;
		
		public PriceCal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PUnitPrice,
		decimal? PQtyList__1,
		decimal? PQtyList__2,
		decimal? PQtyList__3,
		decimal? PQtyList__4,
		decimal? PQtyList__5,
		decimal? PPriceList__1,
		decimal? PPriceList__2,
		decimal? PPriceList__3,
		decimal? PPriceList__4,
		decimal? PPriceList__5,
		string PPriceListType,
		string Infobar,
		byte? NeedToConvertPrice,
		decimal? LineDisc,
		string CustItemUM) PriceCalSp(byte? PShowMatrix,
		string PItem,
		string PCustNum,
		string PCustItem,
		DateTime? PEffDate,
		DateTime? PExpDate,
		decimal? PQtyOrdered,
		string POrderPriceCode,
		string PCurrCode,
		string PConfigString,
		decimal? PRate,
		decimal? PUnitPrice = null,
		decimal? PQtyList__1 = null,
		decimal? PQtyList__2 = null,
		decimal? PQtyList__3 = null,
		decimal? PQtyList__4 = null,
		decimal? PQtyList__5 = null,
		decimal? PPriceList__1 = null,
		decimal? PPriceList__2 = null,
		decimal? PPriceList__3 = null,
		decimal? PPriceList__4 = null,
		decimal? PPriceList__5 = null,
		string PPriceListType = null,
		string Infobar = null,
		string Site = null,
		string PCoNum = null,
		short? PCoLine = null,
		byte? ConvertPrice = (byte)1,
		byte? NeedToConvertPrice = (byte)0,
		string ItemUM = null,
		string ItemWhse = null,
		int? ShipTo = 0,
		decimal? LineDisc = 0,
		string CustItemUM = null,
		string PromotionCode = null,
		string CoNum = null)
		{
			Flag _PShowMatrix = PShowMatrix;
			ItemType _PItem = PItem;
			CustNumType _PCustNum = PCustNum;
			ItemType _PCustItem = PCustItem;
			DateType _PEffDate = PEffDate;
			DateType _PExpDate = PExpDate;
			QtyUnitType _PQtyOrdered = PQtyOrdered;
			PriceCodeType _POrderPriceCode = POrderPriceCode;
			CurrCodeType _PCurrCode = PCurrCode;
			FeatStrType _PConfigString = PConfigString;
			ExchRateType _PRate = PRate;
			CostPrcType _PUnitPrice = PUnitPrice;
			QtyUnitType _PQtyList__1 = PQtyList__1;
			QtyUnitType _PQtyList__2 = PQtyList__2;
			QtyUnitType _PQtyList__3 = PQtyList__3;
			QtyUnitType _PQtyList__4 = PQtyList__4;
			QtyUnitType _PQtyList__5 = PQtyList__5;
			CostPrcType _PPriceList__1 = PPriceList__1;
			CostPrcType _PPriceList__2 = PPriceList__2;
			CostPrcType _PPriceList__3 = PPriceList__3;
			CostPrcType _PPriceList__4 = PPriceList__4;
			CostPrcType _PPriceList__5 = PPriceList__5;
			InfobarType _PPriceListType = PPriceListType;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			ListYesNoType _ConvertPrice = ConvertPrice;
			ListYesNoType _NeedToConvertPrice = NeedToConvertPrice;
			UMType _ItemUM = ItemUM;
			WhseType _ItemWhse = ItemWhse;
			CustSeqType _ShipTo = ShipTo;
			LineDiscType _LineDisc = LineDisc;
			UMType _CustItemUM = CustItemUM;
			PromotionCodeType _PromotionCode = PromotionCode;
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PriceCalSp";
				
				appDB.AddCommandParameter(cmd, "PShowMatrix", _PShowMatrix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustItem", _PCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEffDate", _PEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExpDate", _PExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderPriceCode", _POrderPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PConfigString", _PConfigString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRate", _PRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitPrice", _PUnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyList##1", _PQtyList__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyList##2", _PQtyList__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyList##3", _PQtyList__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyList##4", _PQtyList__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyList##5", _PQtyList__5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPriceList##1", _PPriceList__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPriceList##2", _PPriceList__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPriceList##3", _PPriceList__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPriceList##4", _PPriceList__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPriceList##5", _PPriceList__5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPriceListType", _PPriceListType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvertPrice", _ConvertPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NeedToConvertPrice", _NeedToConvertPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemWhse", _ItemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipTo", _ShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineDisc", _LineDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItemUM", _CustItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromotionCode", _PromotionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUnitPrice = _PUnitPrice;
				PQtyList__1 = _PQtyList__1;
				PQtyList__2 = _PQtyList__2;
				PQtyList__3 = _PQtyList__3;
				PQtyList__4 = _PQtyList__4;
				PQtyList__5 = _PQtyList__5;
				PPriceList__1 = _PPriceList__1;
				PPriceList__2 = _PPriceList__2;
				PPriceList__3 = _PPriceList__3;
				PPriceList__4 = _PPriceList__4;
				PPriceList__5 = _PPriceList__5;
				PPriceListType = _PPriceListType;
				Infobar = _Infobar;
				NeedToConvertPrice = _NeedToConvertPrice;
				LineDisc = _LineDisc;
				CustItemUM = _CustItemUM;
				
				return (Severity, PUnitPrice, PQtyList__1, PQtyList__2, PQtyList__3, PQtyList__4, PQtyList__5, PPriceList__1, PPriceList__2, PPriceList__3, PPriceList__4, PPriceList__5, PPriceListType, Infobar, NeedToConvertPrice, LineDisc, CustItemUM);
			}
		}
	}
}
