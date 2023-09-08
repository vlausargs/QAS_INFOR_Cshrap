//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadPOXdocOrderItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadPOXdocOrderItems : ICLM_FTSLLoadPOXdocOrderItems
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTSLLoadPOXdocOrderItems(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLLoadPOXdocOrderItemsSp(string Item,
		string Whse,
		string Job,
		int? priority_1,
		int? priority_2,
		int? priority_3,
		int? priority_4,
		int? priority_5,
		int? future_days_1,
		int? future_days_2,
		int? future_days_3,
		int? future_days_4,
		int? future_days_5)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			JobType _Job = Job;
			CustSeqType _priority_1 = priority_1;
			CustSeqType _priority_2 = priority_2;
			CustSeqType _priority_3 = priority_3;
			CustSeqType _priority_4 = priority_4;
			CustSeqType _priority_5 = priority_5;
			CustSeqType _future_days_1 = future_days_1;
			CustSeqType _future_days_2 = future_days_2;
			CustSeqType _future_days_3 = future_days_3;
			CustSeqType _future_days_4 = future_days_4;
			CustSeqType _future_days_5 = future_days_5;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLLoadPOXdocOrderItemsSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "priority_1", _priority_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "priority_2", _priority_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "priority_3", _priority_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "priority_4", _priority_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "priority_5", _priority_5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "future_days_1", _future_days_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "future_days_2", _future_days_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "future_days_3", _future_days_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "future_days_4", _future_days_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "future_days_5", _future_days_5, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
