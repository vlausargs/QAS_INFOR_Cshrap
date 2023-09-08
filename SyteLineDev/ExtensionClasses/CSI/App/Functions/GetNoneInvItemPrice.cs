//PROJECT NAME: Data
//CLASS NAME: GetNoneInvItemPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetNoneInvItemPrice : IGetNoneInvItemPrice
	{
		readonly IApplicationDB appDB;
		
		public GetNoneInvItemPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ItemPrice,
			string Infobar) GetNoneInvItemPriceSp(
			string Item,
			string ItemUM,
			decimal? ItemQty,
			decimal? ItemPrice,
			string Infobar)
		{
			ItemType _Item = Item;
			UMType _ItemUM = ItemUM;
			QtyUnitType _ItemQty = ItemQty;
			CostPrcType _ItemPrice = ItemPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNoneInvItemPriceSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemQty", _ItemQty, ParameterDirection.Input);
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
