//PROJECT NAME: Material
//CLASS NAME: CheckWhsePhyInvFlg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CheckWhsePhyInvFlg : ICheckWhsePhyInvFlg
	{
		readonly IApplicationDB appDB;
		
		
		public CheckWhsePhyInvFlg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? WhsePhyInvFlg,
		string Infobar) CheckWhsePhyInvFlgSp(string Whse,
		string Site,
		int? WhsePhyInvFlg = 0,
		string Infobar = null)
		{
			TrnNumType _Whse = Whse;
			SiteType _Site = Site;
			ListYesNoType _WhsePhyInvFlg = WhsePhyInvFlg;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckWhsePhyInvFlgSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhsePhyInvFlg", _WhsePhyInvFlg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WhsePhyInvFlg = _WhsePhyInvFlg;
				Infobar = _Infobar;
				
				return (Severity, WhsePhyInvFlg, Infobar);
			}
		}
	}
}
