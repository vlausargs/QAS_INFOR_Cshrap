//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostDetailStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobCostDetailStatus : IRpt_JobCostDetailStatus
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobCostDetailStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobCostDetailStatusSp(string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingSubJob = null,
		int? PEndingSubJob = null,
		string PJobStatus = null,
		string PCostComponent = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PStartingItem = null,
		string PEndingItem = null,
		string PStartingProdMix = null,
		string PEndingProdMix = null,
		string POrderType = null,
		string PStartingOrderNum = null,
		string PEndingOrderNum = null,
		DateTime? PStartingTrxDate = null,
		DateTime? PEndingTrxDate = null,
		DateTime? PStartingJobDate = null,
		DateTime? PEndingJobDate = null,
		int? PStartingTrxDateOffset = null,
		int? PEndingTrxDateOffset = null,
		int? PStartingJobDateOffset = null,
		int? PEndingJobDateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			JobType _PStartingJob = PStartingJob;
			JobType _PEndingJob = PEndingJob;
			IntType _PStartingSubJob = PStartingSubJob;
			IntType _PEndingSubJob = PEndingSubJob;
			Infobar _PJobStatus = PJobStatus;
			Infobar _PCostComponent = PCostComponent;
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			ItemType _PStartingItem = PStartingItem;
			ItemType _PEndingItem = PEndingItem;
			ProdMixType _PStartingProdMix = PStartingProdMix;
			ProdMixType _PEndingProdMix = PEndingProdMix;
			RefTypeIKOTType _POrderType = POrderType;
			CoProjTrnNumType _PStartingOrderNum = PStartingOrderNum;
			CoProjTrnNumType _PEndingOrderNum = PEndingOrderNum;
			DateType _PStartingTrxDate = PStartingTrxDate;
			DateType _PEndingTrxDate = PEndingTrxDate;
			DateType _PStartingJobDate = PStartingJobDate;
			DateType _PEndingJobDate = PEndingJobDate;
			DateOffsetType _PStartingTrxDateOffset = PStartingTrxDateOffset;
			DateOffsetType _PEndingTrxDateOffset = PEndingTrxDateOffset;
			DateOffsetType _PStartingJobDateOffset = PStartingJobDateOffset;
			DateOffsetType _PEndingJobDateOffset = PEndingJobDateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobCostDetailStatusSp";
				
				appDB.AddCommandParameter(cmd, "PStartingJob", _PStartingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJob", _PEndingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingSubJob", _PStartingSubJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingSubJob", _PEndingSubJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobStatus", _PJobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostComponent", _PCostComponent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingItem", _PStartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingItem", _PEndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingProdMix", _PStartingProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingProdMix", _PEndingProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderType", _POrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingOrderNum", _PStartingOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingOrderNum", _PEndingOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingTrxDate", _PStartingTrxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingTrxDate", _PEndingTrxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingJobDate", _PStartingJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJobDate", _PEndingJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingTrxDateOffset", _PStartingTrxDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingTrxDateOffset", _PEndingTrxDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingJobDateOffset", _PStartingJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJobDateOffset", _PEndingJobDateOffset, ParameterDirection.Input);
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
