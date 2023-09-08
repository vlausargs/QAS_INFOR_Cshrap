//PROJECT NAME: Production
//CLASS NAME: IApsBATPRODORDDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBATPRODORDDel
	{
		int? ApsBATPRODORDDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

