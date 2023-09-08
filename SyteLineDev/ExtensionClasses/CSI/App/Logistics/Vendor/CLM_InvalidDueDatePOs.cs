//PROJECT NAME: Logistics
//CLASS NAME: CLM_InvalidDueDatePOs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_InvalidDueDatePOs : ICLM_InvalidDueDatePOs
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_InvalidDueDatePOs(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_InvalidDueDatePOsSp(string OrderType,
		string Status,
		string StartOrderNum,
		string EndOrderNum,
		int? StartLine,
		int? EndLine,
		int? StartRelease,
		int? EndRelease,
		string StartVendor,
		string EndVendor,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartReleaseDate,
		DateTime? EndReleaseDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		int? MoveDirection)
		{
			PoTypeType _OrderType = OrderType;
			PoitemStatType _Status = Status;
			PoNumType _StartOrderNum = StartOrderNum;
			PoNumType _EndOrderNum = EndOrderNum;
			PoLineType _StartLine = StartLine;
			PoLineType _EndLine = EndLine;
			PoReleaseType _StartRelease = StartRelease;
			PoReleaseType _EndRelease = EndRelease;
			VendNumType _StartVendor = StartVendor;
			VendNumType _EndVendor = EndVendor;
			DateType _StartOrderDate = StartOrderDate;
			DateType _EndOrderDate = EndOrderDate;
			DateType _StartReleaseDate = StartReleaseDate;
			DateType _EndReleaseDate = EndReleaseDate;
			DateType _StartDueDate = StartDueDate;
			DateType _EndDueDate = EndDueDate;
			ListYesNoType _MoveDirection = MoveDirection;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_InvalidDueDatePOsSp";
				
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLine", _StartLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLine", _EndLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRelease", _StartRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRelease", _EndRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendor", _StartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendor", _EndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderDate", _StartOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderDate", _EndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReleaseDate", _StartReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReleaseDate", _EndReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveDirection", _MoveDirection, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
