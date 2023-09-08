//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_ResourceOEE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface ICLM_ResourceOEE
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ResourceOEESp(string ResOrResGrp,
		string Type,
		DateTime? StartDate = null,
		DateTime? EndDate = null);
	}
	
	public class CLM_ResourceOEE : ICLM_ResourceOEE
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ResourceOEE(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ResourceOEESp(string ResOrResGrp,
		string Type,
		DateTime? StartDate = null,
		DateTime? EndDate = null)
		{
			StringType _ResOrResGrp = ResOrResGrp;
			ApsRestypeType _Type = Type;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ResourceOEESp";
				
				appDB.AddCommandParameter(cmd, "ResOrResGrp", _ResOrResGrp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
