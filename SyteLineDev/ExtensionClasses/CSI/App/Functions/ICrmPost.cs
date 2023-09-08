//PROJECT NAME: Data
//CLASS NAME: ICrmPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICrmPost
	{
		(int? ReturnCode,
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
			int? Invoice = null);
	}
}

