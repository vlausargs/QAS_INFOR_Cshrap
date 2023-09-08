//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInvPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInvPrint
	{
		(int? ReturnCode,
			string Infobar) SSSFSSROInvPrintSp(
			string Mode = "PROCESS",
			string TPrintInvNum = null,
			string MooreForm = "N",
			int? TransToDomCurr = null,
			int? PrintEuro = 0,
			int? PrintBillToNotes = 0,
			int? PrintSRONotes = 0,
			int? PrintSROLineNotes = 0,
			int? PrintSROOperNotes = 0,
			int? PrintTransNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintSerials = 0,
			int? PrintMatl = 0,
			int? PrintLabor = 0,
			int? PrintMisc = 0,
			int? SummarizeTrans = 0,
			string BillCustCons = "U",
			string OrderBy = null,
			string Infobar = null);
	}
}

