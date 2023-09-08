//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetAltsItemId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_ApsGetAltsItemId : ICLM_ApsGetAltsItemId
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsGetAltsItemId(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetAltsItemIdSp(int? AltNo1,
		int? AltNo2,
		string ItemFilter = null)
		{
			ApsAltNoType _AltNo1 = AltNo1;
			ApsAltNoType _AltNo2 = AltNo2;
			LongListType _ItemFilter = ItemFilter;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ApsGetAltsItemIdSp";
				
				appDB.AddCommandParameter(cmd, "AltNo1", _AltNo1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo2", _AltNo2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemFilter", _ItemFilter, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
