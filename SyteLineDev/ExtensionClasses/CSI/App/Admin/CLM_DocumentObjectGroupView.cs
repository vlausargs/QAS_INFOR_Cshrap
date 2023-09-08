//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_DocumentObjectGroupView.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface ICLM_DocumentObjectGroupView
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DocumentObjectGroupViewSp(string filterString = null,
		string IdoFilter = null);
	}
	
	public class CLM_DocumentObjectGroupView : ICLM_DocumentObjectGroupView
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_DocumentObjectGroupView(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_DocumentObjectGroupViewSp(string filterString = null,
		string IdoFilter = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				LongListType _filterString = filterString;
				StringType _IdoFilter = IdoFilter;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_DocumentObjectGroupViewSp";
					
					appDB.AddCommandParameter(cmd, "filterString", _filterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IdoFilter", _IdoFilter, ParameterDirection.Input);
					
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
