//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PrintInventorySheets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PrintInventorySheets
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintInventorySheetsSp(string PSessionIDChar = null,
		string Whse = null,
		int? bPrintBlankSheets = null,
		int? bPrintBarcodeFormat = null,
		int? bPrintZeroQty = null,
		string sStartLoc = null,
		string sEndLoc = null,
		string sStartLot = null,
		string sEndLot = null,
		int? sStartSheet = null,
		int? sEndSheet = null,
		int? DisplayHeader = null,
		int? PrintPieces = 0,
		string BGSessionId = null,
		string pSite = null);
	}
}

