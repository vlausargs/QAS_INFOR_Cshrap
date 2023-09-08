//PROJECT NAME: Codes
//CLASS NAME: PortalCSICompatabilityCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class PortalCSICompatabilityCheck : IPortalCSICompatabilityCheck
	{
		readonly IApplicationDB appDB;
		
		
		public PortalCSICompatabilityCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ConfigIsValid,
		string ReturnMessage) PortalCSICompatabilityCheckSp(string ExpectedCSIVersion,
		string RequiredAPARs,
		int? ConfigIsValid = 0,
		string ReturnMessage = null)
		{
			ProductVersionType _ExpectedCSIVersion = ExpectedCSIVersion;
			StringType _RequiredAPARs = RequiredAPARs;
			ListYesNoType _ConfigIsValid = ConfigIsValid;
			InfobarType _ReturnMessage = ReturnMessage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalCSICompatabilityCheckSp";
				
				appDB.AddCommandParameter(cmd, "ExpectedCSIVersion", _ExpectedCSIVersion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequiredAPARs", _RequiredAPARs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigIsValid", _ConfigIsValid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReturnMessage", _ReturnMessage, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ConfigIsValid = _ConfigIsValid;
				ReturnMessage = _ReturnMessage;
				
				return (Severity, ConfigIsValid, ReturnMessage);
			}
		}
	}
}
