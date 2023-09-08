//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerServiceImpart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_CustomerServiceImpart
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerServiceImpartSp(string StartDate,
		string LateByDate = null,
		int? GraphIntervalCount = 6,
		int? GraphIntervalType = 2,
		byte? IncludeWithCO = (byte)0,
		byte? JobOrderOnly = (byte)0,
		string UnallocJOPrice = null,
		int? Yield = null,
		string RptType = "DTL",
		string CustNums = null,
		string CustNumShipto = null);
	}
	
	public class CLM_CustomerServiceImpart : ICLM_CustomerServiceImpart
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CustomerServiceImpart(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerServiceImpartSp(string StartDate,
		string LateByDate = null,
		int? GraphIntervalCount = 6,
		int? GraphIntervalType = 2,
		byte? IncludeWithCO = (byte)0,
		byte? JobOrderOnly = (byte)0,
		string UnallocJOPrice = null,
		int? Yield = null,
		string RptType = "DTL",
		string CustNums = null,
		string CustNumShipto = null)
		{
			ItemType _StartDate = StartDate;
			StringType _LateByDate = LateByDate;
			IntType _GraphIntervalCount = GraphIntervalCount;
			IntType _GraphIntervalType = GraphIntervalType;
			ListYesNoType _IncludeWithCO = IncludeWithCO;
			ListYesNoType _JobOrderOnly = JobOrderOnly;
			StringType _UnallocJOPrice = UnallocJOPrice;
			IntType _Yield = Yield;
			StringType _RptType = RptType;
			StringType _CustNums = CustNums;
			StringType _CustNumShipto = CustNumShipto;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_CustomerServiceImpartSp";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LateByDate", _LateByDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GraphIntervalCount", _GraphIntervalCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GraphIntervalType", _GraphIntervalType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeWithCO", _IncludeWithCO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobOrderOnly", _JobOrderOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnallocJOPrice", _UnallocJOPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Yield", _Yield, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RptType", _RptType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNums", _CustNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumShipto", _CustNumShipto, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
