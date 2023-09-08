//PROJECT NAME: Material
//CLASS NAME: IPrintInventoryOK.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPrintInventoryOK
	{
		(int? ReturnCode,
			string Infobar) PrintInventoryOKSp(
			string Whse,
			int? bSheetsOrTags,
			int? bPrintBlankTagSheet,
			string Infobar);
	}
}

