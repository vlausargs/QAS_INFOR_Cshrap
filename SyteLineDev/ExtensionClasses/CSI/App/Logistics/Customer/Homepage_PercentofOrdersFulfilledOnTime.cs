//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_PercentofOrdersFulfilledOnTime.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_PercentofOrdersFulfilledOnTime
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_PercentofOrdersFulfilledOnTimeSp(int? DaysBefore = 30);
	}
	
	public class Homepage_PercentofOrdersFulfilledOnTime : IHomepage_PercentofOrdersFulfilledOnTime
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Homepage_PercentofOrdersFulfilledOnTime(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_PercentofOrdersFulfilledOnTimeSp(int? DaysBefore = 30)
		{
			IntType _DaysBefore = DaysBefore;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Homepage_PercentofOrdersFulfilledOnTimeSp";
				
				appDB.AddCommandParameter(cmd, "DaysBefore", _DaysBefore, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
