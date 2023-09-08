//PROJECT NAME: Finance
//CLASS NAME: SSSVTXGetECCountry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXGetECCountry : ISSSVTXGetECCountry
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXGetECCountry(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSVTXGetECCountryFn(
			string Country)
		{
			CountryType _Country = Country;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSVTXGetECCountry](@Country)";
				
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
