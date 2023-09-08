//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConsumerUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConsumerUpdate : ISSSFSUnitConsumerUpdate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitConsumerUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSUnitConsumerUpdateSp(
			string SerNum,
			string Item,
			string CustNum,
			int? CustSeq,
			string UsrNum,
			int? UsrSeq,
			int? MeterAmt,
			int? CustLookup = 1,
			string Name = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			string City = null,
			string State = null,
			string Zip = null,
			string County = null,
			string Country = null,
			string Contact = null,
			string Email = null,
			string Phone = null,
			string FaxNum = null,
			int? BufferMode = 0)
		{
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			FSUsrNumType _UsrNum = UsrNum;
			FSUsrSeqType _UsrSeq = UsrSeq;
			FSMeterAmtType _MeterAmt = MeterAmt;
			ListYesNoType _CustLookup = CustLookup;
			NameType _Name = Name;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountyType _County = County;
			CountryType _Country = Country;
			ContactType _Contact = Contact;
			EmailType _Email = Email;
			PhoneType _Phone = Phone;
			PhoneType _FaxNum = FaxNum;
			ListYesNoType _BufferMode = BufferMode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitConsumerUpdateSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MeterAmt", _MeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustLookup", _CustLookup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BufferMode", _BufferMode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
