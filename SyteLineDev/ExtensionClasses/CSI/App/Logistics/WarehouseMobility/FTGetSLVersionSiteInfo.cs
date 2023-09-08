//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTGetSLVersionSiteInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTGetSLVersionSiteInfo
	{
		int FTGetSLVersionSiteInfoSp(string DefaultConfig,
		                             ref string Site,
		                             ref string SyteLineVersion);
	}
	
	public class FTGetSLVersionSiteInfo : IFTGetSLVersionSiteInfo
	{
		readonly IApplicationDB appDB;
		
		public FTGetSLVersionSiteInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTGetSLVersionSiteInfoSp(string DefaultConfig,
		                                    ref string Site,
		                                    ref string SyteLineVersion)
		{
			ConfigurationNameType _DefaultConfig = DefaultConfig;
			SiteType _Site = Site;
			ProductVersionType _SyteLineVersion = SyteLineVersion;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTGetSLVersionSiteInfoSp";
				
				appDB.AddCommandParameter(cmd, "DefaultConfig", _DefaultConfig, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SyteLineVersion", _SyteLineVersion, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Site = _Site;
				SyteLineVersion = _SyteLineVersion;
				
				return Severity;
			}
		}
	}
}
