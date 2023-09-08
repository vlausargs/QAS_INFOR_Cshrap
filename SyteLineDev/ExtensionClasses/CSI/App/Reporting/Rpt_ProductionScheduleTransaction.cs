//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleTransaction : IRpt_ProductionScheduleTransaction
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProductionScheduleTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleTransactionSp(string PSNumStarting = null,
		string PSNumEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string WcStarting = null,
		string WcEnding = null,
		string ShiftStarting = null,
		string ShiftEnding = null,
		DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		int? TransDateStartingOffset = null,
		int? TransDateEndingOffset = null,
		string BackFlushTrans = null,
		int? CompleteStatusReport = null,
		int? DisplayHeader = null,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null)
		{
			PsNumType _PSNumStarting = PSNumStarting;
			PsNumType _PSNumEnding = PSNumEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			WcType _WcStarting = WcStarting;
			WcType _WcEnding = WcEnding;
			ShiftType _ShiftStarting = ShiftStarting;
			ShiftType _ShiftEnding = ShiftEnding;
			DateType _TransDateStarting = TransDateStarting;
			DateType _TransDateEnding = TransDateEnding;
			DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
			DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
			StringType _BackFlushTrans = BackFlushTrans;
			ListYesNoType _CompleteStatusReport = CompleteStatusReport;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			DocumentNumType _DocumentNumStarting = DocumentNumStarting;
			DocumentNumType _DocumentNumEnding = DocumentNumEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductionScheduleTransactionSp";
				
				appDB.AddCommandParameter(cmd, "PSNumStarting", _PSNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSNumEnding", _PSNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WcStarting", _WcStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WcEnding", _WcEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiftStarting", _ShiftStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiftEnding", _ShiftEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackFlushTrans", _BackFlushTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompleteStatusReport", _CompleteStatusReport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumStarting", _DocumentNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumEnding", _DocumentNumEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
