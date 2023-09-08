//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferOrderReceivingList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TransferOrderReceivingList : IRpt_TransferOrderReceivingList
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TransferOrderReceivingList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransferOrderReceivingListSp(string ExOptprRecvTrans = null,
		int? ExOptprPostRcpts = null,
		DateTime? ExOptprPostDate = null,
		int? ExOptprPrintBc = null,
		int? ExOptprPrSerialNumbers = null,
		int? DateStarting = null,
		int? DisplayHeader = null,
		decimal? UserId = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null)
		{
			TrnNumType _ExOptprRecvTrans = ExOptprRecvTrans;
			ListYesNoType _ExOptprPostRcpts = ExOptprPostRcpts;
			DateType _ExOptprPostDate = ExOptprPostDate;
			ListYesNoType _ExOptprPrintBc = ExOptprPrintBc;
			ListYesNoType _ExOptprPrSerialNumbers = ExOptprPrSerialNumbers;
			DateOffsetType _DateStarting = DateStarting;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TokenType _UserId = UserId;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TransferOrderReceivingListSp";
				
				appDB.AddCommandParameter(cmd, "ExOptprRecvTrans", _ExOptprRecvTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostRcpts", _ExOptprPostRcpts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostDate", _ExOptprPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPrintBc", _ExOptprPrintBc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPrSerialNumbers", _ExOptprPrSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStarting", _DateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
