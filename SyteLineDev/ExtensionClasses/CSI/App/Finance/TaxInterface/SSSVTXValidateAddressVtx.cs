//PROJECT NAME: Finance
//CLASS NAME: SSSVTXValidateAddressVtx.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXValidateAddressVtx : ISSSVTXValidateAddressVtx
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXValidateAddressVtx(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ioGeo,
			int? oValid,
			string Infobar) SSSVTXValidateAddressVtxSp(
			string ioGeo,
			string iState,
			string iCity,
			string iZip,
			string iCnty,
			string iCountry,
			int? oValid,
			string Infobar)
		{
			VTXTXWGeoCodeType _ioGeo = ioGeo;
			StateType _iState = iState;
			CityType _iCity = iCity;
			PostalCodeType _iZip = iZip;
			CountyType _iCnty = iCnty;
			CountryType _iCountry = iCountry;
			ByteType _oValid = oValid;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXValidateAddressVtxSp";
				
				appDB.AddCommandParameter(cmd, "ioGeo", _ioGeo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iState", _iState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCity", _iCity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iZip", _iZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCnty", _iCnty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCountry", _iCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oValid", _oValid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ioGeo = _ioGeo;
				oValid = _oValid;
				Infobar = _Infobar;
				
				return (Severity, ioGeo, oValid, Infobar);
			}
		}
	}
}
