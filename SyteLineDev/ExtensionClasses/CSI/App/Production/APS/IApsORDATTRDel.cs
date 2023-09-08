//PROJECT NAME: Production
//CLASS NAME: IApsORDATTRDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsORDATTRDel
	{
		int? ApsORDATTRDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

