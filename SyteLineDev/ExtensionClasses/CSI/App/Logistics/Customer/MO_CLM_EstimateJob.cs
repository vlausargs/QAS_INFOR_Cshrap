//PROJECT NAME: Logistics
//CLASS NAME: MO_CLM_EstimateJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class MO_CLM_EstimateJob : IMO_CLM_EstimateJob
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MO_CLM_EstimateJob(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) MO_CLM_EstimateJobSp(string CoNum,
		string RESID,
		string BOMType,
		string CoProductMix,
		int? ProductCycle)
		{
			CoNumType _CoNum = CoNum;
			ApsResourceType _RESID = RESID;
			MO_JobConfigTypeType _BOMType = BOMType;
			ProdMixType _CoProductMix = CoProductMix;
			MO_ProductCycleType _ProductCycle = ProductCycle;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_CLM_EstimateJobSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMType", _BOMType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoProductMix", _CoProductMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCycle", _ProductCycle, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
