//PROJECT NAME: CSIEmployee
//CLASS NAME: CLM_PrtrxChecksToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface ICLM_PrtrxChecksToPrintPost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PrtrxChecksToPrintPostSp(Guid? pSessionID = null);
	}
	
	public class CLM_PrtrxChecksToPrintPost : ICLM_PrtrxChecksToPrintPost
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PrtrxChecksToPrintPost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PrtrxChecksToPrintPostSp(Guid? pSessionID = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RowPointerType _pSessionID = pSessionID;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_PrtrxChecksToPrintPostSp";
					
					appDB.AddCommandParameter(cmd, "pSessionID", _pSessionID, ParameterDirection.Input);
					
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
