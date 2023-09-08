//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobOperationStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobOperationStatus : IRpt_JobOperationStatus
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobOperationStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobOperationStatusSp(string JobStarting = null,
		string JobEnding = null,
		int? SuffixStarting = null,
		int? SuffixEnding = null,
		string JobStatus = null,
		string LbrMatlBoth = null,
		string CustNum = null,
		string CustPo = null,
		string CustItem = null,
		int? ControlPoint = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string OrdType = null,
		string OrdNumStarting = null,
		string OrdNumEnding = null,
		DateTime? LastTrxDateStarting = null,
		DateTime? LastTrxDateEnding = null,
		int? LastTrxDateStartingOffset = null,
		int? LastTrxDateEndingOffset = null,
		DateTime? JobDateStarting = null,
		DateTime? JobDateEnding = null,
		int? JobDateStartingOffset = null,
		int? JobDateEndingOffset = null,
		int? DisplayHeader = 1,
		string BGSessionId = null,
		string pSite = null)
		{
			JobType _JobStarting = JobStarting;
			JobType _JobEnding = JobEnding;
			SuffixType _SuffixStarting = SuffixStarting;
			SuffixType _SuffixEnding = SuffixEnding;
			InfobarType _JobStatus = JobStatus;
			StringType _LbrMatlBoth = LbrMatlBoth;
			CustNumType _CustNum = CustNum;
			CustPoType _CustPo = CustPo;
			CustItemType _CustItem = CustItem;
			FlagNyType _ControlPoint = ControlPoint;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			RefTypeIKOTType _OrdType = OrdType;
			CoProjTrnNumType _OrdNumStarting = OrdNumStarting;
			CoProjTrnNumType _OrdNumEnding = OrdNumEnding;
			DateType _LastTrxDateStarting = LastTrxDateStarting;
			DateType _LastTrxDateEnding = LastTrxDateEnding;
			DateOffsetType _LastTrxDateStartingOffset = LastTrxDateStartingOffset;
			DateOffsetType _LastTrxDateEndingOffset = LastTrxDateEndingOffset;
			DateType _JobDateStarting = JobDateStarting;
			DateType _JobDateEnding = JobDateEnding;
			DateOffsetType _JobDateStartingOffset = JobDateStartingOffset;
			DateOffsetType _JobDateEndingOffset = JobDateEndingOffset;
			FlagNyType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobOperationStatusSp";
				
				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixStarting", _SuffixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixEnding", _SuffixEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStatus", _JobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrMatlBoth", _LbrMatlBoth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPoint", _ControlPoint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNumStarting", _OrdNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNumEnding", _OrdNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTrxDateStarting", _LastTrxDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTrxDateEnding", _LastTrxDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTrxDateStartingOffset", _LastTrxDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTrxDateEndingOffset", _LastTrxDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateStarting", _JobDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateEnding", _JobDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateStartingOffset", _JobDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateEndingOffset", _JobDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
