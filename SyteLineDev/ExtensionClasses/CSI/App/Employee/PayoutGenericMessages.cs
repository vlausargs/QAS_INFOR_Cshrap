//PROJECT NAME: Employee
//CLASS NAME: PayoutGenericMessages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PayoutGenericMessages : IPayoutGenericMessages
	{
		readonly IApplicationDB appDB;
		
		
		public PayoutGenericMessages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PayoutGenericMessagesSp(string StartingDept,
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
				cmd.CommandText = "PayoutGenericMessagesSp";
				
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
