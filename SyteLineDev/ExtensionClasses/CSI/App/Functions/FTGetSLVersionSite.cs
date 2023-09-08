//PROJECT NAME: Data
//CLASS NAME: FTGetSLVersionSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTGetSLVersionSite : IFTGetSLVersionSite
	{
		readonly IApplicationDB appDB;
		
		public FTGetSLVersionSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Site,
			string SyteLineVersion,
			string Infobar) FTGetSLVersionSiteSp(
			string DefaultConfig,
			string Site,
			string SyteLineVersion,
			string Infobar)
		{
			ConfigurationNameType _DefaultConfig = DefaultConfig;
			SiteType _Site = Site;
			ProductVersionType _SyteLineVersion = SyteLineVersion;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTGetSLVersionSiteSp";
				
				appDB.AddCommandParameter(cmd, "DefaultConfig", _DefaultConfig, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SyteLineVersion", _SyteLineVersion, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Site = _Site;
				SyteLineVersion = _SyteLineVersion;
				Infobar = _Infobar;
				
				return (Severity, Site, SyteLineVersion, Infobar);
			}
		}
	}
}
