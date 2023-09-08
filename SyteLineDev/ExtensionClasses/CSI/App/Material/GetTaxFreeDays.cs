//PROJECT NAME: Material
//CLASS NAME: GetTaxFreeDays.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetTaxFreeDays : IGetTaxFreeDays
	{
		readonly IApplicationDB appDB;
		
		
		public GetTaxFreeDays(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TaxFreeDays) GetTaxFreeDaysSp(string ProdCode,
		int? TaxFreeDays,
		string PSite = null)
		{
			ProductCodeType _ProdCode = ProdCode;
			TaxFreeDaysType _TaxFreeDays = TaxFreeDays;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTaxFreeDaysSp";
				
				appDB.AddCommandParameter(cmd, "ProdCode", _ProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxFreeDays", _TaxFreeDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxFreeDays = _TaxFreeDays;
				
				return (Severity, TaxFreeDays);
			}
		}
	}
}
