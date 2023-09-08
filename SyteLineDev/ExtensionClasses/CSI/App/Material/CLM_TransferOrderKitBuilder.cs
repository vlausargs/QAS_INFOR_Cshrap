//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_TransferOrderKitBuilder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ICLM_TransferOrderKitBuilder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_TransferOrderKitBuilderSp(string StartingItem = null,
		string EndingItem = null,
		string PlannerCode = null,
		DateTime? StartingDate = null,
		DateTime? EndingDate = null,
		string FilterString = null);
	}
	
	public class CLM_TransferOrderKitBuilder : ICLM_TransferOrderKitBuilder
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_TransferOrderKitBuilder(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_TransferOrderKitBuilderSp(string StartingItem = null,
		string EndingItem = null,
		string PlannerCode = null,
		DateTime? StartingDate = null,
		DateTime? EndingDate = null,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ItemType _StartingItem = StartingItem;
				ItemType _EndingItem = EndingItem;
				UserCodeType _PlannerCode = PlannerCode;
				DateType _StartingDate = StartingDate;
				DateType _EndingDate = EndingDate;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_TransferOrderKitBuilderSp";
					
					appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PlannerCode", _PlannerCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingDate", _StartingDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingDate", _EndingDate, ParameterDirection.Input);
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
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
