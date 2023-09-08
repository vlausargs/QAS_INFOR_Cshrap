//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ConsolidatedJobCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ConsolidatedJobCost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ConsolidatedJobCostSp(string PrimeJob = null,
		short? JobSuffixStarting = null,
		short? JobSuffixEnding = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_ConsolidatedJobCost : IRpt_ConsolidatedJobCost
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ConsolidatedJobCost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ConsolidatedJobCostSp(string PrimeJob = null,
		short? JobSuffixStarting = null,
		short? JobSuffixEnding = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			JobType _PrimeJob = PrimeJob;
			SuffixType _JobSuffixStarting = JobSuffixStarting;
			SuffixType _JobSuffixEnding = JobSuffixEnding;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ConsolidatedJobCostSp";
				
				appDB.AddCommandParameter(cmd, "PrimeJob", _PrimeJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffixStarting", _JobSuffixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffixEnding", _JobSuffixEnding, ParameterDirection.Input);
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
