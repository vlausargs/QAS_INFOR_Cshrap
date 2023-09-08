//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSchedDemandID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSchedDemandID : ICLM_ApsGetSchedDemandID
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

		public CLM_ApsGetSchedDemandID(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSchedDemandIDSp(string PDemandType,
		string PDemandId)
		{
			ApsOrderType _PDemandType = PDemandType;
			OrderRefStrType _PDemandId = PDemandId;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ApsGetSchedDemandIDSp";

				appDB.AddCommandParameter(cmd, "PDemandType", _PDemandType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDemandId", _PDemandId, ParameterDirection.Input);

				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

				dtReturn = appDB.ExecuteQuery(cmd);

				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
