//PROJECT NAME: Logistics
//CLASS NAME: PromotionCodeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPromotionCodeValid
	{
		(int? ReturnCode, string Infobar) PromotionCodeValidSp(string CoNum,
		string Whse,
		string Item,
		DateTime? CoOrderDate,
		string PromotionCode,
		string ItemUM,
		string CustItem,
		string ShipSite,
		decimal? InQtyConv,
		string CurrCode,
		string ItemPriceCode,
		decimal? PriceConv,
		short? CoLine,
		string ItemWhse,
		string Infobar,
		string Slsman = null,
		string CustNum = null,
		int? CustSeq = null,
		string EndUserType = null);
	}
	
	public class PromotionCodeValid : IPromotionCodeValid
	{
		readonly IApplicationDB appDB;
		
		public PromotionCodeValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PromotionCodeValidSp(string CoNum,
		string Whse,
		string Item,
		DateTime? CoOrderDate,
		string PromotionCode,
		string ItemUM,
		string CustItem,
		string ShipSite,
		decimal? InQtyConv,
		string CurrCode,
		string ItemPriceCode,
		decimal? PriceConv,
		short? CoLine,
		string ItemWhse,
		string Infobar,
		string Slsman = null,
		string CustNum = null,
		int? CustSeq = null,
		string EndUserType = null)
		{
			CoNumType _CoNum = CoNum;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			DateType _CoOrderDate = CoOrderDate;
			PromotionCodeType _PromotionCode = PromotionCode;
			UMType _ItemUM = ItemUM;
			ItemType _CustItem = CustItem;
			SiteType _ShipSite = ShipSite;
			QtyUnitType _InQtyConv = InQtyConv;
			CurrCodeType _CurrCode = CurrCode;
			PriceCodeType _ItemPriceCode = ItemPriceCode;
			AmountType _PriceConv = PriceConv;
			CoLineType _CoLine = CoLine;
			WhseType _ItemWhse = ItemWhse;
			InfobarType _Infobar = Infobar;
			SlsmanType _Slsman = Slsman;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			EndUserTypeType _EndUserType = EndUserType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PromotionCodeValidSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrderDate", _CoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromotionCode", _PromotionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InQtyConv", _InQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceCode", _ItemPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemWhse", _ItemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
