//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ToBeInvoiced.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ToBeInvoiced : IRpt_ToBeInvoiced
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ToBeInvoiced(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ToBeInvoicedSp(string OrderStarting = null,
		string OrderEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string SlsmanStarting = null,
		string SlsmanEnding = null,
		string CustPOStarting = null,
		string CustPOEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustItemStarting = null,
		string CustItemEnding = null,
		DateTime? ShipDateStarting = null,
		DateTime? ShipDateEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string InvoiceType = null,
		string COStatus = null,
		string COItemStatus = null,
		string SortBy = null,
		int? ShowDetail = null,
		int? OrderDateStartingOffSET = null,
		int? OrderDateEndingOffSET = null,
		int? ShipDateStartingOffSET = null,
		int? ShipDateEndingOffSET = null,
		int? DueDateStartingOffSET = null,
		int? DueDateEndingOffSET = null,
		int? ShowPrice = null,
		int? DisplayHeader = null,
		int? IncludeInvoiceHold = null,
		string pSite = null,
        DateTime? InvDate = null,
        Guid? ProcessId = null)
		{
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			GenericDateType _OrderDateStarting = OrderDateStarting;
			GenericDateType _OrderDateEnding = OrderDateEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			SlsmanType _SlsmanStarting = SlsmanStarting;
			SlsmanType _SlsmanEnding = SlsmanEnding;
			CustPoType _CustPOStarting = CustPOStarting;
			CustPoType _CustPOEnding = CustPOEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			CustItemType _CustItemStarting = CustItemStarting;
			CustItemType _CustItemEnding = CustItemEnding;
			GenericDateType _ShipDateStarting = ShipDateStarting;
			GenericDateType _ShipDateEnding = ShipDateEnding;
			GenericDateType _DueDateStarting = DueDateStarting;
			GenericDateType _DueDateEnding = DueDateEnding;
			StringType _InvoiceType = InvoiceType;
			StringType _COStatus = COStatus;
			StringType _COItemStatus = COItemStatus;
			StringType _SortBy = SortBy;
			FlagNyType _ShowDetail = ShowDetail;
			DateOffsetType _OrderDateStartingOffSET = OrderDateStartingOffSET;
			DateOffsetType _OrderDateEndingOffSET = OrderDateEndingOffSET;
			DateOffsetType _ShipDateStartingOffSET = ShipDateStartingOffSET;
			DateOffsetType _ShipDateEndingOffSET = ShipDateEndingOffSET;
			DateOffsetType _DueDateStartingOffSET = DueDateStartingOffSET;
			DateOffsetType _DueDateEndingOffSET = DueDateEndingOffSET;
			FlagNyType _ShowPrice = ShowPrice;
			FlagNyType _DisplayHeader = DisplayHeader;
			FlagNyType _IncludeInvoiceHold = IncludeInvoiceHold;
			SiteType _pSite = pSite;
            GenericDateType _InvDate = InvDate;
            RowPointerType _ProcessId = ProcessId;

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ToBeInvoicedSp";
				
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SlsmanStarting", _SlsmanStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SlsmanEnding", _SlsmanEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPOStarting", _CustPOStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPOEnding", _CustPOEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItemStarting", _CustItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItemEnding", _CustItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateStarting", _ShipDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateEnding", _ShipDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceType", _InvoiceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COStatus", _COStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COItemStatus", _COItemStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStartingOffSET", _OrderDateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEndingOffSET", _OrderDateEndingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateStartingOffSET", _ShipDateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateEndingOffSET", _ShipDateEndingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStartingOffSET", _DueDateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEndingOffSET", _DueDateEndingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPrice", _ShowPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeInvoiceHold", _IncludeInvoiceHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input); 
                appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
                IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);

                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
