//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvPrint
	{
		(int? ReturnCode,
			string Infobar) SSSFSConInvPrintSp(
			string TPrintInvNum,
			string MooreForm = "N",
			int? TransToDomCurr = 0,
			int? PrintEuro = 0,
			int? PrintBillToNotes = 0,
			int? PrintContractNotes = 0,
			int? PrintContLineNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintFixedContLines = 0,
			string Infobar = null,
			int? Summarize = 0);
	}
}

