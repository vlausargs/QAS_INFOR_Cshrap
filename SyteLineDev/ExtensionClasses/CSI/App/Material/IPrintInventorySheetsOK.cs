//PROJECT NAME: Material
//CLASS NAME: IPrintInventorySheetsOK.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPrintInventorySheetsOK
	{
		(int? ReturnCode, string Infobar) PrintInventorySheetsOKSp(Guid? PSessionID,
		string PWhse,
		int? PNumSheets,
		string Infobar);
	}
}

