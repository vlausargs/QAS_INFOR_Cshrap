//PROJECT NAME: CSIMaterial
//CLASS NAME: PlanningDetailRefresh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPlanningDetailRefresh
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PlanningDetailRefreshSp(int? RowCount,
		string PCFilter = null,
		int? PageCount = 1);
	}
	
	public class PlanningDetailRefresh : IPlanningDetailRefresh
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PlanningDetailRefresh(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) PlanningDetailRefreshSp(int? RowCount,
		string PCFilter = null,
		int? PageCount = 1)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				IntType _RowCount = RowCount;
				LongListType _PCFilter = PCFilter;
				IntType _PageCount = PageCount;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "PlanningDetailRefreshSp";
					
					appDB.AddCommandParameter(cmd, "RowCount", _RowCount, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCFilter", _PCFilter, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PageCount", _PageCount, ParameterDirection.Input);
					
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
