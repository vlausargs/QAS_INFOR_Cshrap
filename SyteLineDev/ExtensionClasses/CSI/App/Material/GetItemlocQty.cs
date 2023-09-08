//PROJECT NAME: CSIMaterial
//CLASS NAME: GetItemlocQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetItemlocQty
	{
		int GetItemlocQtySp(string Site,
		                    string Whse,
		                    string Item,
		                    string Loc,
		                    ref decimal? QtyOnHand);
	}
	
	public class GetItemlocQty : IGetItemlocQty
	{
		readonly IApplicationDB appDB;
		
		public GetItemlocQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetItemlocQtySp(string Site,
		                           string Whse,
		                           string Item,
		                           string Loc,
		                           ref decimal? QtyOnHand)
		{
			SiteType _Site = Site;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			QtyUnitType _QtyOnHand = QtyOnHand;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemlocQtySp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOnHand = _QtyOnHand;
				
				return Severity;
			}
		}
	}
}
