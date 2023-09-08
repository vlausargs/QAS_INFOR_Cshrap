//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RMACreditMemo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RMACreditMemo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RMACreditMemoSp(Guid? pSessionID = null,
		string ProcessReprint = "R",
		string PrintItemCustItem = "CI",
		int? TPrSerialNum = 0,
		int? TTransDomCurr = 0,
		string BCrmNum = null,
		string ECrmNum = null,
		DateTime? BCrmDate = null,
		DateTime? ECrmDate = null,
		int? PrintOrderNotes = 0,
		int? PrintRMANotes = 0,
		int? PrintShipToNotes = 0,
		int? PrintBillToNotes = 0,
		int? ShowInternal = 0,
		int? ShowExternal = 0,
		int? PrintItemOverview = null,
		int? PrintRMALineNotes = 0,
		int? PrintLotNumbers = 1,
		string BGSessionId = null,
		string pSite = null);
	}
}

