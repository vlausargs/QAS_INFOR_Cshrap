//PROJECT NAME: Production
//CLASS NAME: IOPRULEDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IOPRULEDel
	{
		int? OPRULEDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

