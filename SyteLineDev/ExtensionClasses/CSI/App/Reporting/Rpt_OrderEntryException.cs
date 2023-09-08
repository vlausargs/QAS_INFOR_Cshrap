//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderEntryException.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_OrderEntryException : IRpt_OrderEntryException
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OrderEntryException(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderEntryExceptionSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		int? OrderLineStarting = null,
		int? OrderLineEnding = null,
		int? OrderReleaseStarting = null,
		int? OrderReleaseEnding = null,
		DateTime? ShipDateStarting = null,
		DateTime? ShipDateEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string OrderType = null,
		string COStatus = null,
		string COItemStatus = null,
		string ExceptionType = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		int? ShipDateStartingOffset = null,
		int? ShipDateEndingOffset = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? ShowPrice = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateType _OrderDateStarting = OrderDateStarting;
			DateType _OrderDateEnding = OrderDateEnding;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CoLineType _OrderLineStarting = OrderLineStarting;
			CoLineType _OrderLineEnding = OrderLineEnding;
			CoReleaseType _OrderReleaseStarting = OrderReleaseStarting;
			CoReleaseType _OrderReleaseEnding = OrderReleaseEnding;
			DateType _ShipDateStarting = ShipDateStarting;
			DateType _ShipDateEnding = ShipDateEnding;
			DateType _DueDateStarting = DueDateStarting;
			DateType _DueDateEnding = DueDateEnding;
			InfobarType _OrderType = OrderType;
			InfobarType _COStatus = COStatus;
			InfobarType _COItemStatus = COItemStatus;
			InfobarType _ExceptionType = ExceptionType;
			DateOffsetType _OrderDateStartingOffset = OrderDateStartingOffset;
			DateOffsetType _OrderDateEndingOffset = OrderDateEndingOffset;
			DateOffsetType _ShipDateStartingOffset = ShipDateStartingOffset;
			DateOffsetType _ShipDateEndingOffset = ShipDateEndingOffset;
			DateOffsetType _DueDateStartingOffset = DueDateStartingOffset;
			DateOffsetType _DueDateEndingOffset = DueDateEndingOffset;
			ListYesNoType _ShowPrice = ShowPrice;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OrderEntryExceptionSp";
				
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineStarting", _OrderLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineEnding", _OrderLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseStarting", _OrderReleaseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseEnding", _OrderReleaseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateStarting", _ShipDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateEnding", _ShipDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COStatus", _COStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COItemStatus", _COItemStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExceptionType", _ExceptionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStartingOffset", _OrderDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEndingOffset", _OrderDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateStartingOffset", _ShipDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateEndingOffset", _ShipDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStartingOffset", _DueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEndingOffset", _DueDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPrice", _ShowPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
