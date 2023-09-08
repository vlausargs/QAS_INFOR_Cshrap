//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetJOBSTEP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetJOBSTEP
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetJOBSTEPSp(short? AltNo,
		string Filter = null,
		string PROCPLANID = null);
	}
	
	public class CLM_ApsGetJOBSTEP : ICLM_ApsGetJOBSTEP
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsGetJOBSTEP(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetJOBSTEPSp(short? AltNo,
		string Filter = null,
		string PROCPLANID = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ApsAltNoType _AltNo = AltNo;
				LongListType _Filter = Filter;
				ApsProcplanType _PROCPLANID = PROCPLANID;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsGetJOBSTEPSp";
					
					appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PROCPLANID", _PROCPLANID, ParameterDirection.Input);
					
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
