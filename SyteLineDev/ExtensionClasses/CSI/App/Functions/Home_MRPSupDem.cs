//PROJECT NAME: Data
//CLASS NAME: Home_MRPSupDem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Home_MRPSupDem : IHome_MRPSupDem
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Home_MRPSupDem(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Home_MRPSupDemSp(
			int? DetailDisplay = 0,
			int? UseFullyTransactedOrders = 0,
			int? PExcludePLNs = 0,
			string Item = null,
			int? RowCount = 200)
		{
			ListYesNoType _DetailDisplay = DetailDisplay;
			ListYesNoType _UseFullyTransactedOrders = UseFullyTransactedOrders;
			ListYesNoType _PExcludePLNs = PExcludePLNs;
			ItemType _Item = Item;
			IntType _RowCount = RowCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_MRPSupDemSp";
				
				appDB.AddCommandParameter(cmd, "DetailDisplay", _DetailDisplay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseFullyTransactedOrders", _UseFullyTransactedOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExcludePLNs", _PExcludePLNs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowCount", _RowCount, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
