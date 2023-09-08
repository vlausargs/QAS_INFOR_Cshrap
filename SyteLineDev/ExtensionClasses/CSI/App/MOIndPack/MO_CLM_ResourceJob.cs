//PROJECT NAME: MOIndPack
//CLASS NAME: MO_CLM_ResourceJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MOIndPack
{
	public class MO_CLM_ResourceJob : IMO_CLM_ResourceJob
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MO_CLM_ResourceJob(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) MO_CLM_ResourceJobSp(string BOMType,
		string CoJob,
		string ProdMix,
		string RESID,
		int? DeleteFlag,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				MO_JobConfigTypeType _BOMType = BOMType;
				JobType _CoJob = CoJob;
				ProdMixType _ProdMix = ProdMix;
				ApsResourceType _RESID = RESID;
				ListYesNoType _DeleteFlag = DeleteFlag;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "MO_CLM_ResourceJobSp";
					
					appDB.AddCommandParameter(cmd, "BOMType", _BOMType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoJob", _CoJob, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ProdMix", _ProdMix, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DeleteFlag", _DeleteFlag, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
