//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VerifyReportstoAccounts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VerifyReportstoAccounts : IRpt_VerifyReportstoAccounts
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VerifyReportstoAccounts(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VerifyReportstoAccountsSp(string AccountStarting = null,
		string AccountEnding = null,
		int? InvalidAccountsOnly = null,
		int? DisplayHeader = null,
		string PMessageLanguage = null,
		string BGSessionId = null,
		string pSite = null)
		{
			AcctType _AccountStarting = AccountStarting;
			AcctType _AccountEnding = AccountEnding;
			ListYesNoType _InvalidAccountsOnly = InvalidAccountsOnly;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VerifyReportstoAccountsSp";
				
				appDB.AddCommandParameter(cmd, "AccountStarting", _AccountStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountEnding", _AccountEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvalidAccountsOnly", _InvalidAccountsOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
