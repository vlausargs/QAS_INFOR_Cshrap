//PROJECT NAME: Logistics
//CLASS NAME: GetPoDropShipData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetPoDropShipData : IGetPoDropShipData
	{
		readonly IApplicationDB appDB;
		
		
		public GetPoDropShipData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DropShipName,
		string DropShipAddr1,
		string DropShipAddr2,
		string DropShipAddr3,
		string DropShipAddr4,
		string DropShipCity,
		string DropShipState,
		string DropShipCounty,
		string DropShipCountry,
		string DropShipZip,
		string DropShipContact,
		string DropShipPhone,
		string DropShipFaxNum,
		string DropShipExtEmail,
		string Infobar) GetPoDropShipDataSp(string PoDropShipNo,
		int? PoDropSeq,
		string PoShipAddr,
		string DropShipName,
		string DropShipAddr1,
		string DropShipAddr2,
		string DropShipAddr3,
		string DropShipAddr4,
		string DropShipCity,
		string DropShipState,
		string DropShipCounty,
		string DropShipCountry,
		string DropShipZip,
		string DropShipContact,
		string DropShipPhone,
		string DropShipFaxNum,
		string DropShipExtEmail,
		string Infobar)
		{
			DropShipNoType _PoDropShipNo = PoDropShipNo;
			DropSeqType _PoDropSeq = PoDropSeq;
			DropShipTypeType _PoShipAddr = PoShipAddr;
			NameType _DropShipName = DropShipName;
			AddressType _DropShipAddr1 = DropShipAddr1;
			AddressType _DropShipAddr2 = DropShipAddr2;
			AddressType _DropShipAddr3 = DropShipAddr3;
			AddressType _DropShipAddr4 = DropShipAddr4;
			CityType _DropShipCity = DropShipCity;
			StateType _DropShipState = DropShipState;
			CountyType _DropShipCounty = DropShipCounty;
			CountryType _DropShipCountry = DropShipCountry;
			PostalCodeType _DropShipZip = DropShipZip;
			ContactType _DropShipContact = DropShipContact;
			PhoneType _DropShipPhone = DropShipPhone;
			PhoneType _DropShipFaxNum = DropShipFaxNum;
			EmailType _DropShipExtEmail = DropShipExtEmail;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPoDropShipDataSp";
				
				appDB.AddCommandParameter(cmd, "PoDropShipNo", _PoDropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoDropSeq", _PoDropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoShipAddr", _PoShipAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropShipName", _DropShipName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipAddr1", _DropShipAddr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipAddr2", _DropShipAddr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipAddr3", _DropShipAddr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipAddr4", _DropShipAddr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipCity", _DropShipCity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipState", _DropShipState, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipCounty", _DropShipCounty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipCountry", _DropShipCountry, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipZip", _DropShipZip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipContact", _DropShipContact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipPhone", _DropShipPhone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipFaxNum", _DropShipFaxNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropShipExtEmail", _DropShipExtEmail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DropShipName = _DropShipName;
				DropShipAddr1 = _DropShipAddr1;
				DropShipAddr2 = _DropShipAddr2;
				DropShipAddr3 = _DropShipAddr3;
				DropShipAddr4 = _DropShipAddr4;
				DropShipCity = _DropShipCity;
				DropShipState = _DropShipState;
				DropShipCounty = _DropShipCounty;
				DropShipCountry = _DropShipCountry;
				DropShipZip = _DropShipZip;
				DropShipContact = _DropShipContact;
				DropShipPhone = _DropShipPhone;
				DropShipFaxNum = _DropShipFaxNum;
				DropShipExtEmail = _DropShipExtEmail;
				Infobar = _Infobar;
				
				return (Severity, DropShipName, DropShipAddr1, DropShipAddr2, DropShipAddr3, DropShipAddr4, DropShipCity, DropShipState, DropShipCounty, DropShipCountry, DropShipZip, DropShipContact, DropShipPhone, DropShipFaxNum, DropShipExtEmail, Infobar);
			}
		}
	}
}
