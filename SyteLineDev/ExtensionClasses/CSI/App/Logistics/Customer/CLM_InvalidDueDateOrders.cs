//PROJECT NAME: Logistics
//CLASS NAME: CLM_InvalidDueDateOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_InvalidDueDateOrders : ICLM_InvalidDueDateOrders
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_InvalidDueDateOrders(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_InvalidDueDateOrdersSp(string OrderType,
		string Status,
		string StartOrderNum,
		string EndOrderNum,
		int? StartLine,
		int? EndLine,
		int? StartRelease,
		int? EndRelease,
		string StartCustomer,
		string EndCustomer,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartReleaseDate,
		DateTime? EndReleaseDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		int? IsForward,
		string Site)
		{
			CoTypeType _OrderType = OrderType;
			CoitemStatusType _Status = Status;
			CoNumType _StartOrderNum = StartOrderNum;
			CoNumType _EndOrderNum = EndOrderNum;
			CoLineType _StartLine = StartLine;
			CoLineType _EndLine = EndLine;
			CoReleaseType _StartRelease = StartRelease;
			CoReleaseType _EndRelease = EndRelease;
			CustNumType _StartCustomer = StartCustomer;
			CustNumType _EndCustomer = EndCustomer;
			DateType _StartOrderDate = StartOrderDate;
			DateType _EndOrderDate = EndOrderDate;
			DateType _StartReleaseDate = StartReleaseDate;
			DateType _EndReleaseDate = EndReleaseDate;
			DateType _StartDueDate = StartDueDate;
			DateType _EndDueDate = EndDueDate;
			ListYesNoType _IsForward = IsForward;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_InvalidDueDateOrdersSp";
				
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLine", _StartLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLine", _EndLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRelease", _StartRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRelease", _EndRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustomer", _StartCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomer", _EndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderDate", _StartOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderDate", _EndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReleaseDate", _StartReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReleaseDate", _EndReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsForward", _IsForward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
