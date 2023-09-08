//PROJECT NAME: Production
//CLASS NAME: ApsResrcUtilIntervalTbl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Production.APS
{
	public class ApsResrcUtilIntervalTbl : IApsResrcUtilIntervalTbl
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public ApsResrcUtilIntervalTbl(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse ApsResrcUtilIntervalTblFn(
			int? IntervalType,
			int? IntervalCount,
			DateTime? StartDate,
			DateTime? BeginDate)
		{
			ByteType _IntervalType = IntervalType;
			ShortType _IntervalCount = IntervalCount;
			DateTimeType _StartDate = StartDate;
			DateTimeType _BeginDate = BeginDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[ApsResrcUtilIntervalTbl](@IntervalType, @IntervalCount, @StartDate, @BeginDate)";
				
				appDB.AddCommandParameter(cmd, "IntervalType", _IntervalType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IntervalCount", _IntervalCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginDate", _BeginDate, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_ApsResrcUtilIntervalTbl";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
