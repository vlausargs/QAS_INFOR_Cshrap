//PROJECT NAME: CSIMaterial
//CLASS NAME: DisableEnableTaxFreeMatlForMultiSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IDisableEnableTaxFreeMatlForMultiSite
	{
		(int? ReturnCode, byte? DisableEnable) DisableEnableTaxFreeMatlForMultiSiteSp(string PSite = null,
		byte? DisableEnable = null);
	}
	
	public class DisableEnableTaxFreeMatlForMultiSite : IDisableEnableTaxFreeMatlForMultiSite
	{
		readonly IApplicationDB appDB;
		
		public DisableEnableTaxFreeMatlForMultiSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? DisableEnable) DisableEnableTaxFreeMatlForMultiSiteSp(string PSite = null,
		byte? DisableEnable = null)
		{
			SiteType _PSite = PSite;
			ListYesNoType _DisableEnable = DisableEnable;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DisableEnableTaxFreeMatlForMultiSiteSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisableEnable", _DisableEnable, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DisableEnable = _DisableEnable;
				
				return (Severity, DisableEnable);
			}
		}
	}
}
