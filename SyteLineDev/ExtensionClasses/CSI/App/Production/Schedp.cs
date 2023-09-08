//PROJECT NAME: Production
//CLASS NAME: Schedp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Schedp : ISchedp
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Schedp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SchedpSp(string pType,
		string pStatus,
		string pUseCr,
		string pStartingJobNum,
		string pEndingJobNum,
		int? pStartingSuffixNum,
		int? pEndingSuffixNum)
		{
			StringType _pType = pType;
			StringType _pStatus = pStatus;
			StringType _pUseCr = pUseCr;
			JobType _pStartingJobNum = pStartingJobNum;
			JobType _pEndingJobNum = pEndingJobNum;
			SuffixType _pStartingSuffixNum = pStartingSuffixNum;
			SuffixType _pEndingSuffixNum = pEndingSuffixNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SchedpSp";
				
				appDB.AddCommandParameter(cmd, "pType", _pType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStatus", _pStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseCr", _pUseCr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingJobNum", _pStartingJobNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingJobNum", _pEndingJobNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingSuffixNum", _pStartingSuffixNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingSuffixNum", _pEndingSuffixNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
