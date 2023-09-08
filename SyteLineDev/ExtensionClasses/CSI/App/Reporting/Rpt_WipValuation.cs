//PROJECT NAME: Reporting
//CLASS NAME: Rpt_WipValuation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_WipValuation : IRpt_WipValuation
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_WipValuation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_WipValuationSp(string PStartingProdCode = null,
		string PEndingProdCode = null,
		string PStartingItem = null,
		string PEndingItem = null,
		string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingSubJob = null,
		int? PEndingSubJob = null,
		string PJobStatus = "RSC",
		int? PShowDetail = 0,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			ProductCodeType _PStartingProdCode = PStartingProdCode;
			ProductCodeType _PEndingProdCode = PEndingProdCode;
			ItemType _PStartingItem = PStartingItem;
			ItemType _PEndingItem = PEndingItem;
			JobType _PStartingJob = PStartingJob;
			JobType _PEndingJob = PEndingJob;
			SuffixType _PStartingSubJob = PStartingSubJob;
			SuffixType _PEndingSubJob = PEndingSubJob;
			Infobar _PJobStatus = PJobStatus;
			ListYesNoType _PShowDetail = PShowDetail;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_WipValuationSp";
				
				appDB.AddCommandParameter(cmd, "PStartingProdCode", _PStartingProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingProdCode", _PEndingProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingItem", _PStartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingItem", _PEndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingJob", _PStartingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJob", _PEndingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingSubJob", _PStartingSubJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingSubJob", _PEndingSubJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobStatus", _PJobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowDetail", _PShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
