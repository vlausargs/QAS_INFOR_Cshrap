//PROJECT NAME: Codes
//CLASS NAME: CountTasksAndMessages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CountTasksAndMessages : ICountTasksAndMessages
	{
		readonly IApplicationDB appDB;
		
		
		public CountTasksAndMessages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NumberOfUserTasks,
		int? NumberOfEventMessages) CountTasksAndMessagesSp(int? NumberOfUserTasks,
		int? NumberOfEventMessages)
		{
			NumberOfLinesType _NumberOfUserTasks = NumberOfUserTasks;
			NumberOfLinesType _NumberOfEventMessages = NumberOfEventMessages;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CountTasksAndMessagesSp";
				
				appDB.AddCommandParameter(cmd, "NumberOfUserTasks", _NumberOfUserTasks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfEventMessages", _NumberOfEventMessages, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NumberOfUserTasks = _NumberOfUserTasks;
				NumberOfEventMessages = _NumberOfEventMessages;
				
				return (Severity, NumberOfUserTasks, NumberOfEventMessages);
			}
		}
	}
}
