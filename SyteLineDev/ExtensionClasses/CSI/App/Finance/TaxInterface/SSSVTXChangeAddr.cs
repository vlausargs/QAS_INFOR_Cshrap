//PROJECT NAME: Finance
//CLASS NAME: SSSVTXChangeAddr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXChangeAddr : ISSSVTXChangeAddr
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXChangeAddr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ioGeo,
			string ioState,
			string ioCity,
			string ioZip,
			string ioCnty,
			string ioCountry,
			string Infobar) SSSVTXChangeAddrSp(
			int? ioGeo,
			string ioState,
			string ioCity,
			string ioZip,
			string ioCnty,
			string ioCountry,
			string Infobar)
		{
			VTXSgeoType _ioGeo = ioGeo;
			StateType _ioState = ioState;
			CityType _ioCity = ioCity;
			PostalCodeType _ioZip = ioZip;
			CountyType _ioCnty = ioCnty;
			CountryType _ioCountry = ioCountry;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXChangeAddrSp";
				
				appDB.AddCommandParameter(cmd, "ioGeo", _ioGeo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ioState", _ioState, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ioCity", _ioCity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ioZip", _ioZip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ioCnty", _ioCnty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ioCountry", _ioCountry, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ioGeo = _ioGeo;
				ioState = _ioState;
				ioCity = _ioCity;
				ioZip = _ioZip;
				ioCnty = _ioCnty;
				ioCountry = _ioCountry;
				Infobar = _Infobar;
				
				return (Severity, ioGeo, ioState, ioCity, ioZip, ioCnty, ioCountry, Infobar);
			}
		}
	}
}
