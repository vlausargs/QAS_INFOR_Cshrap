//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPAction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPAction : IRpt_RSQC_IPAction
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_IPAction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPActionSp(
			string begjob = null,
			string endjob = null,
			int? begsuffix = null,
			int? endsuffix = null,
			string begpsnum = null,
			string endpsnum = null,
			string JustJobs = null,
			int? ShowDetail = null,
			int? DisplayHeader = null)
		{
			JobType _begjob = begjob;
			JobType _endjob = endjob;
			SuffixType _begsuffix = begsuffix;
			SuffixType _endsuffix = endsuffix;
			PsNumType _begpsnum = begpsnum;
			PsNumType _endpsnum = endpsnum;
			StringType _JustJobs = JustJobs;
			ListYesNoType _ShowDetail = ShowDetail;
			ListYesNoType _DisplayHeader = DisplayHeader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_IPActionSp";
				
				appDB.AddCommandParameter(cmd, "begjob", _begjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endjob", _endjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begsuffix", _begsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endsuffix", _endsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begpsnum", _begpsnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endpsnum", _endpsnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JustJobs", _JustJobs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
