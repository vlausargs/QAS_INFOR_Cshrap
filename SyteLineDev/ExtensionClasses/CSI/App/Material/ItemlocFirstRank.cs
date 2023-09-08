//PROJECT NAME: Material
//CLASS NAME: ItemlocFirstRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemlocFirstRank : IItemlocFirstRank
	{
		readonly IApplicationDB appDB;
		
		
		public ItemlocFirstRank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Loc) ItemlocFirstRankSp(string Item,
		string Whse,
		string Site = null,
		string Loc = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			SiteType _Site = Site;
			LocType _Loc = Loc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemlocFirstRankSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Loc = _Loc;
				
				return (Severity, Loc);
			}
		}
	}
}
