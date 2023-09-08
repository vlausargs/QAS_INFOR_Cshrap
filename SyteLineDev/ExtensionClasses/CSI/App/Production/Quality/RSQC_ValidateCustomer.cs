//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateCustom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateCustom : IRSQC_ValidateCustom
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_ValidateCustom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Name,
		string City,
		string State,
		string Zip,
		string Country,
		string Contact,
		string Phone,
		string Fax,
		string eMail,
		string Infobar) RSQC_ValidateCustomer(int? ValidateOk,
		string CustNum,
		int? CustSeq,
		string Name,
		string City,
		string State,
		string Zip,
		string Country,
		string Contact,
		string Phone,
		string Fax,
		string eMail,
		string Infobar)
		{
			ListYesNoType _ValidateOk = ValidateOk;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			StringType _Name = Name;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			StringType _Contact = Contact;
			StringType _Phone = Phone;
			StringType _Fax = Fax;
			StringType _eMail = eMail;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ValidateCustomer";
				
				appDB.AddCommandParameter(cmd, "ValidateOk", _ValidateOk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Fax", _Fax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "eMail", _eMail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Name = _Name;
				City = _City;
				State = _State;
				Zip = _Zip;
				Country = _Country;
				Contact = _Contact;
				Phone = _Phone;
				Fax = _Fax;
				eMail = _eMail;
				Infobar = _Infobar;
				
				return (Severity, Name, City, State, Zip, Country, Contact, Phone, Fax, eMail, Infobar);
			}
		}
	}
}
