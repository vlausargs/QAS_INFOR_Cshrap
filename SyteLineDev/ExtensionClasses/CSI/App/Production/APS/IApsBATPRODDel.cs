//PROJECT NAME: Production
//CLASS NAME: IApsBATPRODDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBATPRODDel
	{
		int? ApsBATPRODDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

