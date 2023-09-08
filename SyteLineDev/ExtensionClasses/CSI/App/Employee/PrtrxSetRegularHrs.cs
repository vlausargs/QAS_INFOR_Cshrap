//PROJECT NAME: Employee
//CLASS NAME: PrtrxSetRegularHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PrtrxSetRegularHrs : IPrtrxSetRegularHrs
	{
		readonly IApplicationDB appDB;
		
		
		public PrtrxSetRegularHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PrtrxSetRegularHrsSp(string EmpNum,
		int? EmpSeq,
		int? PaySalaryStatus,
		string Infobar)
		{
			EmpNumType _EmpNum = EmpNum;
			PrtrxSeqType _EmpSeq = EmpSeq;
			ListYesNoType _PaySalaryStatus = PaySalaryStatus;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrtrxSetRegularHrsSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpSeq", _EmpSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaySalaryStatus", _PaySalaryStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
