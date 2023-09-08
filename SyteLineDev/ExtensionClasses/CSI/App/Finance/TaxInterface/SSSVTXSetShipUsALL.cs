//PROJECT NAME: Finance
//CLASS NAME: SSSVTXSetShipUsALL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXSetShipUsALL : ISSSVTXSetShipUsALL
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXSetShipUsALL(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? oJurisCd,
			int? oGeo,
			string oState,
			string oCity,
			string oZip,
			string oCnty,
			string oCountry,
			string oAddr1,
			string oAddr2,
			string oAddr3,
			string oAddr4,
			string Infobar) SSSVTXSetShipUsALLSp(
			string iWhse,
			int? oJurisCd,
			int? oGeo,
			string oState,
			string oCity,
			string oZip,
			string oCnty,
			string oCountry,
			string oAddr1,
			string oAddr2,
			string oAddr3,
			string oAddr4,
			string Infobar)
		{
			WhseType _iWhse = iWhse;
			VTXStJurisInCityType _oJurisCd = oJurisCd;
			VTXSgeoType _oGeo = oGeo;
			StateType _oState = oState;
			CityType _oCity = oCity;
			PostalCodeType _oZip = oZip;
			CountyType _oCnty = oCnty;
			CountryType _oCountry = oCountry;
			AddressType _oAddr1 = oAddr1;
			AddressType _oAddr2 = oAddr2;
			AddressType _oAddr3 = oAddr3;
			AddressType _oAddr4 = oAddr4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXSetShipUsALLSp";
				
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oJurisCd", _oJurisCd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oGeo", _oGeo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oState", _oState, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCity", _oCity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oZip", _oZip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCnty", _oCnty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCountry", _oCountry, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oAddr1", _oAddr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oAddr2", _oAddr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oAddr3", _oAddr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oAddr4", _oAddr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oJurisCd = _oJurisCd;
				oGeo = _oGeo;
				oState = _oState;
				oCity = _oCity;
				oZip = _oZip;
				oCnty = _oCnty;
				oCountry = _oCountry;
				oAddr1 = _oAddr1;
				oAddr2 = _oAddr2;
				oAddr3 = _oAddr3;
				oAddr4 = _oAddr4;
				Infobar = _Infobar;
				
				return (Severity, oJurisCd, oGeo, oState, oCity, oZip, oCnty, oCountry, oAddr1, oAddr2, oAddr3, oAddr4, Infobar);
			}
		}
	}
}
