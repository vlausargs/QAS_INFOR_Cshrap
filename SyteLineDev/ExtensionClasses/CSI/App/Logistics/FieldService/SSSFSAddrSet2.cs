//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAddrSet2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAddrSet2 : ISSSFSAddrSet2
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAddrSet2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Addr1_1,
			string Addr1_2,
			string Addr1_3,
			string Addr1_4,
			string Addr1_5,
			string Addr1_6,
			string Addr1_7,
			string Addr1_8,
			string Infobar) SSSFSAddrSet2Sp(
			string CustContact,
			string CustPhone,
			string CustName,
			string CustAddr1,
			string CustAddr2,
			string CustAddr3,
			string CustAddr4,
			string CustCity,
			string CustState,
			string CustZip,
			string CustCountry,
			string Addr1_1,
			string Addr1_2,
			string Addr1_3,
			string Addr1_4,
			string Addr1_5,
			string Addr1_6,
			string Addr1_7,
			string Addr1_8,
			string Infobar)
		{
			ContactType _CustContact = CustContact;
			PhoneType _CustPhone = CustPhone;
			NameType _CustName = CustName;
			AddressType _CustAddr1 = CustAddr1;
			AddressType _CustAddr2 = CustAddr2;
			AddressType _CustAddr3 = CustAddr3;
			AddressType _CustAddr4 = CustAddr4;
			CityType _CustCity = CustCity;
			StateType _CustState = CustState;
			PostalCodeType _CustZip = CustZip;
			CountryType _CustCountry = CustCountry;
			AddressType _Addr1_1 = Addr1_1;
			AddressType _Addr1_2 = Addr1_2;
			AddressType _Addr1_3 = Addr1_3;
			AddressType _Addr1_4 = Addr1_4;
			AddressType _Addr1_5 = Addr1_5;
			AddressType _Addr1_6 = Addr1_6;
			AddressType _Addr1_7 = Addr1_7;
			AddressType _Addr1_8 = Addr1_8;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAddrSet2Sp";
				
				appDB.AddCommandParameter(cmd, "CustContact", _CustContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPhone", _CustPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustName", _CustName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddr1", _CustAddr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddr2", _CustAddr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddr3", _CustAddr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddr4", _CustAddr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustCity", _CustCity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustState", _CustState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustZip", _CustZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustCountry", _CustCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1_1", _Addr1_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_2", _Addr1_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_3", _Addr1_3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_4", _Addr1_4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_5", _Addr1_5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_6", _Addr1_6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_7", _Addr1_7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_8", _Addr1_8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Addr1_1 = _Addr1_1;
				Addr1_2 = _Addr1_2;
				Addr1_3 = _Addr1_3;
				Addr1_4 = _Addr1_4;
				Addr1_5 = _Addr1_5;
				Addr1_6 = _Addr1_6;
				Addr1_7 = _Addr1_7;
				Addr1_8 = _Addr1_8;
				Infobar = _Infobar;
				
				return (Severity, Addr1_1, Addr1_2, Addr1_3, Addr1_4, Addr1_5, Addr1_6, Addr1_7, Addr1_8, Infobar);
			}
		}
	}
}
