//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBMXProcessReceivableTracker.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBMXProcessReceivableTracker : ILoadESBMXProcessReceivableTracker
	{
		readonly IApplicationDB appDB;
		
		public LoadESBMXProcessReceivableTracker(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LoadESBMXProcessReceivableTrackerSp(
			string ActionExpression = null,
			string ProcessArCheckNum = null,
			string UUID = null,
			string Status = null,
			string ErrMessage = null,
			string Filename = null,
			string Infobar = null)
		{
			StringType _ActionExpression = ActionExpression;
			StringType _ProcessArCheckNum = ProcessArCheckNum;
			StringType _UUID = UUID;
			StringType _Status = Status;
			MessageType _ErrMessage = ErrMessage;
			StringType _Filename = Filename;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBMXProcessReceivableTrackerSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessArCheckNum", _ProcessArCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UUID", _UUID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrMessage", _ErrMessage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Filename", _Filename, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
