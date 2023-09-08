//PROJECT NAME: Codes
//CLASS NAME: GetTaxCodeDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetTaxCodeDefaults : IGetTaxCodeDefaults
	{
		readonly IApplicationDB appDB;
		
		
		public GetTaxCodeDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TaxCode1,
		string TaxCode2,
		int? TaxCodeFound,
		string Infobar) GetTaxCodeDefaultsSp(string Country = null,
		string State = null,
		string Zip = null,
		string TaxCode1 = null,
		string TaxCode2 = null,
		int? TaxCodeFound = 0,
		string Infobar = null)
		{
			CountryType _Country = Country;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			ListYesNoType _TaxCodeFound = TaxCodeFound;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTaxCodeDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCodeFound", _TaxCodeFound, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				TaxCodeFound = _TaxCodeFound;
				Infobar = _Infobar;
				
				return (Severity, TaxCode1, TaxCode2, TaxCodeFound, Infobar);
			}
		}
	}
}
