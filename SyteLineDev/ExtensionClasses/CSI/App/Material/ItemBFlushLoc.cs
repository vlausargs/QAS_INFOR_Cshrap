//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemBFlushLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemBFlushLoc
	{
		(int? ReturnCode, string Infobar) ItemBFlushLocSp(string Item,
		string Loc,
		string Infobar,
		string PSite = null);
	}
	
	public class ItemBFlushLoc : IItemBFlushLoc
	{
		readonly IApplicationDB appDB;
		
		public ItemBFlushLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemBFlushLocSp(string Item,
		string Loc,
		string Infobar,
		string PSite = null)
		{
			ItemType _Item = Item;
			LocType _Loc = Loc;
			InfobarType _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemBFlushLocSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
