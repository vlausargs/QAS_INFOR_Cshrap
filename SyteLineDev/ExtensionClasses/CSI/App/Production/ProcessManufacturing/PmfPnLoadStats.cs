//PROJECT NAME: Production
//CLASS NAME: PmfPnLoadStats.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnLoadStats
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfPnLoadStatsSp(string InfoBar = null,
		                                                                                 Guid? PnRp = null);
	}
	
	public class PmfPnLoadStats : IPmfPnLoadStats
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PmfPnLoadStats(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfPnLoadStatsSp(string InfoBar = null,
		                                                                                        Guid? PnRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnLoadStatsSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				
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
