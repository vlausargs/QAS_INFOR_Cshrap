//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobTickets.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobTickets : IRpt_JobTickets
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobTickets(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobTicketsSp(string StartJob = null,
		string EndJob = null,
		int? StartSuffix = null,
		int? EndSuffix = null,
		string JobStat = null,
		string StartItem = null,
		string EndItem = null,
		string StartProdMix = null,
		string EndProdMix = null,
		DateTime? StartJobDate = null,
		DateTime? EndJobDate = null,
		int? JobTickets132 = null,
		int? NumTickets = null,
		int? StartJobDateOffset = null,
		int? EndJobDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			JobType _StartJob = StartJob;
			JobType _EndJob = EndJob;
			SuffixType _StartSuffix = StartSuffix;
			SuffixType _EndSuffix = EndSuffix;
			StringType _JobStat = JobStat;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			ProdMixType _StartProdMix = StartProdMix;
			ProdMixType _EndProdMix = EndProdMix;
			GenericDateType _StartJobDate = StartJobDate;
			GenericDateType _EndJobDate = EndJobDate;
			ListYesNoType _JobTickets132 = JobTickets132;
			IntType _NumTickets = NumTickets;
			DateOffsetType _StartJobDateOffset = StartJobDateOffset;
			DateOffsetType _EndJobDateOffset = EndJobDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobTicketsSp";
				
				appDB.AddCommandParameter(cmd, "StartJob", _StartJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSuffix", _StartSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSuffix", _EndSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStat", _JobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartProdMix", _StartProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProdMix", _EndProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJobDate", _StartJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJobDate", _EndJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobTickets132", _JobTickets132, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumTickets", _NumTickets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJobDateOffset", _StartJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJobDateOffset", _EndJobDateOffset, ParameterDirection.Input);
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
