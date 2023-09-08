//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerOrderDocumentLifecycle.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_CustomerOrderDocumentLifecycle : ICLM_CustomerOrderDocumentLifecycle
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CustomerOrderDocumentLifecycle(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerOrderDocumentLifecycleSp(string RecType,
		string CoNum = null,
		string InvNum = null,
		string EstNum = null,
		string RmaNum = null)
		{
			StringType _RecType = RecType;
			CoNumType _CoNum = CoNum;
			InvNumType _InvNum = InvNum;
			EstNumType _EstNum = EstNum;
			RmaNumType _RmaNum = RmaNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_CustomerOrderDocumentLifecycleSp";
				
				appDB.AddCommandParameter(cmd, "RecType", _RecType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstNum", _EstNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
