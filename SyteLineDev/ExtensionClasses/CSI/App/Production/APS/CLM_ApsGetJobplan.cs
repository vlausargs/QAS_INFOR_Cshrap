//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetJobplan.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_ApsGetJobplan : ICLM_ApsGetJobplan
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsGetJobplan(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetJobplanSp(string PSite,
		string POrder,
		int? AltNo)
		{
			SiteType _PSite = PSite;
			ApsOrderType _POrder = POrder;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ApsGetJobplanSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrder", _POrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
