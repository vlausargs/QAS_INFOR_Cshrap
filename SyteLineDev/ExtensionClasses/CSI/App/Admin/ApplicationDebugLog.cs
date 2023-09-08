//PROJECT NAME: Admin
//CLASS NAME: ApplicationDebugLog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class ApplicationDebugLog : IApplicationDebugLog
	{
		IApplicationDB appDB;
		
		
		public ApplicationDebugLog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ApplicationDebugLogSp(string SourceType = "",
		string SourceName = "",
		string MessageName = "",
		string MessageDetail = "",
		int? ProcID = 0,
		int? PurgeData = 0,
		string Infobar = "")
		{
			ApplicationDebugLogSourceTypeType _SourceType = SourceType;
			ObjectNameType _SourceName = SourceName;
			NameType _MessageName = MessageName;
			NoteType _MessageDetail = MessageDetail;
			IntType _ProcID = ProcID;
			ListYesNoType _PurgeData = PurgeData;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApplicationDebugLogSp";
				
				appDB.AddCommandParameter(cmd, "SourceType", _SourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceName", _SourceName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageName", _MessageName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageDetail", _MessageDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcID", _ProcID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurgeData", _PurgeData, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
