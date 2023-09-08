//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostVariance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobCostVariance : IRpt_JobCostVariance
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobCostVariance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobCostVarianceSp(string StartJob = null,
		string EndJob = null,
		int? SSuffix = null,
		int? ESuffix = null,
		string Status = null,
		string VarianceType = null,
		string StartItem = null,
		string EndItem = null,
		string SCustNum = null,
		string ECustNum = null,
		string SProdMix = null,
		string EProdMix = null,
		string OrdType = null,
		string SOrdNum = null,
		string EOrdNum = null,
		DateTime? SLstTrxDate = null,
		DateTime? ELstTrxDate = null,
		DateTime? StartJobDate = null,
		DateTime? EndJobDate = null,
		int? SLstTrxDateOffset = null,
		int? ELstTrxDateOffset = null,
		int? SJobDateOffset = null,
		int? EJobDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null,
		Guid? ProcessId = null)
		{
			JobType _StartJob = StartJob;
			JobType _EndJob = EndJob;
			SuffixType _SSuffix = SSuffix;
			SuffixType _ESuffix = ESuffix;
			InfobarType _Status = Status;
			InfobarType _VarianceType = VarianceType;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			CustNumType _SCustNum = SCustNum;
			CustNumType _ECustNum = ECustNum;
			ProdMixType _SProdMix = SProdMix;
			ProdMixType _EProdMix = EProdMix;
			RefTypeIKOTType _OrdType = OrdType;
			CoProjTrnNumType _SOrdNum = SOrdNum;
			CoProjTrnNumType _EOrdNum = EOrdNum;
			DateType _SLstTrxDate = SLstTrxDate;
			DateType _ELstTrxDate = ELstTrxDate;
			DateType _StartJobDate = StartJobDate;
			DateType _EndJobDate = EndJobDate;
			DateOffsetType _SLstTrxDateOffset = SLstTrxDateOffset;
			DateOffsetType _ELstTrxDateOffset = ELstTrxDateOffset;
			DateOffsetType _SJobDateOffset = SJobDateOffset;
			DateOffsetType _EJobDateOffset = EJobDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			RowPointerType _ProcessId = ProcessId;

			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobCostVarianceSp";
				
				appDB.AddCommandParameter(cmd, "StartJob", _StartJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSuffix", _SSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ESuffix", _ESuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VarianceType", _VarianceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCustNum", _SCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECustNum", _ECustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SProdMix", _SProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EProdMix", _EProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SOrdNum", _SOrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EOrdNum", _EOrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLstTrxDate", _SLstTrxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELstTrxDate", _ELstTrxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJobDate", _StartJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJobDate", _EndJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLstTrxDateOffset", _SLstTrxDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELstTrxDateOffset", _ELstTrxDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobDateOffset", _SJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EJobDateOffset", _EJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);

				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);

				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();

				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
