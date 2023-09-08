//PROJECT NAME: CSIEmployee
//CLASS NAME: GetPayrollParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IGetPayrollParms
	{
		(int? ReturnCode, DateTime? CurCheckDate, string BankCode, DateTime? PerStart, DateTime? PerEnd, string PayFreqs, decimal? PrtrxRegHrs, decimal? PrtrxWksWorked) GetPayrollParmsSp(DateTime? CurCheckDate,
		string BankCode = null,
		DateTime? PerStart = null,
		DateTime? PerEnd = null,
		string PayFreqs = null,
		string EmpNum = null,
		decimal? PrtrxRegHrs = null,
		decimal? PrtrxWksWorked = null);
	}
	
	public class GetPayrollParms : IGetPayrollParms
	{
		readonly IApplicationDB appDB;
		
		public GetPayrollParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? CurCheckDate, string BankCode, DateTime? PerStart, DateTime? PerEnd, string PayFreqs, decimal? PrtrxRegHrs, decimal? PrtrxWksWorked) GetPayrollParmsSp(DateTime? CurCheckDate,
		string BankCode = null,
		DateTime? PerStart = null,
		DateTime? PerEnd = null,
		string PayFreqs = null,
		string EmpNum = null,
		decimal? PrtrxRegHrs = null,
		decimal? PrtrxWksWorked = null)
		{
			DateType _CurCheckDate = CurCheckDate;
			BankCodeType _BankCode = BankCode;
			DateType _PerStart = PerStart;
			DateType _PerEnd = PerEnd;
			PrPayFreqsType _PayFreqs = PayFreqs;
			EmpNumType _EmpNum = EmpNum;
			TotalHoursType _PrtrxRegHrs = PrtrxRegHrs;
			WeeksWorkedType _PrtrxWksWorked = PrtrxWksWorked;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPayrollParmsSp";
				
				appDB.AddCommandParameter(cmd, "CurCheckDate", _CurCheckDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayFreqs", _PayFreqs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxRegHrs", _PrtrxRegHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxWksWorked", _PrtrxWksWorked, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurCheckDate = _CurCheckDate;
				BankCode = _BankCode;
				PerStart = _PerStart;
				PerEnd = _PerEnd;
				PayFreqs = _PayFreqs;
				PrtrxRegHrs = _PrtrxRegHrs;
				PrtrxWksWorked = _PrtrxWksWorked;
				
				return (Severity, CurCheckDate, BankCode, PerStart, PerEnd, PayFreqs, PrtrxRegHrs, PrtrxWksWorked);
			}
		}
	}
}
