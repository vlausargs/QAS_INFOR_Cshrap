//PROJECT NAME: Admin
//CLASS NAME: ProcessEmployee.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class ProcessEmployee : IProcessEmployee
	{
		IApplicationDB appDB;
		
		
		public ProcessEmployee(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProcessEmployeeSp(string EmpNum,
		string Dept,
		string DlAcct,
		string DeptAcctUnit1,
		string DlAcctUnit2,
		string DlAcctUnit3,
		string DlAcctUnit4,
		int? UpdateDept,
		string Name,
		string LastName,
		string FirstName,
		string Mi,
		string Addr1,
		string Addr2,
		string City,
		string State,
		string Zip,
		string Ssn,
		string Phone,
		string PayFreq,
		decimal? Rate,
		string Marital,
		decimal? YtdGrs,
		decimal? YtdFwt,
		decimal? YtdFica,
		decimal? YtdMed,
		decimal? YtdSwt,
		decimal? YtdOst,
		decimal? YtdCwt,
		int? Prenote,
		string Infobar)
		{
			EmpNumType _EmpNum = EmpNum;
			DeptType _Dept = Dept;
			AcctType _DlAcct = DlAcct;
			UnitCode1Type _DeptAcctUnit1 = DeptAcctUnit1;
			UnitCode2Type _DlAcctUnit2 = DlAcctUnit2;
			UnitCode3Type _DlAcctUnit3 = DlAcctUnit3;
			UnitCode4Type _DlAcctUnit4 = DlAcctUnit4;
			ListYesNoType _UpdateDept = UpdateDept;
			EmpNameType _Name = Name;
			SurnameType _LastName = LastName;
			GivenNameType _FirstName = FirstName;
			InitialType _Mi = Mi;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			SsnType _Ssn = Ssn;
			PhoneType _Phone = Phone;
			PrPayFreqType _PayFreq = PayFreq;
			PayRateType _Rate = Rate;
			MaritalStatusType _Marital = Marital;
			PrYtdAmountType _YtdGrs = YtdGrs;
			PrYtdAmountType _YtdFwt = YtdFwt;
			PrYtdAmountType _YtdFica = YtdFica;
			PrYtdAmountType _YtdMed = YtdMed;
			PrYtdAmountType _YtdSwt = YtdSwt;
			PrYtdAmountType _YtdOst = YtdOst;
			PrYtdAmountType _YtdCwt = YtdCwt;
			PrenoteType _Prenote = Prenote;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessEmployeeSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DlAcct", _DlAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeptAcctUnit1", _DeptAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DlAcctUnit2", _DlAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DlAcctUnit3", _DlAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DlAcctUnit4", _DlAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateDept", _UpdateDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastName", _LastName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstName", _FirstName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mi", _Mi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ssn", _Ssn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayFreq", _PayFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rate", _Rate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Marital", _Marital, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YtdGrs", _YtdGrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YtdFwt", _YtdFwt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YtdFica", _YtdFica, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YtdMed", _YtdMed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YtdSwt", _YtdSwt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YtdOst", _YtdOst, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YtdCwt", _YtdCwt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prenote", _Prenote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
