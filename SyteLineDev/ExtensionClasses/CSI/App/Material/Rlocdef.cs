//PROJECT NAME: Material
//CLASS NAME: Rlocdef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Rlocdef : IRlocdef
	{
		readonly IApplicationDB appDB;
		
		
		public Rlocdef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Loc,
		string Infobar) RlocdefSp(string Site = null,
		string Whse = null,
		string Item = null,
		string Loc = null,
		string Infobar = null)
		{
			SiteType _Site = Site;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RlocdefSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Loc = _Loc;
				Infobar = _Infobar;
				
				return (Severity, Loc, Infobar);
			}
		}
	}
}
