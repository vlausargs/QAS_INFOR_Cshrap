//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBProductionOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBProductionOrder : ILoadESBProductionOrder
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBProductionOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Job,
		int? Suffix,
		string Infobar) LoadESBProductionOrderSp(string DerBODID,
		string ActionExpression,
		string Description,
		DateTime? CreateDate,
		DateTime? DueDateTime,
		DateTime? EarliestStartDateTime,
		DateTime? RecordDate,
		string Rework,
		string Status,
		string Job,
		int? Suffix,
		string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			DescriptionType _Description = Description;
			DateTimeType _CreateDate = CreateDate;
			DateTimeType _DueDateTime = DueDateTime;
			DateTimeType _EarliestStartDateTime = EarliestStartDateTime;
			DateTimeType _RecordDate = RecordDate;
			LongListType _Rework = Rework;
			LongListType _Status = Status;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBProductionOrderSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateDate", _CreateDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateTime", _DueDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EarliestStartDateTime", _EarliestStartDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rework", _Rework, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				Suffix = _Suffix;
				Infobar = _Infobar;
				
				return (Severity, Job, Suffix, Infobar);
			}
		}
	}
}
