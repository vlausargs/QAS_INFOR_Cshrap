//PROJECT NAME: Production
//CLASS NAME: IApsJOBSTEPDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsJOBSTEPDel
	{
		int? ApsJOBSTEPDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

