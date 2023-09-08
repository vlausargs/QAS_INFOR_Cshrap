//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustServOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_CustServOrders : ICLM_CustServOrders
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CustServOrders(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CustServOrdersSp(string FilterVar,
		string CustNum,
		string SlsmanList,
		string OrdersFor,
		string FilterString,
		string PSiteGroup = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _FilterVar = FilterVar;
				CustNumType _CustNum = CustNum;
				StringType _SlsmanList = SlsmanList;
				StringType _OrdersFor = OrdersFor;
				LongListType _FilterString = FilterString;
				SiteGroupType _PSiteGroup = PSiteGroup;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_CustServOrdersSp";
					
					appDB.AddCommandParameter(cmd, "FilterVar", _FilterVar, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SlsmanList", _SlsmanList, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "OrdersFor", _OrdersFor, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);
					
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
