//PROJECT NAME: Logistics
//CLASS NAME: CoitmConvertUnitPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitmConvertUnitPrice : ICoitmConvertUnitPrice
	{
		readonly IApplicationDB appDB;
		
		public CoitmConvertUnitPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PriceConv,
			decimal? Price,
			string Infobar) CoitmConvertUnitPriceSp(
			string ItemUM,
			string Item,
			string CustNum,
			string CurrCode,
			string ConvertTo,
			string Site = null,
			decimal? PriceConv = null,
			decimal? Price = null,
			string Infobar = null)
		{
			UMType _ItemUM = ItemUM;
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			CurrCodeType _CurrCode = CurrCode;
			LongListType _ConvertTo = ConvertTo;
			SiteType _Site = Site;
			CostPrcType _PriceConv = PriceConv;
			CostPrcType _Price = Price;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitmConvertUnitPriceSp";
				
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvertTo", _ConvertTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriceConv = _PriceConv;
				Price = _Price;
				Infobar = _Infobar;
				
				return (Severity, PriceConv, Price, Infobar);
			}
		}
	}
}
