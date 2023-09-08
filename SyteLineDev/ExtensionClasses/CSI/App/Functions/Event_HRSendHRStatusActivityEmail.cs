//PROJECT NAME: Data
//CLASS NAME: Event_HRSendHRStatusActivityEmail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Event_HRSendHRStatusActivityEmail : IEvent_HRSendHRStatusActivityEmail
	{
		readonly IApplicationDB appDB;
		
		public Event_HRSendHRStatusActivityEmail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Event_HRSendHRStatusActivityEmailSp(
			string EmpNum,
			string EmpName,
			int? IsNew,
			string PrevHRStatus = null,
			string HRStatus = null,
			string Infobar = null)
		{
			EmpNumType _EmpNum = EmpNum;
			EmpNameType _EmpName = EmpName;
			ListYesNoType _IsNew = IsNew;
			ExternalHRStatusType _PrevHRStatus = PrevHRStatus;
			ExternalHRStatusType _HRStatus = HRStatus;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Event_HRSendHRStatusActivityEmail";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpName", _EmpName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsNew", _IsNew, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrevHRStatus", _PrevHRStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HRStatus", _HRStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
