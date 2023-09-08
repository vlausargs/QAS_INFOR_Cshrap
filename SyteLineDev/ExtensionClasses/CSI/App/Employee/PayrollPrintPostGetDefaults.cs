//PROJECT NAME: CSIEmployee
//CLASS NAME: PayrollPrintPostGetDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPayrollPrintPostGetDefaults
	{
		(int? ReturnCode, string rBankCode, DateTime? rCurCheckD) PayrollPrintPostGetDefaultsSp(string rBankCode = null,
		DateTime? rCurCheckD = null);
	}
	
	public class PayrollPrintPostGetDefaults : IPayrollPrintPostGetDefaults
	{
		readonly IApplicationDB appDB;
		
		public PayrollPrintPostGetDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rBankCode, DateTime? rCurCheckD) PayrollPrintPostGetDefaultsSp(string rBankCode = null,
		DateTime? rCurCheckD = null)
		{
			BankCodeType _rBankCode = rBankCode;
			DateType _rCurCheckD = rCurCheckD;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PayrollPrintPostGetDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "rBankCode", _rBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rCurCheckD", _rCurCheckD, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rBankCode = _rBankCode;
				rCurCheckD = _rCurCheckD;
				
				return (Severity, rBankCode, rCurCheckD);
			}
		}
	}
}
