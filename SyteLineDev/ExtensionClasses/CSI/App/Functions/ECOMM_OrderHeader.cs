//PROJECT NAME: Data
//CLASS NAME: ECOMM_OrderHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ECOMM_OrderHeader : IECOMM_OrderHeader
	{
		readonly IApplicationDB appDB;
		
		public ECOMM_OrderHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string OrdNumber,
			int? ErrorOccured,
			string Infobar,
			decimal? InvoiceAmount) ECOMM_OrderHeaderSp(
			string CustomerNumber,
			int? ShipToNumber,
			string PONumber,
			string CarrierCode,
			string WarehouseID,
			string OrderType,
			string Comment,
			string ShippingInstr,
			string EmailAddress,
			string OrdNumber,
			int? ErrorOccured,
			string Infobar,
			decimal? InvoiceAmount)
		{
			CustNumType _CustomerNumber = CustomerNumber;
			CustSeqType _ShipToNumber = ShipToNumber;
			CustPoType _PONumber = PONumber;
			ShipCodeType _CarrierCode = CarrierCode;
			WhseType _WarehouseID = WarehouseID;
			CoTypeType _OrderType = OrderType;
			OleObjectType _Comment = Comment;
			OleObjectType _ShippingInstr = ShippingInstr;
			EmailType _EmailAddress = EmailAddress;
			CoNumType _OrdNumber = OrdNumber;
			ListYesNoType _ErrorOccured = ErrorOccured;
			InfobarType _Infobar = Infobar;
			AmtTotType _InvoiceAmount = InvoiceAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ECOMM_OrderHeaderSp";
				
				appDB.AddCommandParameter(cmd, "CustomerNumber", _CustomerNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToNumber", _ShipToNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PONumber", _PONumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CarrierCode", _CarrierCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseID", _WarehouseID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Comment", _Comment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShippingInstr", _ShippingInstr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailAddress", _EmailAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNumber", _OrdNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ErrorOccured", _ErrorOccured, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvoiceAmount", _InvoiceAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OrdNumber = _OrdNumber;
				ErrorOccured = _ErrorOccured;
				Infobar = _Infobar;
				InvoiceAmount = _InvoiceAmount;
				
				return (Severity, OrdNumber, ErrorOccured, Infobar, InvoiceAmount);
			}
		}
	}
}
