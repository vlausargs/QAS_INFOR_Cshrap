//PROJECT NAME: Data
//CLASS NAME: GetPPItemPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPPItemPrice : IGetPPItemPrice
	{
		readonly IApplicationDB appDB;
		
		public GetPPItemPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ItemPrice,
			string Infobar) GetPPItemPriceSp(
			string MaterialSource,
			string CustNum,
			string Item,
			string ItemUM,
			decimal? ItemQty,
			string CurrCode,
			decimal? ItemPrice,
			string Infobar)
		{
			PP_MatlPaperSourceType _MaterialSource = MaterialSource;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			UMType _ItemUM = ItemUM;
			QtyUnitType _ItemQty = ItemQty;
			CurrCodeType _CurrCode = CurrCode;
			CostPrcType _ItemPrice = ItemPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPPItemPriceSp";
				
				appDB.AddCommandParameter(cmd, "MaterialSource", _MaterialSource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemQty", _ItemQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPrice", _ItemPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemPrice = _ItemPrice;
				Infobar = _Infobar;
				
				return (Severity, ItemPrice, Infobar);
			}
		}
	}
}
