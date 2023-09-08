//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JournalCompress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JournalCompress : IRpt_JournalCompress
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JournalCompress(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JournalCompressSp(string pSessionIDChar = null,
		string pCurId = null,
		DateTime? pTransDateEnd = null,
		int? pTransDateEndOffset = null,
		int? TaskId = null,
		string pSite = null)
		{
			StringType _pSessionIDChar = pSessionIDChar;
			JournalIdType _pCurId = pCurId;
			DateType _pTransDateEnd = pTransDateEnd;
			DateOffsetType _pTransDateEndOffset = pTransDateEndOffset;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JournalCompressSp";
				
				appDB.AddCommandParameter(cmd, "pSessionIDChar", _pSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurId", _pCurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDateEnd", _pTransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDateEndOffset", _pTransDateEndOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
