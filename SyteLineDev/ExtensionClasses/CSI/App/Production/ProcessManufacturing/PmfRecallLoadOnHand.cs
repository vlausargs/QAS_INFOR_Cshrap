//PROJECT NAME: Production
//CLASS NAME: PmfRecallLoadOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRecallLoadOnHand
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfRecallLoadOnHandSp(string InfoBar = null,
		                                                                                      Guid? RecallRp = null,
		                                                                                      string Lineage = null,
		                                                                                      int? Forward = 1,
		                                                                                      int? Backward = 0);
	}
	
	public class PmfRecallLoadOnHand : IPmfRecallLoadOnHand
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PmfRecallLoadOnHand(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfRecallLoadOnHandSp(string InfoBar = null,
		                                                                                             Guid? RecallRp = null,
		                                                                                             string Lineage = null,
		                                                                                             int? Forward = 1,
		                                                                                             int? Backward = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _RecallRp = RecallRp;
			StringType _Lineage = Lineage;
			IntType _Forward = Forward;
			IntType _Backward = Backward;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRecallLoadOnHandSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecallRp", _RecallRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lineage", _Lineage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Forward", _Forward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Backward", _Backward, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                InfoBar = _InfoBar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, InfoBar);
			}
		}
	}
}
