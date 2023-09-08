//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ItemBottlenecksAPS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_ItemBottlenecksAPS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemBottlenecksAPSSp(string UbItem = null,
		string UbPlannerCode = null,
		string UbSourceType = null,
		string UbBuyerNum = null,
		string UbProductCode = null,
		short? ALTNO = null);
	}
	
	public class CLM_ItemBottlenecksAPS : ICLM_ItemBottlenecksAPS
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ItemBottlenecksAPS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemBottlenecksAPSSp(string UbItem = null,
		string UbPlannerCode = null,
		string UbSourceType = null,
		string UbBuyerNum = null,
		string UbProductCode = null,
		short? ALTNO = null)
		{
			ItemType _UbItem = UbItem;
			UserCodeType _UbPlannerCode = UbPlannerCode;
			SourceType _UbSourceType = UbSourceType;
			UsernameType _UbBuyerNum = UbBuyerNum;
			ProductCodeType _UbProductCode = UbProductCode;
			ApsAltNoType _ALTNO = ALTNO;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ItemBottlenecksAPSSp";
				
				appDB.AddCommandParameter(cmd, "UbItem", _UbItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbPlannerCode", _UbPlannerCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbSourceType", _UbSourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbBuyerNum", _UbBuyerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbProductCode", _UbProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALTNO", _ALTNO, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
