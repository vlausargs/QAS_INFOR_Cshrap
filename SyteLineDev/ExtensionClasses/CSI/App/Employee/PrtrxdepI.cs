//PROJECT NAME: Employee
//CLASS NAME: PrtrxdepI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPrtrxdepI
	{
		(int? ReturnCode, decimal? PrtrxNetPay,
		decimal? PrtrxDepAmt,
		byte? SchedDirDepExceedNetPay) PrtrxdepISp(string EmpPrbankEmpNum,
		short? PrtrxDepDtlSeq,
		byte? EmployeeDirDep,
		string PrtrxType,
		int? PrtrxCheckNum,
		byte? Void,
		byte? CreateDepDtl,
		DateTime? CheckDate,
		string BankCode,
		string CalledFromForm,
		decimal? PrtrxNetPay,
		decimal? PrtrxDepAmt,
		byte? SchedDirDepExceedNetPay);
	}
	
	public class PrtrxdepI : IPrtrxdepI
	{
		readonly IApplicationDB appDB;
		
		public PrtrxdepI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PrtrxNetPay,
		decimal? PrtrxDepAmt,
		byte? SchedDirDepExceedNetPay) PrtrxdepISp(string EmpPrbankEmpNum,
		short? PrtrxDepDtlSeq,
		byte? EmployeeDirDep,
		string PrtrxType,
		int? PrtrxCheckNum,
		byte? Void,
		byte? CreateDepDtl,
		DateTime? CheckDate,
		string BankCode,
		string CalledFromForm,
		decimal? PrtrxNetPay,
		decimal? PrtrxDepAmt,
		byte? SchedDirDepExceedNetPay)
		{
			EmpNumType _EmpPrbankEmpNum = EmpPrbankEmpNum;
			PrtrxSeqType _PrtrxDepDtlSeq = PrtrxDepDtlSeq;
			ListYesNoType _EmployeeDirDep = EmployeeDirDep;
			PrtrxTypeType _PrtrxType = PrtrxType;
			PrCheckNumType _PrtrxCheckNum = PrtrxCheckNum;
			ListYesNoType _Void = Void;
			ListYesNoType _CreateDepDtl = CreateDepDtl;
			DateType _CheckDate = CheckDate;
			BankCodeType _BankCode = BankCode;
			StringType _CalledFromForm = CalledFromForm;
			RetireAmountType _PrtrxNetPay = PrtrxNetPay;
			RetireAmountType _PrtrxDepAmt = PrtrxDepAmt;
			ListYesNoType _SchedDirDepExceedNetPay = SchedDirDepExceedNetPay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrtrxdepISp";
				
				appDB.AddCommandParameter(cmd, "EmpPrbankEmpNum", _EmpPrbankEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDepDtlSeq", _PrtrxDepDtlSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeDirDep", _EmployeeDirDep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxType", _PrtrxType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxCheckNum", _PrtrxCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Void", _Void, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateDepDtl", _CreateDepDtl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromForm", _CalledFromForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxNetPay", _PrtrxNetPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDepAmt", _PrtrxDepAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SchedDirDepExceedNetPay", _SchedDirDepExceedNetPay, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrtrxNetPay = _PrtrxNetPay;
				PrtrxDepAmt = _PrtrxDepAmt;
				SchedDirDepExceedNetPay = _SchedDirDepExceedNetPay;
				
				return (Severity, PrtrxNetPay, PrtrxDepAmt, SchedDirDepExceedNetPay);
			}
		}
	}
}
