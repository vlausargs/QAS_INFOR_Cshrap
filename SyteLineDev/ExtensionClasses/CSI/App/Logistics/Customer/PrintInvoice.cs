//PROJECT NAME: Logistics
//CLASS NAME: PrintInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PrintInvoice : IPrintInvoice
	{
		readonly IApplicationDB appDB;
		
		public PrintInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Error,
			string Infobar) PrintInvoiceSp(
			string CustomerNum,
			string InvoiceNum,
			int? InvoiceSeq,
			int? EPlaces,
			int? EuroExists,
			string DocType,
			int? PrintDocTxt,
			int? PrintStdOrderTxt,
			int? PrintCustMstrTxt,
			int? TransDomCurr,
			int? PrintEuroTotal,
			int? ShowInternal,
			int? ShowExternal,
			DateTime? DocDate,
			int? Error,
			string Infobar = null,
			int? PrePrint = null)
		{
			CustNumType _CustomerNum = CustomerNum;
			InvNumType _InvoiceNum = InvoiceNum;
			ArInvSeqType _InvoiceSeq = InvoiceSeq;
			DecimalPlacesType _EPlaces = EPlaces;
			ListYesNoType _EuroExists = EuroExists;
			InfobarType _DocType = DocType;
			ListYesNoType _PrintDocTxt = PrintDocTxt;
			ListYesNoType _PrintStdOrderTxt = PrintStdOrderTxt;
			ListYesNoType _PrintCustMstrTxt = PrintCustMstrTxt;
			ListYesNoType _TransDomCurr = TransDomCurr;
			ListYesNoType _PrintEuroTotal = PrintEuroTotal;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			DateType _DocDate = DocDate;
			ListYesNoType _Error = Error;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PrePrint = PrePrint;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "CustomerNum", _CustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceNum", _InvoiceNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceSeq", _InvoiceSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPlaces", _EPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EuroExists", _EuroExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocType", _DocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDocTxt", _PrintDocTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStdOrderTxt", _PrintStdOrderTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustMstrTxt", _PrintCustMstrTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuroTotal", _PrintEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocDate", _DocDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Error", _Error, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrePrint", _PrePrint, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Error = _Error;
				Infobar = _Infobar;
				
				return (Severity, Error, Infobar);
			}
		}
	}
}
