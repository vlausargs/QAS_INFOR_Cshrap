//PROJECT NAME: Finance
//CLASS NAME: SSSVTXGetJurisCd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXGetJurisCd : ISSSVTXGetJurisCd
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXGetJurisCd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? oJurisCd,
			string Infobar) SSSVTXGetJurisCdSp(
			int? pGeo,
			string pState,
			string pCity,
			string pZip,
			string pCnty,
			int? oJurisCd,
			string Infobar)
		{
			IntType _pGeo = pGeo;
			StateType _pState = pState;
			CityType _pCity = pCity;
			PostalCodeType _pZip = pZip;
			CountyType _pCnty = pCnty;
			IntType _oJurisCd = oJurisCd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXGetJurisCdSp";
				
				appDB.AddCommandParameter(cmd, "pGeo", _pGeo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pState", _pState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCity", _pCity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pZip", _pZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCnty", _pCnty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oJurisCd", _oJurisCd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oJurisCd = _oJurisCd;
				Infobar = _Infobar;
				
				return (Severity, oJurisCd, Infobar);
			}
		}
	}
}
