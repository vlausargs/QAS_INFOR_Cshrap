//PROJECT NAME: Data
//CLASS NAME: SSSHas.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SSSHas : ISSSHas
	{
		readonly IApplicationDB appDB;
		
		public SSSHas(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Enabled,
			string Infobar) SSSHasSp(
			string FeatureType = null,
			int? Enabled = 0,
			string Infobar = null)
		{
			StringType _FeatureType = FeatureType;
			ListYesNoType _Enabled = Enabled;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSHasSp";
				
				appDB.AddCommandParameter(cmd, "FeatureType", _FeatureType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Enabled", _Enabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Enabled = _Enabled;
				Infobar = _Infobar;
				
				return (Severity, Enabled, Infobar);
			}
		}
	}
}
