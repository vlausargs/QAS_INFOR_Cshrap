//PROJECT NAME: Config
//CLASS NAME: SetAvailCfg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class SetAvailCfg : ISetAvailCfg
	{
		readonly IApplicationDB appDB;
		
		
		public SetAvailCfg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? AvailCfg) SetAvailCfgSp(int? AvailCfg,
		string PSite = null)
		{
			FlagNyType _AvailCfg = AvailCfg;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetAvailCfgSp";
				
				appDB.AddCommandParameter(cmd, "AvailCfg", _AvailCfg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AvailCfg = _AvailCfg;
				
				return (Severity, AvailCfg);
			}
		}
	}
}
