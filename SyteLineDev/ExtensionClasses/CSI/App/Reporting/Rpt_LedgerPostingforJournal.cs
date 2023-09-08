//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LedgerPostingforJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_LedgerPostingforJournal : IRpt_LedgerPostingforJournal
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_LedgerPostingforJournal(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_LedgerPostingforJournalSp(string pSessionIDChar = null,
		string pCurId = null,
		int? pSingleDate = null,
		DateTime? pDateForTrans = null,
		DateTime? pPostThroughDate = null,
		string StartingGLVoucher = null,
		string EndingGLVoucher = null,
		string pSite = null)
		{
			StringType _pSessionIDChar = pSessionIDChar;
			JournalIdType _pCurId = pCurId;
			ListYesNoType _pSingleDate = pSingleDate;
			DateType _pDateForTrans = pDateForTrans;
			DateType _pPostThroughDate = pPostThroughDate;
			InvNumVoucherType _StartingGLVoucher = StartingGLVoucher;
			InvNumVoucherType _EndingGLVoucher = EndingGLVoucher;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_LedgerPostingforJournalSp";
				
				appDB.AddCommandParameter(cmd, "pSessionIDChar", _pSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurId", _pCurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSingleDate", _pSingleDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDateForTrans", _pDateForTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostThroughDate", _pPostThroughDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingGLVoucher", _StartingGLVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingGLVoucher", _EndingGLVoucher, ParameterDirection.Input);
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
