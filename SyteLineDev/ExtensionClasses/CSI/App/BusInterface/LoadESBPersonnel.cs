//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBPersonnel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBPersonnel : ILoadESBPersonnel
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBPersonnel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadESBPersonnelSp(string ActionExpression = null,
		string EmpNum = null,
		string Fname = null,
		string Nickname = null,
		string Mi = null,
		string Lname = null,
		string Sname = null,
		string GenderCode = null,
		string MaritalStatusCode = null,
		DateTime? BirthDate = null,
		string Nationality = null,
		string CitizenshipCountry = null,
		string Addr1 = null,
		string Addr2 = null,
		string Addr3 = null,
		string Addr4 = null,
		string City = null,
		string State = null,
		string ISOCountryCode = null,
		string Zip = null,
		string Phone = null,
		DateTime? HireDate = null,
		string Status = null,
		string CostCenterCode = null,
		string PosJobTitle = null,
		string EmpposJobId = null,
		DateTime? EmpAssignDate = null,
		string Extension = null,
		string EmailAddress = null,
		string Shift = null,
		string PayFreq = null,
		string BankName = null,
		string AccountID = null,
		string AccountType = null,
		string MilitaryDesc = null,
		string Military = null,
		string EthnicId = null,
		string Handicap = null,
		string Supervisor = null,
		decimal? DepAmount = null,
		decimal? DepPct = null,
		string Infobar = null)
		{
			StringType _ActionExpression = ActionExpression;
			EmpNumType _EmpNum = EmpNum;
			GivenNameType _Fname = Fname;
			OtherNameType _Nickname = Nickname;
			InitialType _Mi = Mi;
			SurnameType _Lname = Lname;
			SuffixNameType _Sname = Sname;
			StringType _GenderCode = GenderCode;
			StringType _MaritalStatusCode = MaritalStatusCode;
			Date4Type _BirthDate = BirthDate;
			NationalityType _Nationality = Nationality;
			CountryType _CitizenshipCountry = CitizenshipCountry;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			StateType _State = State;
			CountryType _ISOCountryCode = ISOCountryCode;
			PostalCodeType _Zip = Zip;
			PhoneType _Phone = Phone;
			DateType _HireDate = HireDate;
			StringType _Status = Status;
			StringType _CostCenterCode = CostCenterCode;
			StringType _PosJobTitle = PosJobTitle;
			StringType _EmpposJobId = EmpposJobId;
			DateType _EmpAssignDate = EmpAssignDate;
			StringType _Extension = Extension;
			StringType _EmailAddress = EmailAddress;
			ShiftType _Shift = Shift;
			PrPayFreqType _PayFreq = PayFreq;
			NameType _BankName = BankName;
			BankAccountType _AccountID = AccountID;
			EmpDepTypeType _AccountType = AccountType;
			DescriptionType _MilitaryDesc = MilitaryDesc;
			MilitaryType _Military = Military;
			EthnicIdType _EthnicId = EthnicId;
			StringType _Handicap = Handicap;
			EmpNumType _Supervisor = Supervisor;
			RetireAmountType _DepAmount = DepAmount;
			DirDepPercentType _DepPct = DepPct;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBPersonnelSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Fname", _Fname, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Nickname", _Nickname, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mi", _Mi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lname", _Lname, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sname", _Sname, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenderCode", _GenderCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaritalStatusCode", _MaritalStatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BirthDate", _BirthDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Nationality", _Nationality, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CitizenshipCountry", _CitizenshipCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOCountryCode", _ISOCountryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HireDate", _HireDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCenterCode", _CostCenterCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PosJobTitle", _PosJobTitle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpposJobId", _EmpposJobId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpAssignDate", _EmpAssignDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Extension", _Extension, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailAddress", _EmailAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayFreq", _PayFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankName", _BankName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountID", _AccountID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountType", _AccountType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MilitaryDesc", _MilitaryDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Military", _Military, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EthnicId", _EthnicId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Handicap", _Handicap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Supervisor", _Supervisor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepAmount", _DepAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepPct", _DepPct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
