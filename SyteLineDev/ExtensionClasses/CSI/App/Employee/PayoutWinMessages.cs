//PROJECT NAME: Employee
//CLASS NAME: PayoutWinMessages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PayoutWinMessages : IPayoutWinMessages
	{
		readonly IApplicationDB appDB;
		
		
		public PayoutWinMessages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PayoutWinMessagesSp(string StartingDept,
		string EndingDept,
		string StartingEmpNum,
		string EndingEmpNum,
		string Infobar)
		{
			DeptType _StartingDept = StartingDept;
			DeptType _EndingDept = EndingDept;
			EmpNumType _StartingEmpNum = StartingEmpNum;
			EmpNumType _EndingEmpNum = EndingEmpNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PayoutWinMessagesSp";
				
				appDB.AddCommandParameter(cmd, "StartingDept", _StartingDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDept", _EndingDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingEmpNum", _StartingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingEmpNum", _EndingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
