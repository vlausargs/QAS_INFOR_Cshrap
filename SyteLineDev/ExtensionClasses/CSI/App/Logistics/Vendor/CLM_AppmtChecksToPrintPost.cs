//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_AppmtChecksToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_AppmtChecksToPrintPost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_AppmtChecksToPrintPostSp(Guid? PSessionID = null);
	}
	
	public class CLM_AppmtChecksToPrintPost : ICLM_AppmtChecksToPrintPost
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_AppmtChecksToPrintPost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_AppmtChecksToPrintPostSp(Guid? PSessionID = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RowPointerType _PSessionID = PSessionID;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_AppmtChecksToPrintPostSp";
					
					appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
					
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
