//PROJECT NAME: Finance
//CLASS NAME: FinRptAcctCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptAcctCheck : IFinRptAcctCheck
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public FinRptAcctCheck(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) FinRptAcctCheckSp(string ReportId,
		int? StartSeq,
		int? EndSeq,
		string StartAcct,
		string EndAcct,
		string AccountTypes,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RptIdType _ReportId = ReportId;
				FinStmtSeqType _StartSeq = StartSeq;
				FinStmtSeqType _EndSeq = EndSeq;
				AcctType _StartAcct = StartAcct;
				AcctType _EndAcct = EndAcct;
				StringType _AccountTypes = AccountTypes;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "FinRptAcctCheckSp";
					
					appDB.AddCommandParameter(cmd, "ReportId", _ReportId, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartSeq", _StartSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndSeq", _EndSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartAcct", _StartAcct, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndAcct", _EndAcct, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AccountTypes", _AccountTypes, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
