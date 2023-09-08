//PROJECT NAME: Production
//CLASS NAME: IApsRESRCDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsRESRCDel
	{
		int? ApsRESRCDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

