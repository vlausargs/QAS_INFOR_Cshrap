//PROJECT NAME: Finance
//CLASS NAME: SSSVTXValidateAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXValidateAddress : ISSSVTXValidateAddress
	{
		readonly IApplicationDB appDB;
		
		
		public SSSVTXValidateAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ioGeo,
		string iState,
		string iCity,
		string iZip,
		string iCnty,
		string iCountry,
		string iAddr1,
		string iAddr2,
		string iAddr3,
		string iAddr4,
		int? oValid,
		string Infobar) SSSVTXValidateAddressSp(int? iUpdateRecord,
		string iCustNum,
		int? iCustSeq,
		string ioGeo,
		string iState,
		string iCity,
		string iZip,
		string iCnty,
		string iCountry,
		string iAddr1,
		string iAddr2,
		string iAddr3,
		string iAddr4,
		int? oValid,
		string iAddressType,
		string Infobar)
		{
			ListYesNoType _iUpdateRecord = iUpdateRecord;
			CustNumType _iCustNum = iCustNum;
			CustSeqType _iCustSeq = iCustSeq;
			VTXTXWGeoCodeType _ioGeo = ioGeo;
			StateType _iState = iState;
			CityType _iCity = iCity;
			PostalCodeType _iZip = iZip;
			CountyType _iCnty = iCnty;
			CountryType _iCountry = iCountry;
			AddressType _iAddr1 = iAddr1;
			AddressType _iAddr2 = iAddr2;
			AddressType _iAddr3 = iAddr3;
			AddressType _iAddr4 = iAddr4;
			ByteType _oValid = oValid;
			VTXAddressTypeType _iAddressType = iAddressType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXValidateAddressSp";
				
				appDB.AddCommandParameter(cmd, "iUpdateRecord", _iUpdateRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustNum", _iCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustSeq", _iCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ioGeo", _ioGeo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iState", _iState, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iCity", _iCity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iZip", _iZip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iCnty", _iCnty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iCountry", _iCountry, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iAddr1", _iAddr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iAddr2", _iAddr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iAddr3", _iAddr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iAddr4", _iAddr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oValid", _oValid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iAddressType", _iAddressType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ioGeo = _ioGeo;
				iState = _iState;
				iCity = _iCity;
				iZip = _iZip;
				iCnty = _iCnty;
				iCountry = _iCountry;
				iAddr1 = _iAddr1;
				iAddr2 = _iAddr2;
				iAddr3 = _iAddr3;
				iAddr4 = _iAddr4;
				oValid = _oValid;
				Infobar = _Infobar;
				
				return (Severity, ioGeo, iState, iCity, iZip, iCnty, iCountry, iAddr1, iAddr2, iAddr3, iAddr4, oValid, Infobar);
			}
		}
	}
}
