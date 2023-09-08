//PROJECT NAME: Material
//CLASS NAME: IPrintInventorySheets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPrintInventorySheets
	{
		(int? ReturnCode,
			string Infobar) PrintInventorySheetsSp(
			string Whse,
			int? bPrintBlankSheets,
			int? bPRintBarcodeFormat,
			int? bPrintZeroQty,
			string sStartLoc,
			string sEndLoc,
			string sStartLot,
			string sEndLot,
			int? sStartSheet,
			int? sEndSheet,
			string Infobar);
	}
}

