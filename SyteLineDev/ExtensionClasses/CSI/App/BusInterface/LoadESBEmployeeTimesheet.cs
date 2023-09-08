//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBEmployeeTimesheet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBEmployeeTimesheet
	{
		int? LoadESBEmployeeTimesheetSp(string DerBODID = null,
		string ActionExpression = null);
	}
	
	public class LoadESBEmployeeTimesheet : ILoadESBEmployeeTimesheet
	{
		readonly IApplicationDB appDB;
		
		public LoadESBEmployeeTimesheet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LoadESBEmployeeTimesheetSp(string DerBODID = null,
		string ActionExpression = null)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBEmployeeTimesheetSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
