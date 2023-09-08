//PROJECT NAME: Employee
//CLASS NAME: GetApplicantData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class GetApplicantData : IGetApplicantData
	{
		readonly IApplicationDB appDB;
		
		
		public GetApplicantData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string app_num,
		string lname,
		string fname,
		string mi,
		string sname,
		string addr_1,
		string addr_2,
		string addr_3,
		string addr_4,
		string city,
		string state,
		string zip,
		string phone,
		string marital_stat,
		string sex,
		DateTime? birth_date,
		string ssn,
		string ethnic_id,
		int? citizen,
		int? handicap,
		string nationality,
		string work_stat,
		string military,
		DateTime? HireDate,
		DateTime? ADate,
		string Infobar) GetApplicantDataSp(string AppNum,
		string app_num,
		string lname,
		string fname,
		string mi,
		string sname,
		string addr_1,
		string addr_2,
		string addr_3,
		string addr_4,
		string city,
		string state,
		string zip,
		string phone,
		string marital_stat,
		string sex,
		DateTime? birth_date,
		string ssn,
		string ethnic_id,
		int? citizen,
		int? handicap,
		string nationality,
		string work_stat,
		string military,
		DateTime? HireDate,
		DateTime? ADate,
		string Infobar)
		{
			AppNumType _AppNum = AppNum;
			AppNumType _app_num = app_num;
			SurnameType _lname = lname;
			GivenNameType _fname = fname;
			InitialType _mi = mi;
			SuffixNameType _sname = sname;
			AddressType _addr_1 = addr_1;
			AddressType _addr_2 = addr_2;
			AddressType _addr_3 = addr_3;
			AddressType _addr_4 = addr_4;
			CityType _city = city;
			StateType _state = state;
			PostalCodeType _zip = zip;
			PhoneType _phone = phone;
			MaritalStatusType _marital_stat = marital_stat;
			SexType _sex = sex;
			Date4Type _birth_date = birth_date;
			SsnType _ssn = ssn;
			EthnicIdType _ethnic_id = ethnic_id;
			ListYesNoType _citizen = citizen;
			ListYesNoType _handicap = handicap;
			NationalityType _nationality = nationality;
			WorkStatusType _work_stat = work_stat;
			MilitaryType _military = military;
			Date4Type _HireDate = HireDate;
			Date4Type _ADate = ADate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetApplicantDataSp";
				
				appDB.AddCommandParameter(cmd, "AppNum", _AppNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "app_num", _app_num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "lname", _lname, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fname", _fname, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "mi", _mi, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "sname", _sname, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "addr_1", _addr_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "addr_2", _addr_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "addr_3", _addr_3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "addr_4", _addr_4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "city", _city, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "state", _state, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "zip", _zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "phone", _phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "marital_stat", _marital_stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "sex", _sex, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "birth_date", _birth_date, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ssn", _ssn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ethnic_id", _ethnic_id, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "citizen", _citizen, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "handicap", _handicap, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "nationality", _nationality, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "work_stat", _work_stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "military", _military, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HireDate", _HireDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ADate", _ADate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				app_num = _app_num;
				lname = _lname;
				fname = _fname;
				mi = _mi;
				sname = _sname;
				addr_1 = _addr_1;
				addr_2 = _addr_2;
				addr_3 = _addr_3;
				addr_4 = _addr_4;
				city = _city;
				state = _state;
				zip = _zip;
				phone = _phone;
				marital_stat = _marital_stat;
				sex = _sex;
				birth_date = _birth_date;
				ssn = _ssn;
				ethnic_id = _ethnic_id;
				citizen = _citizen;
				handicap = _handicap;
				nationality = _nationality;
				work_stat = _work_stat;
				military = _military;
				HireDate = _HireDate;
				ADate = _ADate;
				Infobar = _Infobar;
				
				return (Severity, app_num, lname, fname, mi, sname, addr_1, addr_2, addr_3, addr_4, city, state, zip, phone, marital_stat, sex, birth_date, ssn, ethnic_id, citizen, handicap, nationality, work_stat, military, HireDate, ADate, Infobar);
			}
		}
	}
}
