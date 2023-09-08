//PROJECT NAME: Data
//CLASS NAME: CustomerOpenRecordsReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomerOpenRecordsReport : ICustomerOpenRecordsReport
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CustomerOpenRecordsReport(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CustomerOpenRecordsReportSp(
			string CustNumStarting = null,
			string CustNumEnding = null,
			string StatStarting = null,
			string StatEnding = null)
		{
			CustNumType _CustNumStarting = CustNumStarting;
			CustNumType _CustNumEnding = CustNumEnding;
			CustomerStatusType _StatStarting = StatStarting;
			CustomerStatusType _StatEnding = StatEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerOpenRecordsReportSp";
				
				appDB.AddCommandParameter(cmd, "CustNumStarting", _CustNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumEnding", _CustNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatStarting", _StatStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatEnding", _StatEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
