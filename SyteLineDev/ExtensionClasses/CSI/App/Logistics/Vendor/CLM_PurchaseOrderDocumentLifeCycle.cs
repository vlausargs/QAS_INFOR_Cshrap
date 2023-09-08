//PROJECT NAME: Logistics
//CLASS NAME: CLM_PurchaseOrderDocumentLifeCycle.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_PurchaseOrderDocumentLifeCycle : ICLM_PurchaseOrderDocumentLifeCycle
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PurchaseOrderDocumentLifeCycle(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PurchaseOrderDocumentLifeCycleSp(string RecType,
		string PoNum = null,
		int? VchNum = null,
		string ReqNum = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _RecType = RecType;
				PoNumType _PoNum = PoNum;
				VoucherType _VchNum = VchNum;
				ReqNumType _ReqNum = ReqNum;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_PurchaseOrderDocumentLifeCycleSp";
					
					appDB.AddCommandParameter(cmd, "RecType", _RecType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "VchNum", _VchNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
					
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
