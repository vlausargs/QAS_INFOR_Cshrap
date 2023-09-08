//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostDetailBreakout.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobCostDetailBreakout : IRpt_JobCostDetailBreakout
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobCostDetailBreakout(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobCostDetailBreakoutSp(string JobStarting = null,
		int? JobStartSuffix = null,
		string JobEnding = null,
		int? JobEndSuffix = null,
		string ExOptgoJJobStat = null,
		string ExOptacCostComponent = null,
		string CustStarting = null,
		string CustEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
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
		int? DisplayHeader = null,
		string pSite = null)
		{
			JobType _JobStarting = JobStarting;
			SuffixType _JobStartSuffix = JobStartSuffix;
			JobType _JobEnding = JobEnding;
			SuffixType _JobEndSuffix = JobEndSuffix;
			InfobarType _ExOptgoJJobStat = ExOptgoJJobStat;
			StringType _ExOptacCostComponent = ExOptacCostComponent;
			CustNumType _CustStarting = CustStarting;
			CustNumType _CustEnding = CustEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
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
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobCostDetailBreakoutSp";
				
				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStartSuffix", _JobStartSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEndSuffix", _JobEndSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoJJobStat", _ExOptgoJJobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacCostComponent", _ExOptacCostComponent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustStarting", _CustStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustEnding", _CustEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
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
