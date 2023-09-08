//PROJECT NAME: Finance
//CLASS NAME: SSSVTXCustIntlTaxCodeDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXCustIntlTaxCodeDefault : ISSSVTXCustIntlTaxCodeDefault
	{
		readonly IApplicationDB appDB;
		
		
		public SSSVTXCustIntlTaxCodeDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TaxCode1) SSSVTXCustIntlTaxCodeDefaultSp(string Country,
		string TaxCode1)
		{
			CountryType _Country = Country;
			TaxCodeType _TaxCode1 = TaxCode1;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXCustIntlTaxCodeDefaultSp";
				
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxCode1 = _TaxCode1;
				
				return (Severity, TaxCode1);
			}
		}
	}
}
