//PROJECT NAME: Codes
//CLASS NAME: GetTaxRegNumReturnSubmissionSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetTaxRegNumReturnSubmissionSite : IGetTaxRegNumReturnSubmissionSite
	{
		readonly IApplicationDB appDB;
		
		
		public GetTaxRegNumReturnSubmissionSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TaxRegNumReturnSubmissionSite) GetTaxRegNumReturnSubmissionSiteSp(string Site,
		string TaxRegNumReturnSubmissionSite)
		{
			SiteType _Site = Site;
			TaxRegNumType _TaxRegNumReturnSubmissionSite = TaxRegNumReturnSubmissionSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTaxRegNumReturnSubmissionSiteSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxRegNumReturnSubmissionSite", _TaxRegNumReturnSubmissionSite, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxRegNumReturnSubmissionSite = _TaxRegNumReturnSubmissionSite;
				
				return (Severity, TaxRegNumReturnSubmissionSite);
			}
		}
	}
}
