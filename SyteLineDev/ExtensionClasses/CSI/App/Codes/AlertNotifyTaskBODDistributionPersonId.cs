//PROJECT NAME: Codes
//CLASS NAME: AlertNotifyTaskBODDistributionPersonId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class AlertNotifyTaskBODDistributionPersonId : IAlertNotifyTaskBODDistributionPersonId
	{
		readonly IApplicationDB appDB;
		
		
		public AlertNotifyTaskBODDistributionPersonId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DistributionPersonId) AlertNotifyTaskBODDistributionPersonIdSp(string Username,
		string DistributionPersonId)
		{
			UsernameType _Username = Username;
			MediumDescType _DistributionPersonId = DistributionPersonId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AlertNotifyTaskBODDistributionPersonIdSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistributionPersonId", _DistributionPersonId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DistributionPersonId = _DistributionPersonId;
				
				return (Severity, DistributionPersonId);
			}
		}
	}
}
