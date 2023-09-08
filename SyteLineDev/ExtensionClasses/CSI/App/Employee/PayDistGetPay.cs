//PROJECT NAME: CSIEmployee
//CLASS NAME: PayDistGetPay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPayDistGetPay
	{
		(int? ReturnCode, string rEmpNum, short? rSeq, string rEmpName, string rEmpPayFreq, decimal? rEmpSalary, string rEmpType, string rEmpWcClass, string rPrtrxBankCode, string rPrtrxDept, decimal? rPrtrxDtHrs, decimal? rPrtrxHolHrs, decimal? rPrtrxOthHrs, decimal? rPrtrxOtHrs, string rPrtrxPayFreq, string rPrtrxPayFreqs, byte? rPrtrxPaySalary, decimal? rPrtrxRegHrs, decimal? rPrtrxSickhrs, decimal? rPrtrxSupplEarn, string rPrtrxType, decimal? rPrtrxVacHrs, decimal? rPrtrxWksWorked, decimal? rPrtrxWorkUnits, string rDerPrdecdWUnitDesc, string rDerEmpDeptUnit, string rDerEmpWageAcct, string rDerEmpWageAcctUnit1, string rDerEmpWageAcctUnit2, string rDerEmpWageAcctUnit3, string rDerEmpWageAcctUnit4, decimal? rDerEmpRegRate, decimal? rDerEmpOtRate, decimal? rDerEmpDtRate, decimal? rHrs, string rType, string Infobar) PayDistGetPaySp(string pPtrxEmpNum = null,
		short? pPtrxSeq = null,
		string rEmpNum = null,
		short? rSeq = null,
		string rEmpName = null,
		string rEmpPayFreq = null,
		decimal? rEmpSalary = null,
		string rEmpType = null,
		string rEmpWcClass = null,
		string rPrtrxBankCode = null,
		string rPrtrxDept = null,
		decimal? rPrtrxDtHrs = null,
		decimal? rPrtrxHolHrs = null,
		decimal? rPrtrxOthHrs = null,
		decimal? rPrtrxOtHrs = null,
		string rPrtrxPayFreq = null,
		string rPrtrxPayFreqs = null,
		byte? rPrtrxPaySalary = null,
		decimal? rPrtrxRegHrs = null,
		decimal? rPrtrxSickhrs = null,
		decimal? rPrtrxSupplEarn = null,
		string rPrtrxType = null,
		decimal? rPrtrxVacHrs = null,
		decimal? rPrtrxWksWorked = null,
		decimal? rPrtrxWorkUnits = null,
		string rDerPrdecdWUnitDesc = null,
		string rDerEmpDeptUnit = null,
		string rDerEmpWageAcct = null,
		string rDerEmpWageAcctUnit1 = null,
		string rDerEmpWageAcctUnit2 = null,
		string rDerEmpWageAcctUnit3 = null,
		string rDerEmpWageAcctUnit4 = null,
		decimal? rDerEmpRegRate = null,
		decimal? rDerEmpOtRate = null,
		decimal? rDerEmpDtRate = null,
		decimal? rHrs = null,
		string rType = null,
		string Infobar = null);
	}
	
	public class PayDistGetPay : IPayDistGetPay
	{
		readonly IApplicationDB appDB;
		
		public PayDistGetPay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rEmpNum, short? rSeq, string rEmpName, string rEmpPayFreq, decimal? rEmpSalary, string rEmpType, string rEmpWcClass, string rPrtrxBankCode, string rPrtrxDept, decimal? rPrtrxDtHrs, decimal? rPrtrxHolHrs, decimal? rPrtrxOthHrs, decimal? rPrtrxOtHrs, string rPrtrxPayFreq, string rPrtrxPayFreqs, byte? rPrtrxPaySalary, decimal? rPrtrxRegHrs, decimal? rPrtrxSickhrs, decimal? rPrtrxSupplEarn, string rPrtrxType, decimal? rPrtrxVacHrs, decimal? rPrtrxWksWorked, decimal? rPrtrxWorkUnits, string rDerPrdecdWUnitDesc, string rDerEmpDeptUnit, string rDerEmpWageAcct, string rDerEmpWageAcctUnit1, string rDerEmpWageAcctUnit2, string rDerEmpWageAcctUnit3, string rDerEmpWageAcctUnit4, decimal? rDerEmpRegRate, decimal? rDerEmpOtRate, decimal? rDerEmpDtRate, decimal? rHrs, string rType, string Infobar) PayDistGetPaySp(string pPtrxEmpNum = null,
		short? pPtrxSeq = null,
		string rEmpNum = null,
		short? rSeq = null,
		string rEmpName = null,
		string rEmpPayFreq = null,
		decimal? rEmpSalary = null,
		string rEmpType = null,
		string rEmpWcClass = null,
		string rPrtrxBankCode = null,
		string rPrtrxDept = null,
		decimal? rPrtrxDtHrs = null,
		decimal? rPrtrxHolHrs = null,
		decimal? rPrtrxOthHrs = null,
		decimal? rPrtrxOtHrs = null,
		string rPrtrxPayFreq = null,
		string rPrtrxPayFreqs = null,
		byte? rPrtrxPaySalary = null,
		decimal? rPrtrxRegHrs = null,
		decimal? rPrtrxSickhrs = null,
		decimal? rPrtrxSupplEarn = null,
		string rPrtrxType = null,
		decimal? rPrtrxVacHrs = null,
		decimal? rPrtrxWksWorked = null,
		decimal? rPrtrxWorkUnits = null,
		string rDerPrdecdWUnitDesc = null,
		string rDerEmpDeptUnit = null,
		string rDerEmpWageAcct = null,
		string rDerEmpWageAcctUnit1 = null,
		string rDerEmpWageAcctUnit2 = null,
		string rDerEmpWageAcctUnit3 = null,
		string rDerEmpWageAcctUnit4 = null,
		decimal? rDerEmpRegRate = null,
		decimal? rDerEmpOtRate = null,
		decimal? rDerEmpDtRate = null,
		decimal? rHrs = null,
		string rType = null,
		string Infobar = null)
		{
			EmpNumType _pPtrxEmpNum = pPtrxEmpNum;
			PrtrxSeqType _pPtrxSeq = pPtrxSeq;
			EmpNumType _rEmpNum = rEmpNum;
			PrtrxSeqType _rSeq = rSeq;
			NameType _rEmpName = rEmpName;
			PrPayFreqType _rEmpPayFreq = rEmpPayFreq;
			PrAmountType _rEmpSalary = rEmpSalary;
			EmpTypeType _rEmpType = rEmpType;
			DeCodeType _rEmpWcClass = rEmpWcClass;
			BankCodeType _rPrtrxBankCode = rPrtrxBankCode;
			DeptType _rPrtrxDept = rPrtrxDept;
			TotalHoursType _rPrtrxDtHrs = rPrtrxDtHrs;
			TotalHoursType _rPrtrxHolHrs = rPrtrxHolHrs;
			TotalHoursType _rPrtrxOthHrs = rPrtrxOthHrs;
			TotalHoursType _rPrtrxOtHrs = rPrtrxOtHrs;
			PrPayFreqType _rPrtrxPayFreq = rPrtrxPayFreq;
			PrPayFreqsType _rPrtrxPayFreqs = rPrtrxPayFreqs;
			ListYesNoType _rPrtrxPaySalary = rPrtrxPaySalary;
			TotalHoursType _rPrtrxRegHrs = rPrtrxRegHrs;
			TotalHoursType _rPrtrxSickhrs = rPrtrxSickhrs;
			PrAmountType _rPrtrxSupplEarn = rPrtrxSupplEarn;
			PrtrxTypeType _rPrtrxType = rPrtrxType;
			TotalHoursType _rPrtrxVacHrs = rPrtrxVacHrs;
			WeeksWorkedType _rPrtrxWksWorked = rPrtrxWksWorked;
			PrAmountType _rPrtrxWorkUnits = rPrtrxWorkUnits;
			DeWorkUnitDescType _rDerPrdecdWUnitDesc = rDerPrdecdWUnitDesc;
			UnitCode1Type _rDerEmpDeptUnit = rDerEmpDeptUnit;
			AcctType _rDerEmpWageAcct = rDerEmpWageAcct;
			UnitCode1Type _rDerEmpWageAcctUnit1 = rDerEmpWageAcctUnit1;
			UnitCode2Type _rDerEmpWageAcctUnit2 = rDerEmpWageAcctUnit2;
			UnitCode3Type _rDerEmpWageAcctUnit3 = rDerEmpWageAcctUnit3;
			UnitCode4Type _rDerEmpWageAcctUnit4 = rDerEmpWageAcctUnit4;
			PayRateType _rDerEmpRegRate = rDerEmpRegRate;
			PayRateType _rDerEmpOtRate = rDerEmpOtRate;
			PayRateType _rDerEmpDtRate = rDerEmpDtRate;
			TotalHoursType _rHrs = rHrs;
			PrtrxdTypeType _rType = rType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PayDistGetPaySp";
				
				appDB.AddCommandParameter(cmd, "pPtrxEmpNum", _pPtrxEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPtrxSeq", _pPtrxSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rEmpNum", _rEmpNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rSeq", _rSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rEmpName", _rEmpName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rEmpPayFreq", _rEmpPayFreq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rEmpSalary", _rEmpSalary, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rEmpType", _rEmpType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rEmpWcClass", _rEmpWcClass, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxBankCode", _rPrtrxBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxDept", _rPrtrxDept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxDtHrs", _rPrtrxDtHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxHolHrs", _rPrtrxHolHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxOthHrs", _rPrtrxOthHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxOtHrs", _rPrtrxOtHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxPayFreq", _rPrtrxPayFreq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxPayFreqs", _rPrtrxPayFreqs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxPaySalary", _rPrtrxPaySalary, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxRegHrs", _rPrtrxRegHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxSickhrs", _rPrtrxSickhrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxSupplEarn", _rPrtrxSupplEarn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxType", _rPrtrxType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxVacHrs", _rPrtrxVacHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxWksWorked", _rPrtrxWksWorked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPrtrxWorkUnits", _rPrtrxWorkUnits, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerPrdecdWUnitDesc", _rDerPrdecdWUnitDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpDeptUnit", _rDerEmpDeptUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpWageAcct", _rDerEmpWageAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpWageAcctUnit1", _rDerEmpWageAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpWageAcctUnit2", _rDerEmpWageAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpWageAcctUnit3", _rDerEmpWageAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpWageAcctUnit4", _rDerEmpWageAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpRegRate", _rDerEmpRegRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpOtRate", _rDerEmpOtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDerEmpDtRate", _rDerEmpDtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rHrs", _rHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rType", _rType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rEmpNum = _rEmpNum;
				rSeq = _rSeq;
				rEmpName = _rEmpName;
				rEmpPayFreq = _rEmpPayFreq;
				rEmpSalary = _rEmpSalary;
				rEmpType = _rEmpType;
				rEmpWcClass = _rEmpWcClass;
				rPrtrxBankCode = _rPrtrxBankCode;
				rPrtrxDept = _rPrtrxDept;
				rPrtrxDtHrs = _rPrtrxDtHrs;
				rPrtrxHolHrs = _rPrtrxHolHrs;
				rPrtrxOthHrs = _rPrtrxOthHrs;
				rPrtrxOtHrs = _rPrtrxOtHrs;
				rPrtrxPayFreq = _rPrtrxPayFreq;
				rPrtrxPayFreqs = _rPrtrxPayFreqs;
				rPrtrxPaySalary = _rPrtrxPaySalary;
				rPrtrxRegHrs = _rPrtrxRegHrs;
				rPrtrxSickhrs = _rPrtrxSickhrs;
				rPrtrxSupplEarn = _rPrtrxSupplEarn;
				rPrtrxType = _rPrtrxType;
				rPrtrxVacHrs = _rPrtrxVacHrs;
				rPrtrxWksWorked = _rPrtrxWksWorked;
				rPrtrxWorkUnits = _rPrtrxWorkUnits;
				rDerPrdecdWUnitDesc = _rDerPrdecdWUnitDesc;
				rDerEmpDeptUnit = _rDerEmpDeptUnit;
				rDerEmpWageAcct = _rDerEmpWageAcct;
				rDerEmpWageAcctUnit1 = _rDerEmpWageAcctUnit1;
				rDerEmpWageAcctUnit2 = _rDerEmpWageAcctUnit2;
				rDerEmpWageAcctUnit3 = _rDerEmpWageAcctUnit3;
				rDerEmpWageAcctUnit4 = _rDerEmpWageAcctUnit4;
				rDerEmpRegRate = _rDerEmpRegRate;
				rDerEmpOtRate = _rDerEmpOtRate;
				rDerEmpDtRate = _rDerEmpDtRate;
				rHrs = _rHrs;
				rType = _rType;
				Infobar = _Infobar;
				
				return (Severity, rEmpNum, rSeq, rEmpName, rEmpPayFreq, rEmpSalary, rEmpType, rEmpWcClass, rPrtrxBankCode, rPrtrxDept, rPrtrxDtHrs, rPrtrxHolHrs, rPrtrxOthHrs, rPrtrxOtHrs, rPrtrxPayFreq, rPrtrxPayFreqs, rPrtrxPaySalary, rPrtrxRegHrs, rPrtrxSickhrs, rPrtrxSupplEarn, rPrtrxType, rPrtrxVacHrs, rPrtrxWksWorked, rPrtrxWorkUnits, rDerPrdecdWUnitDesc, rDerEmpDeptUnit, rDerEmpWageAcct, rDerEmpWageAcctUnit1, rDerEmpWageAcctUnit2, rDerEmpWageAcctUnit3, rDerEmpWageAcctUnit4, rDerEmpRegRate, rDerEmpOtRate, rDerEmpDtRate, rHrs, rType, Infobar);
			}
		}
	}
}
