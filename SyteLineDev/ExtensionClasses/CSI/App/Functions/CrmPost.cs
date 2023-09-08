//PROJECT NAME: Data
//CLASS NAME: CrmPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CrmPost : ICrmPost
	{
		readonly IApplicationDB appDB;
		
		public CrmPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string BCrmNum,
			string ECrmNum,
			DateTime? BCrmDate,
			DateTime? ECrmDate,
			string Infobar,
			Guid? ProcessId,
			int? Invoice) CrmPostSp(
			string TNewInvoice,
			DateTime? TCrmDate,
			int? TTransDomCurr,
			string BRmaNum,
			string ERmaNum,
			int? BRmaLine,
			int? ERmaLine,
			string BCustNum,
			string ECustNum,
			DateTime? BLastReturnDate,
			DateTime? ELastReturnDate,
			string BCrmNum,
			string ECrmNum,
			DateTime? BCrmDate,
			DateTime? ECrmDate,
			int? PrintOrderNotes = 0,
			int? PrintRMANotes = 0,
			int? PrintShipToNotes = 0,
			int? PrintBillToNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintRMALineNotes = 0,
			string Infobar = null,
			Guid? ProcessId = null,
			int? Invoice = null)
		{
			LongListType _TNewInvoice = TNewInvoice;
			DateType _TCrmDate = TCrmDate;
			ListYesNoType _TTransDomCurr = TTransDomCurr;
			RmaNumType _BRmaNum = BRmaNum;
			RmaNumType _ERmaNum = ERmaNum;
			RmaLineType _BRmaLine = BRmaLine;
			RmaLineType _ERmaLine = ERmaLine;
			CustNumType _BCustNum = BCustNum;
			CustNumType _ECustNum = ECustNum;
			DateType _BLastReturnDate = BLastReturnDate;
			DateType _ELastReturnDate = ELastReturnDate;
			InvNumType _BCrmNum = BCrmNum;
			InvNumType _ECrmNum = ECrmNum;
			DateType _BCrmDate = BCrmDate;
			DateType _ECrmDate = ECrmDate;
			ListYesNoType _PrintOrderNotes = PrintOrderNotes;
			ListYesNoType _PrintRMANotes = PrintRMANotes;
			ListYesNoType _PrintShipToNotes = PrintShipToNotes;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintRMALineNotes = PrintRMALineNotes;
			InfobarType _Infobar = Infobar;
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _Invoice = Invoice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CrmPostSp";
				
				appDB.AddCommandParameter(cmd, "TNewInvoice", _TNewInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCrmDate", _TCrmDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDomCurr", _TTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BRmaNum", _BRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ERmaNum", _ERmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BRmaLine", _BRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ERmaLine", _ERmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BCustNum", _BCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECustNum", _ECustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BLastReturnDate", _BLastReturnDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELastReturnDate", _ELastReturnDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BCrmNum", _BCrmNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ECrmNum", _ECrmNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BCrmDate", _BCrmDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ECrmDate", _ECrmDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintOrderNotes", _PrintOrderNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRMANotes", _PrintRMANotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintShipToNotes", _PrintShipToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRMALineNotes", _PrintRMALineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Invoice", _Invoice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BCrmNum = _BCrmNum;
				ECrmNum = _ECrmNum;
				BCrmDate = _BCrmDate;
				ECrmDate = _ECrmDate;
				Infobar = _Infobar;
				ProcessId = _ProcessId;
				Invoice = _Invoice;
				
				return (Severity, BCrmNum, ECrmNum, BCrmDate, ECrmDate, Infobar, ProcessId, Invoice);
			}
		}
	}
}
