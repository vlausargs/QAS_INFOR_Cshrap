//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PastDueJobs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PastDueJobs : IRpt_PastDueJobs
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PastDueJobs(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PastDueJobsSp(DateTime? ExOptprPastDueDate = null,
		string JobStarting = null,
		int? JobStartSuffix = null,
		string JobEnding = null,
		int? JobEndSuffix = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustStarting = null,
		string CustEnding = null,
		string ExOptgoOrdType = null,
		string OrdNumStarting = null,
		string OrdNumEnding = null,
		DateTime? LstTrxDateStarting = null,
		DateTime? LstTrxDateEnding = null,
		DateTime? JobDateStarting = null,
		DateTime? JobDateEnding = null,
		int? LstTrxDateStartingOffset = null,
		int? LstTrxDateEndingOffset = null,
		int? JobDateStartingOffset = null,
		int? JobDateEndingOffset = null,
		int? ExOptprPastDueDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			DateType _ExOptprPastDueDate = ExOptprPastDueDate;
			JobType _JobStarting = JobStarting;
			SuffixType _JobStartSuffix = JobStartSuffix;
			JobType _JobEnding = JobEnding;
			SuffixType _JobEndSuffix = JobEndSuffix;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			CustNumType _CustStarting = CustStarting;
			CustNumType _CustEnding = CustEnding;
			RefTypeIKOTType _ExOptgoOrdType = ExOptgoOrdType;
			CoProjTrnNumType _OrdNumStarting = OrdNumStarting;
			CoProjTrnNumType _OrdNumEnding = OrdNumEnding;
			DateType _LstTrxDateStarting = LstTrxDateStarting;
			DateType _LstTrxDateEnding = LstTrxDateEnding;
			DateType _JobDateStarting = JobDateStarting;
			DateType _JobDateEnding = JobDateEnding;
			DateOffsetType _LstTrxDateStartingOffset = LstTrxDateStartingOffset;
			DateOffsetType _LstTrxDateEndingOffset = LstTrxDateEndingOffset;
			DateOffsetType _JobDateStartingOffset = JobDateStartingOffset;
			DateOffsetType _JobDateEndingOffset = JobDateEndingOffset;
			DateOffsetType _ExOptprPastDueDateOffset = ExOptprPastDueDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PastDueJobsSp";
				
				appDB.AddCommandParameter(cmd, "ExOptprPastDueDate", _ExOptprPastDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStartSuffix", _JobStartSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEndSuffix", _JobEndSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustStarting", _CustStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustEnding", _CustEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoOrdType", _ExOptgoOrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNumStarting", _OrdNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNumEnding", _OrdNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LstTrxDateStarting", _LstTrxDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LstTrxDateEnding", _LstTrxDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateStarting", _JobDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateEnding", _JobDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LstTrxDateStartingOffset", _LstTrxDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LstTrxDateEndingOffset", _LstTrxDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateStartingOffset", _JobDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateEndingOffset", _JobDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPastDueDateOffset", _ExOptprPastDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
