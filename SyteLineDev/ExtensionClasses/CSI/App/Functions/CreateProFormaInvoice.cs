//PROJECT NAME: Data
//CLASS NAME: CreateProFormaInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CreateProFormaInvoice : ICreateProFormaInvoice
	{
		readonly IApplicationDB appDB;
		
		public CreateProFormaInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateProFormaInvoiceSp(
			string TransactionType,
			Guid? SessionID = null,
			string OrderNumber = null,
			DateTime? TransactionDate = null,
			string CustNum = null,
			string InvoiceNumber = null,
			decimal? ShipmentIdStarting = null,
			decimal? ShipmentIdEnding = null,
			string CustNumStarting = null,
			string CustNumEnding = null,
			int? ShipToStarting = null,
			int? ShipToEnding = null,
			DateTime? PickupDateStarting = null,
			DateTime? PickupDateEnding = null,
			string Infobar = null,
			string InvNumStarting = null,
			string InvNumEnding = null,
			string ApplyToInvoice = null)
		{
			DefaultCharType _TransactionType = TransactionType;
			RowPointerType _SessionID = SessionID;
			CoNumType _OrderNumber = OrderNumber;
			DateTimeType _TransactionDate = TransactionDate;
			CustNumType _CustNum = CustNum;
			InvNumType _InvoiceNumber = InvoiceNumber;
			ShipmentIDType _ShipmentIdStarting = ShipmentIdStarting;
			ShipmentIDType _ShipmentIdEnding = ShipmentIdEnding;
			CustNumType _CustNumStarting = CustNumStarting;
			CustNumType _CustNumEnding = CustNumEnding;
			CustSeqType _ShipToStarting = ShipToStarting;
			CustSeqType _ShipToEnding = ShipToEnding;
			DateTimeType _PickupDateStarting = PickupDateStarting;
			DateTimeType _PickupDateEnding = PickupDateEnding;
			InfobarType _Infobar = Infobar;
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			InvNumType _ApplyToInvoice = ApplyToInvoice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateProFormaInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "TransactionType", _TransactionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNumber", _OrderNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionDate", _TransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceNumber", _InvoiceNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentIdStarting", _ShipmentIdStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentIdEnding", _ShipmentIdEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumStarting", _CustNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumEnding", _CustNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToStarting", _ShipToStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToEnding", _ShipToEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateStarting", _PickupDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateEnding", _PickupDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApplyToInvoice", _ApplyToInvoice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
