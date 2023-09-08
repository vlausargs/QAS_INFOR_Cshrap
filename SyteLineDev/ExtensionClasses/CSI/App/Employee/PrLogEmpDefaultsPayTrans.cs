//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogEmpDefaultsPayTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPrLogEmpDefaultsPayTrans
	{
		(int? ReturnCode, string EmpName, short? EmpSeq, string EmpShift, decimal? TransNum, decimal? PayRate, string Infobar, string Acct, string AcctUnit1, string AcctUnit2, string AcctUnit3, string AcctUnit4) PrLogEmpDefaultsPayTransSp(string EmpNum,
		string HrType,
		DateTime? WorkDate,
		string EmpName,
		short? EmpSeq,
		string EmpShift,
		decimal? TransNum,
		decimal? PayRate,
		string Infobar,
		string Acct = null,
		string AcctUnit1 = null,
		string AcctUnit2 = null,
		string AcctUnit3 = null,
		string AcctUnit4 = null);
	}
	
	public class PrLogEmpDefaultsPayTrans : IPrLogEmpDefaultsPayTrans
	{
		readonly IApplicationDB appDB;
		
		public PrLogEmpDefaultsPayTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string EmpName, short? EmpSeq, string EmpShift, decimal? TransNum, decimal? PayRate, string Infobar, string Acct, string AcctUnit1, string AcctUnit2, string AcctUnit3, string AcctUnit4) PrLogEmpDefaultsPayTransSp(string EmpNum,
		string HrType,
		DateTime? WorkDate,
		string EmpName,
		short? EmpSeq,
		string EmpShift,
		decimal? TransNum,
		decimal? PayRate,
		string Infobar,
		string Acct = null,
		string AcctUnit1 = null,
		string AcctUnit2 = null,
		string AcctUnit3 = null,
		string AcctUnit4 = null)
		{
			EmpNumType _EmpNum = EmpNum;
			PrhrsHrTypeType _HrType = HrType;
			DateType _WorkDate = WorkDate;
			EmpNameType _EmpName = EmpName;
			PrLogSeqType _EmpSeq = EmpSeq;
			ShiftType _EmpShift = EmpShift;
			MatlTransNumType _TransNum = TransNum;
			PayRatePreciseType _PayRate = PayRate;
			InfobarType _Infobar = Infobar;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrLogEmpDefaultsPayTransSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrType", _HrType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDate", _WorkDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpName", _EmpName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpSeq", _EmpSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpShift", _EmpShift, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayRate", _PayRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmpName = _EmpName;
				EmpSeq = _EmpSeq;
				EmpShift = _EmpShift;
				TransNum = _TransNum;
				PayRate = _PayRate;
				Infobar = _Infobar;
				Acct = _Acct;
				AcctUnit1 = _AcctUnit1;
				AcctUnit2 = _AcctUnit2;
				AcctUnit3 = _AcctUnit3;
				AcctUnit4 = _AcctUnit4;
				
				return (Severity, EmpName, EmpSeq, EmpShift, TransNum, PayRate, Infobar, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4);
			}
		}
	}
}
