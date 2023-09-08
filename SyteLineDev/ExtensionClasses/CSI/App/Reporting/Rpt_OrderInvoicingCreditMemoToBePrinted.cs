//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderInvoicingCreditMemoToBePrinted.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_OrderInvoicingCreditMemoToBePrinted : IRpt_OrderInvoicingCreditMemoToBePrinted
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OrderInvoicingCreditMemoToBePrinted(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderInvoicingCreditMemoToBePrintedSp(string CustomerStarting,
		string CustomerEnding,
		string OrderStarting,
		string OrderEnding,
		int? OrderLineStarting,
		int? OrderLineEnding,
		int? OrderReleaseStarting,
		int? OrderReleaseEnding,
		DateTime? ShipDateStarting,
		DateTime? ShipDateEnding,
		int? CreateFromPackSlip,
		int? PackNumStarting,
		int? PackNumEnding,
		int? CreateFromShipment,
		decimal? ShipmentIdStarting,
		decimal? ShipmentIdEnding,
		DateTime? InvDate,
		string InvoiceType,
		string PrintCustomerItemItem,
		string InvoiceOrCreditMemo,
		int? PrintStandardOrderText,
		string pSite = null)
		{
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CoLineType _OrderLineStarting = OrderLineStarting;
			CoLineType _OrderLineEnding = OrderLineEnding;
			CoReleaseType _OrderReleaseStarting = OrderReleaseStarting;
			CoReleaseType _OrderReleaseEnding = OrderReleaseEnding;
			DateType _ShipDateStarting = ShipDateStarting;
			DateType _ShipDateEnding = ShipDateEnding;
			ListYesNoType _CreateFromPackSlip = CreateFromPackSlip;
			PackNumType _PackNumStarting = PackNumStarting;
			PackNumType _PackNumEnding = PackNumEnding;
			ListYesNoType _CreateFromShipment = CreateFromShipment;
			ShipmentIDType _ShipmentIdStarting = ShipmentIdStarting;
			ShipmentIDType _ShipmentIdEnding = ShipmentIdEnding;
			DateType _InvDate = InvDate;
			StringType _InvoiceType = InvoiceType;
			StringType _PrintCustomerItemItem = PrintCustomerItemItem;
			StringType _InvoiceOrCreditMemo = InvoiceOrCreditMemo;
			ListYesNoType _PrintStandardOrderText = PrintStandardOrderText;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OrderInvoicingCreditMemoToBePrintedSp";
				
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineStarting", _OrderLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineEnding", _OrderLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseStarting", _OrderReleaseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseEnding", _OrderReleaseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateStarting", _ShipDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDateEnding", _ShipDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateFromPackSlip", _CreateFromPackSlip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNumStarting", _PackNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNumEnding", _PackNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateFromShipment", _CreateFromShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentIdStarting", _ShipmentIdStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentIdEnding", _ShipmentIdEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceType", _InvoiceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerItemItem", _PrintCustomerItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceOrCreditMemo", _InvoiceOrCreditMemo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardOrderText", _PrintStandardOrderText, ParameterDirection.Input);
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
