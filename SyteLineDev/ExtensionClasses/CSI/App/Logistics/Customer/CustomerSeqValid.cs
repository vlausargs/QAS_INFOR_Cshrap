//PROJECT NAME: Logistics
//CLASS NAME: CustomerSeqValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomerSeqValid : ICustomerSeqValid
	{
		readonly IApplicationDB appDB;
		
		
		public CustomerSeqValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Name,
		string City,
		string State,
		string Zip,
		string County,
		string Country,
		string FaxNum,
		string TelexNum,
		string Addr_1,
		string Addr_2,
		string Addr_3,
		string Addr_4,
		string CurrCode,
		string ShipToEmail,
		string BillToEmail,
		Guid? RowPointer,
		string Infobar) CustomerSeqValidSp(string CustNum,
		int? CustSeq,
		string Name,
		string City,
		string State,
		string Zip,
		string County,
		string Country,
		string FaxNum,
		string TelexNum,
		string Addr_1,
		string Addr_2,
		string Addr_3,
		string Addr_4,
		string CurrCode,
		string ShipToEmail,
		string BillToEmail,
		Guid? RowPointer,
		string Infobar,
		string PSite = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			NameType _Name = Name;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountyType _County = County;
			CountryType _Country = Country;
			PhoneType _FaxNum = FaxNum;
			PhoneType _TelexNum = TelexNum;
			AddressType _Addr_1 = Addr_1;
			AddressType _Addr_2 = Addr_2;
			AddressType _Addr_3 = Addr_3;
			AddressType _Addr_4 = Addr_4;
			CurrCodeType _CurrCode = CurrCode;
			EmailType _ShipToEmail = ShipToEmail;
			EmailType _BillToEmail = BillToEmail;
			RowPointerType _RowPointer = RowPointer;
			Infobar _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerSeqValidSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TelexNum", _TelexNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr_1", _Addr_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr_2", _Addr_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr_3", _Addr_3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr_4", _Addr_4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToEmail", _ShipToEmail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillToEmail", _BillToEmail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Name = _Name;
				City = _City;
				State = _State;
				Zip = _Zip;
				County = _County;
				Country = _Country;
				FaxNum = _FaxNum;
				TelexNum = _TelexNum;
				Addr_1 = _Addr_1;
				Addr_2 = _Addr_2;
				Addr_3 = _Addr_3;
				Addr_4 = _Addr_4;
				CurrCode = _CurrCode;
				ShipToEmail = _ShipToEmail;
				BillToEmail = _BillToEmail;
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, Name, City, State, Zip, County, Country, FaxNum, TelexNum, Addr_1, Addr_2, Addr_3, Addr_4, CurrCode, ShipToEmail, BillToEmail, RowPointer, Infobar);
			}
		}
	}
}
