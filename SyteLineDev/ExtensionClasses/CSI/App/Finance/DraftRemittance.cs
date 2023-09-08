//PROJECT NAME: Finance
//CLASS NAME: DraftRemittance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class DraftRemittance : IDraftRemittance
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public DraftRemittance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) DraftRemittanceSp(string RemOption = null,
		string BankCodeStarting = null,
		string BankCodeEnding = null,
		int? StartDraftNumber = null,
		int? EndDraftNumber = null)
		{
			StringType _RemOption = RemOption;
			BankCodeType _BankCodeStarting = BankCodeStarting;
			BankCodeType _BankCodeEnding = BankCodeEnding;
			DraftNumType _StartDraftNumber = StartDraftNumber;
			DraftNumType _EndDraftNumber = EndDraftNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DraftRemittanceSp";
				
				appDB.AddCommandParameter(cmd, "RemOption", _RemOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCodeStarting", _BankCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCodeEnding", _BankCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDraftNumber", _StartDraftNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDraftNumber", _EndDraftNumber, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
