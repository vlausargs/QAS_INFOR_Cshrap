//PROJECT NAME: Reporting
//CLASS NAME: THARpt_PettyCash.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_PettyCash : ITHARpt_PettyCash
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_PettyCash(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_PettyCashSp(string StartingBankCode = null,
		string EndingBankCode = null,
		DateTime? StartingIssueDate = null,
		DateTime? EndingIssueDate = null,
		string StartingReference = null,
		string EndingReference = null,
		string pSite = null)
		{
			BankCodeType _StartingBankCode = StartingBankCode;
			BankCodeType _EndingBankCode = EndingBankCode;
			DateType _StartingIssueDate = StartingIssueDate;
			DateType _EndingIssueDate = EndingIssueDate;
			ReferenceType _StartingReference = StartingReference;
			ReferenceType _EndingReference = EndingReference;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_PettyCashSp";
				
				appDB.AddCommandParameter(cmd, "StartingBankCode", _StartingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingBankCode", _EndingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingIssueDate", _StartingIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingIssueDate", _EndingIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingReference", _StartingReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingReference", _EndingReference, ParameterDirection.Input);
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
