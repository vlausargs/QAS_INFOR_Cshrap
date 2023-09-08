//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBEmployeeTimeSheetDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBEmployeeTimeSheetDetail : ILoadESBEmployeeTimeSheetDetail
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBEmployeeTimeSheetDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadESBEmployeeTimeSheetDetailSp(string DerBODID,
		string ActionExpression,
		string EmployeeID,
		DateTime? TransactionDate,
		string ReferenceID,
		string Prefix,
		string Duration,
		string Status,
		string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			StringType _EmployeeID = EmployeeID;
			DateType _TransactionDate = TransactionDate;
			StringType _ReferenceID = ReferenceID;
			StringType _Prefix = Prefix;
			StringType _Duration = Duration;
			StringType _Status = Status;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBEmployeeTimeSheetDetailSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeID", _EmployeeID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionDate", _TransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceID", _ReferenceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Duration", _Duration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
