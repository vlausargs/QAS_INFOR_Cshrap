//PROJECT NAME: Data
//CLASS NAME: AutoSyncCoFromPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class AutoSyncCoFromPo : IAutoSyncCoFromPo
	{
		readonly IApplicationDB appDB;
		
		public AutoSyncCoFromPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AutoSyncCoFromPoSp(
			string SourceSite,
			string DemandingSite,
			string DemandingPO,
			string Infobar)
		{
			SiteType _SourceSite = SourceSite;
			SiteType _DemandingSite = DemandingSite;
			PoNumType _DemandingPO = DemandingPO;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AutoSyncCoFromPoSp";
				
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandingSite", _DemandingSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandingPO", _DemandingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
