//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PrintInventoryTags.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PrintInventoryTags
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintInventoryTagsSp(string PSessionIDChar = null,
		string Whse = null,
		int? bPrintBlankTags = null,
		int? bPrintBarcodeFormat = null,
		int? bPrintZeroQty = null,
		string sStartLoc = null,
		string sEndLoc = null,
		string sStartLot = null,
		string sEndLot = null,
		int? sStartTag = null,
		int? sEndTag = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

