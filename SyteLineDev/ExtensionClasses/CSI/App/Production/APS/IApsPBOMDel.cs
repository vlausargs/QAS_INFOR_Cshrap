//PROJECT NAME: Production
//CLASS NAME: IApsPBOMDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPBOMDel
	{
		int? ApsPBOMDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

