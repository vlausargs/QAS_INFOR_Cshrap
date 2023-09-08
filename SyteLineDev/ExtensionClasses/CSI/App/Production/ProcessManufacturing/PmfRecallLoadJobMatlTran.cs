//PROJECT NAME: Production
//CLASS NAME: PmfRecallLoadJobMatlTran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRecallLoadJobMatlTran
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfRecallLoadJobMatlTranSp(string InfoBar = null,
		                                                                                           Guid? RecallRp = null,
		                                                                                           string Lineage = null,
		                                                                                           int? Forward = 1,
		                                                                                           int? Backward = 0,
		                                                                                           int? LotDetail = 0);
	}
	
	public class PmfRecallLoadJobMatlTran : IPmfRecallLoadJobMatlTran
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PmfRecallLoadJobMatlTran(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfRecallLoadJobMatlTranSp(string InfoBar = null,
		                                                                                                  Guid? RecallRp = null,
		                                                                                                  string Lineage = null,
		                                                                                                  int? Forward = 1,
		                                                                                                  int? Backward = 0,
		                                                                                                  int? LotDetail = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _RecallRp = RecallRp;
			StringType _Lineage = Lineage;
			IntType _Forward = Forward;
			IntType _Backward = Backward;
			IntType _LotDetail = LotDetail;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRecallLoadJobMatlTranSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecallRp", _RecallRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lineage", _Lineage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Forward", _Forward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Backward", _Backward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotDetail", _LotDetail, ParameterDirection.Input);
				
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
