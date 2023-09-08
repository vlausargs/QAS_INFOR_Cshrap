//PROJECT NAME: Employee
//CLASS NAME: Tmp10941095c.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface ITmp10941095c
	{
		(int? ReturnCode, decimal? Total_1095, string Infobar) Tmp10941095cSp(Guid? SessionID = null,
		string Action = null,
		decimal? Total_1095 = null,
		string EmployerName = null,
		string EmployerEIN = null,
		string EmployerAddr__1 = null,
		string EmployerCity = null,
		string EmployerState = null,
		string EmployerCountry = null,
		string EmployerZip = null,
		string ContactFirstName = null,
		string ContactLastName = null,
		string ContactPhone = null,
		string DGEEmployerName = null,
		string DGEEmployerEIN = null,
		string DGEEmployerAddr__1 = null,
		string DGEEmployerCity = null,
		string DGEEmployerState = null,
		string DGEEmployerCountry = null,
		string DGEEmployerZip = null,
		string DGEContactFirstName = null,
		string DGEContactLastName = null,
		string DGEContactPhone = null,
		string OtherAleName01 = null,
		string OtherAleEin01 = null,
		string OtherAleName02 = null,
		string OtherAleEin02 = null,
		string OtherAleName03 = null,
		string OtherAleEin03 = null,
		string OtherAleName04 = null,
		string OtherAleEin04 = null,
		string OtherAleName05 = null,
		string OtherAleEin05 = null,
		string OtherAleName06 = null,
		string OtherAleEin06 = null,
		string OtherAleName07 = null,
		string OtherAleEin07 = null,
		string OtherAleName08 = null,
		string OtherAleEin08 = null,
		string OtherAleName09 = null,
		string OtherAleEin09 = null,
		string OtherAleName10 = null,
		string OtherAleEin10 = null,
		string OtherAleName11 = null,
		string OtherAleEin11 = null,
		string OtherAleName12 = null,
		string OtherAleEin12 = null,
		string OtherAleName13 = null,
		string OtherAleEin13 = null,
		string OtherAleName14 = null,
		string OtherAleEin14 = null,
		string OtherAleName15 = null,
		string OtherAleEin15 = null,
		string OtherAleName16 = null,
		string OtherAleEin16 = null,
		string OtherAleName17 = null,
		string OtherAleEin17 = null,
		string OtherAleName18 = null,
		string OtherAleEin18 = null,
		string OtherAleName19 = null,
		string OtherAleEin19 = null,
		string OtherAleName20 = null,
		string OtherAleEin20 = null,
		string OtherAleName21 = null,
		string OtherAleEin21 = null,
		string OtherAleName22 = null,
		string OtherAleEin22 = null,
		string OtherAleName23 = null,
		string OtherAleEin23 = null,
		string OtherAleName24 = null,
		string OtherAleEin24 = null,
		string OtherAleName25 = null,
		string OtherAleEin25 = null,
		string OtherAleName26 = null,
		string OtherAleEin26 = null,
		string OtherAleName27 = null,
		string OtherAleEin27 = null,
		string OtherAleName28 = null,
		string OtherAleEin28 = null,
		string OtherAleName29 = null,
		string OtherAleEin29 = null,
		string OtherAleName30 = null,
		string OtherAleEin30 = null,
		string Infobar = null);
	}
	
	public class Tmp10941095c : ITmp10941095c
	{
		readonly IApplicationDB appDB;
		
		public Tmp10941095c(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Total_1095, string Infobar) Tmp10941095cSp(Guid? SessionID = null,
		string Action = null,
		decimal? Total_1095 = null,
		string EmployerName = null,
		string EmployerEIN = null,
		string EmployerAddr__1 = null,
		string EmployerCity = null,
		string EmployerState = null,
		string EmployerCountry = null,
		string EmployerZip = null,
		string ContactFirstName = null,
		string ContactLastName = null,
		string ContactPhone = null,
		string DGEEmployerName = null,
		string DGEEmployerEIN = null,
		string DGEEmployerAddr__1 = null,
		string DGEEmployerCity = null,
		string DGEEmployerState = null,
		string DGEEmployerCountry = null,
		string DGEEmployerZip = null,
		string DGEContactFirstName = null,
		string DGEContactLastName = null,
		string DGEContactPhone = null,
		string OtherAleName01 = null,
		string OtherAleEin01 = null,
		string OtherAleName02 = null,
		string OtherAleEin02 = null,
		string OtherAleName03 = null,
		string OtherAleEin03 = null,
		string OtherAleName04 = null,
		string OtherAleEin04 = null,
		string OtherAleName05 = null,
		string OtherAleEin05 = null,
		string OtherAleName06 = null,
		string OtherAleEin06 = null,
		string OtherAleName07 = null,
		string OtherAleEin07 = null,
		string OtherAleName08 = null,
		string OtherAleEin08 = null,
		string OtherAleName09 = null,
		string OtherAleEin09 = null,
		string OtherAleName10 = null,
		string OtherAleEin10 = null,
		string OtherAleName11 = null,
		string OtherAleEin11 = null,
		string OtherAleName12 = null,
		string OtherAleEin12 = null,
		string OtherAleName13 = null,
		string OtherAleEin13 = null,
		string OtherAleName14 = null,
		string OtherAleEin14 = null,
		string OtherAleName15 = null,
		string OtherAleEin15 = null,
		string OtherAleName16 = null,
		string OtherAleEin16 = null,
		string OtherAleName17 = null,
		string OtherAleEin17 = null,
		string OtherAleName18 = null,
		string OtherAleEin18 = null,
		string OtherAleName19 = null,
		string OtherAleEin19 = null,
		string OtherAleName20 = null,
		string OtherAleEin20 = null,
		string OtherAleName21 = null,
		string OtherAleEin21 = null,
		string OtherAleName22 = null,
		string OtherAleEin22 = null,
		string OtherAleName23 = null,
		string OtherAleEin23 = null,
		string OtherAleName24 = null,
		string OtherAleEin24 = null,
		string OtherAleName25 = null,
		string OtherAleEin25 = null,
		string OtherAleName26 = null,
		string OtherAleEin26 = null,
		string OtherAleName27 = null,
		string OtherAleEin27 = null,
		string OtherAleName28 = null,
		string OtherAleEin28 = null,
		string OtherAleName29 = null,
		string OtherAleEin29 = null,
		string OtherAleName30 = null,
		string OtherAleEin30 = null,
		string Infobar = null)
		{
			RowPointerType _SessionID = SessionID;
			RecordActionType _Action = Action;
			RsvdNumType _Total_1095 = Total_1095;
			NameType _EmployerName = EmployerName;
			TaxRegNumType _EmployerEIN = EmployerEIN;
			AddressType _EmployerAddr__1 = EmployerAddr__1;
			CityType _EmployerCity = EmployerCity;
			StateType _EmployerState = EmployerState;
			CountryType _EmployerCountry = EmployerCountry;
			PostalCodeType _EmployerZip = EmployerZip;
			NameType _ContactFirstName = ContactFirstName;
			NameType _ContactLastName = ContactLastName;
			PhoneType _ContactPhone = ContactPhone;
			NameType _DGEEmployerName = DGEEmployerName;
			TaxRegNumType _DGEEmployerEIN = DGEEmployerEIN;
			AddressType _DGEEmployerAddr__1 = DGEEmployerAddr__1;
			CityType _DGEEmployerCity = DGEEmployerCity;
			StateType _DGEEmployerState = DGEEmployerState;
			CountryType _DGEEmployerCountry = DGEEmployerCountry;
			PostalCodeType _DGEEmployerZip = DGEEmployerZip;
			NameType _DGEContactFirstName = DGEContactFirstName;
			NameType _DGEContactLastName = DGEContactLastName;
			PhoneType _DGEContactPhone = DGEContactPhone;
			NameType _OtherAleName01 = OtherAleName01;
			TaxRegNumType _OtherAleEin01 = OtherAleEin01;
			NameType _OtherAleName02 = OtherAleName02;
			TaxRegNumType _OtherAleEin02 = OtherAleEin02;
			NameType _OtherAleName03 = OtherAleName03;
			TaxRegNumType _OtherAleEin03 = OtherAleEin03;
			NameType _OtherAleName04 = OtherAleName04;
			TaxRegNumType _OtherAleEin04 = OtherAleEin04;
			NameType _OtherAleName05 = OtherAleName05;
			TaxRegNumType _OtherAleEin05 = OtherAleEin05;
			NameType _OtherAleName06 = OtherAleName06;
			TaxRegNumType _OtherAleEin06 = OtherAleEin06;
			NameType _OtherAleName07 = OtherAleName07;
			TaxRegNumType _OtherAleEin07 = OtherAleEin07;
			NameType _OtherAleName08 = OtherAleName08;
			TaxRegNumType _OtherAleEin08 = OtherAleEin08;
			NameType _OtherAleName09 = OtherAleName09;
			TaxRegNumType _OtherAleEin09 = OtherAleEin09;
			NameType _OtherAleName10 = OtherAleName10;
			TaxRegNumType _OtherAleEin10 = OtherAleEin10;
			NameType _OtherAleName11 = OtherAleName11;
			TaxRegNumType _OtherAleEin11 = OtherAleEin11;
			NameType _OtherAleName12 = OtherAleName12;
			TaxRegNumType _OtherAleEin12 = OtherAleEin12;
			NameType _OtherAleName13 = OtherAleName13;
			TaxRegNumType _OtherAleEin13 = OtherAleEin13;
			NameType _OtherAleName14 = OtherAleName14;
			TaxRegNumType _OtherAleEin14 = OtherAleEin14;
			NameType _OtherAleName15 = OtherAleName15;
			TaxRegNumType _OtherAleEin15 = OtherAleEin15;
			NameType _OtherAleName16 = OtherAleName16;
			TaxRegNumType _OtherAleEin16 = OtherAleEin16;
			NameType _OtherAleName17 = OtherAleName17;
			TaxRegNumType _OtherAleEin17 = OtherAleEin17;
			NameType _OtherAleName18 = OtherAleName18;
			TaxRegNumType _OtherAleEin18 = OtherAleEin18;
			NameType _OtherAleName19 = OtherAleName19;
			TaxRegNumType _OtherAleEin19 = OtherAleEin19;
			NameType _OtherAleName20 = OtherAleName20;
			TaxRegNumType _OtherAleEin20 = OtherAleEin20;
			NameType _OtherAleName21 = OtherAleName21;
			TaxRegNumType _OtherAleEin21 = OtherAleEin21;
			NameType _OtherAleName22 = OtherAleName22;
			TaxRegNumType _OtherAleEin22 = OtherAleEin22;
			NameType _OtherAleName23 = OtherAleName23;
			TaxRegNumType _OtherAleEin23 = OtherAleEin23;
			NameType _OtherAleName24 = OtherAleName24;
			TaxRegNumType _OtherAleEin24 = OtherAleEin24;
			NameType _OtherAleName25 = OtherAleName25;
			TaxRegNumType _OtherAleEin25 = OtherAleEin25;
			NameType _OtherAleName26 = OtherAleName26;
			TaxRegNumType _OtherAleEin26 = OtherAleEin26;
			NameType _OtherAleName27 = OtherAleName27;
			TaxRegNumType _OtherAleEin27 = OtherAleEin27;
			NameType _OtherAleName28 = OtherAleName28;
			TaxRegNumType _OtherAleEin28 = OtherAleEin28;
			NameType _OtherAleName29 = OtherAleName29;
			TaxRegNumType _OtherAleEin29 = OtherAleEin29;
			NameType _OtherAleName30 = OtherAleName30;
			TaxRegNumType _OtherAleEin30 = OtherAleEin30;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Tmp10941095cSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Total_1095", _Total_1095, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmployerName", _EmployerName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerEIN", _EmployerEIN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerAddr##1", _EmployerAddr__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerCity", _EmployerCity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerState", _EmployerState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerCountry", _EmployerCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerZip", _EmployerZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactFirstName", _ContactFirstName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactLastName", _ContactLastName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactPhone", _ContactPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEEmployerName", _DGEEmployerName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEEmployerEIN", _DGEEmployerEIN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEEmployerAddr##1", _DGEEmployerAddr__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEEmployerCity", _DGEEmployerCity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEEmployerState", _DGEEmployerState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEEmployerCountry", _DGEEmployerCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEEmployerZip", _DGEEmployerZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEContactFirstName", _DGEContactFirstName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEContactLastName", _DGEContactLastName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DGEContactPhone", _DGEContactPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName01", _OtherAleName01, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin01", _OtherAleEin01, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName02", _OtherAleName02, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin02", _OtherAleEin02, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName03", _OtherAleName03, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin03", _OtherAleEin03, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName04", _OtherAleName04, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin04", _OtherAleEin04, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName05", _OtherAleName05, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin05", _OtherAleEin05, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName06", _OtherAleName06, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin06", _OtherAleEin06, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName07", _OtherAleName07, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin07", _OtherAleEin07, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName08", _OtherAleName08, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin08", _OtherAleEin08, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName09", _OtherAleName09, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin09", _OtherAleEin09, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName10", _OtherAleName10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin10", _OtherAleEin10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName11", _OtherAleName11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin11", _OtherAleEin11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName12", _OtherAleName12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin12", _OtherAleEin12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName13", _OtherAleName13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin13", _OtherAleEin13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName14", _OtherAleName14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin14", _OtherAleEin14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName15", _OtherAleName15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin15", _OtherAleEin15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName16", _OtherAleName16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin16", _OtherAleEin16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName17", _OtherAleName17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin17", _OtherAleEin17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName18", _OtherAleName18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin18", _OtherAleEin18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName19", _OtherAleName19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin19", _OtherAleEin19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName20", _OtherAleName20, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin20", _OtherAleEin20, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName21", _OtherAleName21, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin21", _OtherAleEin21, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName22", _OtherAleName22, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin22", _OtherAleEin22, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName23", _OtherAleName23, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin23", _OtherAleEin23, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName24", _OtherAleName24, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin24", _OtherAleEin24, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName25", _OtherAleName25, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin25", _OtherAleEin25, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName26", _OtherAleName26, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin26", _OtherAleEin26, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName27", _OtherAleName27, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin27", _OtherAleEin27, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName28", _OtherAleName28, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin28", _OtherAleEin28, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName29", _OtherAleName29, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin29", _OtherAleEin29, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleName30", _OtherAleName30, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherAleEin30", _OtherAleEin30, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Total_1095 = _Total_1095;
				Infobar = _Infobar;
				
				return (Severity, Total_1095, Infobar);
			}
		}
	}
}
