//PROJECT NAME: Codes
//CLASS NAME: CustomerPortalCreateCustomerShipTo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CustomerPortalCreateCustomerShipTo : ICustomerPortalCreateCustomerShipTo
	{
		readonly IApplicationDB appDB;
		
		
		public CustomerPortalCreateCustomerShipTo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CustSeq,
		string Infobar) CustomerPortalCreateCustomerShipToSp(string CustNum,
		string CustSeq,
		string Name,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string County,
		string State,
		string PostalCode,
		string Country,
		string ResellerSlsman,
		string ShipToContactName,
		string ShipToContactPhone,
		string ShipToContactFax,
		string ShipToContactEmail,
		int? PrimarySiteFlag,
		int? BillToFlag,
		int? AddressChanged,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			StringType _CustSeq = CustSeq;
			NameType _Name = Name;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			CountyType _County = County;
			StateType _State = State;
			PostalCodeType _PostalCode = PostalCode;
			CountryType _Country = Country;
			SlsmanType _ResellerSlsman = ResellerSlsman;
			NameType _ShipToContactName = ShipToContactName;
			PhoneType _ShipToContactPhone = ShipToContactPhone;
			PhoneType _ShipToContactFax = ShipToContactFax;
			EmailType _ShipToContactEmail = ShipToContactEmail;
			ListYesNoType _PrimarySiteFlag = PrimarySiteFlag;
			ListYesNoType _BillToFlag = BillToFlag;
			ListYesNoType _AddressChanged = AddressChanged;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerPortalCreateCustomerShipToSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostalCode", _PostalCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerSlsman", _ResellerSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToContactName", _ShipToContactName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToContactPhone", _ShipToContactPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToContactFax", _ShipToContactFax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToContactEmail", _ShipToContactEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrimarySiteFlag", _PrimarySiteFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillToFlag", _BillToFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddressChanged", _AddressChanged, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustSeq = _CustSeq;
				Infobar = _Infobar;
				
				return (Severity, CustSeq, Infobar);
			}
		}
	}
}
