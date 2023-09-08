//PROJECT NAME: Material
//CLASS NAME: GetTransitItemLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetTransitItemLoc : IGetTransitItemLoc
	{
		readonly IApplicationDB appDB;
		
		
		public GetTransitItemLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TrnLoc,
		string Infobar) GetTransitItemLocSp(string Item,
		string Whse,
		int? BlankOk,
		string TrnLoc,
		string Infobar,
		string Site = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			Flag _BlankOk = BlankOk;
			LocType _TrnLoc = TrnLoc;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTransitItemLocSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlankOk", _BlankOk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TrnLoc = _TrnLoc;
				Infobar = _Infobar;
				
				return (Severity, TrnLoc, Infobar);
			}
		}
	}
}
