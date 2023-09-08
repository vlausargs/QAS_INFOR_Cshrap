//PROJECT NAME: Production
//CLASS NAME: IApsMATLRULEDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLRULEDel
	{
		int? ApsMATLRULEDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

