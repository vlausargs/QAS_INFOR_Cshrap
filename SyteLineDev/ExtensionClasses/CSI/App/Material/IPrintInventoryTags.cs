//PROJECT NAME: Material
//CLASS NAME: IPrintInventoryTags.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPrintInventoryTags
	{
		(int? ReturnCode,
			string Infobar) PrintInventoryTagsSp(
			string Whse,
			int? bPrintBlankTags,
			int? bPRintBarcodeFormat,
			int? bPrintZeroQty,
			string sStartLoc,
			string sEndLoc,
			string sStartLot,
			string sEndLot,
			int? sStartTag,
			int? sEndTag,
			string Infobar);
	}
}

