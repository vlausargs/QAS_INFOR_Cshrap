//PROJECT NAME: CSIAdmin
//CLASS NAME: GetPortalAdminStats.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface IGetPortalAdminStats
	{
		(int? ReturnCode, int? FailedEvents, int? PendingApproval, int? ExpiredMessages) GetPortalAdminStatsSp(DateTime? BeginDate = null,
		DateTime? EndDate = null,
		string AppName = null,
		int? FailedEvents = null,
		int? PendingApproval = null,
		int? ExpiredMessages = null);
	}
	
	public class GetPortalAdminStats : IGetPortalAdminStats
	{
		IApplicationDB appDB;
		
		public GetPortalAdminStats(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? FailedEvents, int? PendingApproval, int? ExpiredMessages) GetPortalAdminStatsSp(DateTime? BeginDate = null,
		DateTime? EndDate = null,
		string AppName = null,
		int? FailedEvents = null,
		int? PendingApproval = null,
		int? ExpiredMessages = null)
		{
			DateType _BeginDate = BeginDate;
			DateType _EndDate = EndDate;
			ApplicationNameType _AppName = AppName;
			IntType _FailedEvents = FailedEvents;
			IntType _PendingApproval = PendingApproval;
			IntType _ExpiredMessages = ExpiredMessages;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPortalAdminStatsSp";
				
				appDB.AddCommandParameter(cmd, "BeginDate", _BeginDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppName", _AppName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FailedEvents", _FailedEvents, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PendingApproval", _PendingApproval, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExpiredMessages", _ExpiredMessages, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FailedEvents = _FailedEvents;
				PendingApproval = _PendingApproval;
				ExpiredMessages = _ExpiredMessages;
				
				return (Severity, FailedEvents, PendingApproval, ExpiredMessages);
			}
		}
	}
}
