//PROJECT NAME: Production
//CLASS NAME: PmfLoadOnHandStock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfLoadOnHandStock
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfLoadOnHandStockSp(string InfoBar = null,
		                                                                                     int? RowLimit = 100,
		                                                                                     string Item = null,
		                                                                                     string Whse = null,
		                                                                                     string Function = null,
		                                                                                     int? ExpiredFlag = 0,
		                                                                                     int? LockedForPickFlag = 0,
		                                                                                     int? ExcludeOtherPnInv = 1,
		                                                                                     Guid? PnRp = null,
		                                                                                     Guid? JobRp = null);
	}
	
	public class PmfLoadOnHandStock : IPmfLoadOnHandStock
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PmfLoadOnHandStock(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfLoadOnHandStockSp(string InfoBar = null,
		                                                                                            int? RowLimit = 100,
		                                                                                            string Item = null,
		                                                                                            string Whse = null,
		                                                                                            string Function = null,
		                                                                                            int? ExpiredFlag = 0,
		                                                                                            int? LockedForPickFlag = 0,
		                                                                                            int? ExcludeOtherPnInv = 1,
		                                                                                            Guid? PnRp = null,
		                                                                                            Guid? JobRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			IntType _RowLimit = RowLimit;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			StringType _Function = Function;
			IntType _ExpiredFlag = ExpiredFlag;
			IntType _LockedForPickFlag = LockedForPickFlag;
			IntType _ExcludeOtherPnInv = ExcludeOtherPnInv;
			RowPointerType _PnRp = PnRp;
			RowPointerType _JobRp = JobRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfLoadOnHandStockSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowLimit", _RowLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Function", _Function, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpiredFlag", _ExpiredFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LockedForPickFlag", _LockedForPickFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeOtherPnInv", _ExcludeOtherPnInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.Input);
				
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
