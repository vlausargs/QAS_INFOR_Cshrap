//PROJECT NAME: CSICustomer
//CLASS NAME: ChangeCOLineRelease.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IChangeCOLineRelease
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChangeCOLineReleaseSp(string StartOrderNum,
		string EndOrderNum,
		short? StartLine,
		short? StartRelease,
		short? EndLine,
		short? EndRelease,
		string StartCustomer,
		string EndCustomer,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		DateTime? StartReleaseDate,
		DateTime? EndReleaseDate,
		string OrderType,
		string Status,
		string PProcess,
		string Infobar,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null,
		short? StartDueDateOffset = null,
		short? EndDueDateOffset = null,
		short? StartReleaseDateOffset = null,
		short? EndReleaseDateOffset = null);
	}
	
	public class ChangeCOLineRelease : IChangeCOLineRelease
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ChangeCOLineRelease(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChangeCOLineReleaseSp(string StartOrderNum,
		string EndOrderNum,
		short? StartLine,
		short? StartRelease,
		short? EndLine,
		short? EndRelease,
		string StartCustomer,
		string EndCustomer,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		DateTime? StartReleaseDate,
		DateTime? EndReleaseDate,
		string OrderType,
		string Status,
		string PProcess,
		string Infobar,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null,
		short? StartDueDateOffset = null,
		short? EndDueDateOffset = null,
		short? StartReleaseDateOffset = null,
		short? EndReleaseDateOffset = null)
		{
			CoNumType _StartOrderNum = StartOrderNum;
			CoNumType _EndOrderNum = EndOrderNum;
			CoLineType _StartLine = StartLine;
			CoReleaseType _StartRelease = StartRelease;
			CoLineType _EndLine = EndLine;
			CoReleaseType _EndRelease = EndRelease;
			CustNumType _StartCustomer = StartCustomer;
			CustNumType _EndCustomer = EndCustomer;
			DateType _StartOrderDate = StartOrderDate;
			DateType _EndOrderDate = EndOrderDate;
			DateType _StartDueDate = StartDueDate;
			DateType _EndDueDate = EndDueDate;
			DateType _StartReleaseDate = StartReleaseDate;
			DateType _EndReleaseDate = EndReleaseDate;
			CoTypeType _OrderType = OrderType;
			CoStatusType _Status = Status;
			LongListType _PProcess = PProcess;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartOrderDateOffset = StartOrderDateOffset;
			DateOffsetType _EndOrderDateOffset = EndOrderDateOffset;
			DateOffsetType _StartDueDateOffset = StartDueDateOffset;
			DateOffsetType _EndDueDateOffset = EndDueDateOffset;
			DateOffsetType _StartReleaseDateOffset = StartReleaseDateOffset;
			DateOffsetType _EndReleaseDateOffset = EndReleaseDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeCOLineReleaseSp";
				
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLine", _StartLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRelease", _StartRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLine", _EndLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRelease", _EndRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustomer", _StartCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomer", _EndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderDate", _StartOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderDate", _EndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReleaseDate", _StartReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReleaseDate", _EndReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartOrderDateOffset", _StartOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderDateOffset", _EndOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDateOffset", _StartDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDateOffset", _EndDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReleaseDateOffset", _StartReleaseDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReleaseDateOffset", _EndReleaseDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
