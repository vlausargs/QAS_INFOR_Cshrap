//PROJECT NAME: Production
//CLASS NAME: IApsMATLATTRDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLATTRDel
	{
		int? ApsMATLATTRDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

