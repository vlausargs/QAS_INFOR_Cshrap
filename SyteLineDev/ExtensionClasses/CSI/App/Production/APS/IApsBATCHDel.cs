//PROJECT NAME: Production
//CLASS NAME: IApsBATCHDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBATCHDel
	{
		int? ApsBATCHDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

