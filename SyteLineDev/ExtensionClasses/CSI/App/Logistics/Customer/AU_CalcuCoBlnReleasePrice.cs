//PROJECT NAME: Logistics
//CLASS NAME: AU_CalcuCoBlnReleasePrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AU_CalcuCoBlnReleasePrice : IAU_CalcuCoBlnReleasePrice
	{
		readonly IApplicationDB appDB;
		
		public AU_CalcuCoBlnReleasePrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AU_CalcuCoBlnReleasePriceSp(
			string CoNum,
			string CustNum,
			string Item,
			string ItemUM,
			string CustItem,
			string ShipSite,
			string CurrCode,
			string ItemPriceCode,
			decimal? PriceConv,
			DateTime? OrderDate,
			string Infobar,
			int? CoLine,
			string ItemWhse = null)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			UMType _ItemUM = ItemUM;
			ItemType _CustItem = CustItem;
			SiteType _ShipSite = ShipSite;
			CurrCodeType _CurrCode = CurrCode;
			PriceCodeType _ItemPriceCode = ItemPriceCode;
			AmountType _PriceConv = PriceConv;
			DateType _OrderDate = OrderDate;
			Infobar _Infobar = Infobar;
			CoLineType _CoLine = CoLine;
			WhseType _ItemWhse = ItemWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_CalcuCoBlnReleasePriceSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceCode", _ItemPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemWhse", _ItemWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
