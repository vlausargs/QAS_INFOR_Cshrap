//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CustomerOrderKitBuilder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_CustomerOrderKitBuilder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerOrderKitBuilderSp(string StartingItem = null,
		string EndingItem = null,
		string PlannerCode = null,
		DateTime? StartingDueDate = null,
		DateTime? EndingDueDate = null,
		string FilterString = null);
	}
	
	public class CLM_CustomerOrderKitBuilder : ICLM_CustomerOrderKitBuilder
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CustomerOrderKitBuilder(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerOrderKitBuilderSp(string StartingItem = null,
		string EndingItem = null,
		string PlannerCode = null,
		DateTime? StartingDueDate = null,
		DateTime? EndingDueDate = null,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ItemType _StartingItem = StartingItem;
				ItemType _EndingItem = EndingItem;
				UserCodeType _PlannerCode = PlannerCode;
				DateType _StartingDueDate = StartingDueDate;
				DateType _EndingDueDate = EndingDueDate;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_CustomerOrderKitBuilderSp";
					
					appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PlannerCode", _PlannerCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingDueDate", _StartingDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingDueDate", _EndingDueDate, ParameterDirection.Input);
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
