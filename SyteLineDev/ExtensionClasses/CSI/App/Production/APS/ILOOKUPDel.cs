//PROJECT NAME: Production
//CLASS NAME: ILOOKUPDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ILOOKUPDel
	{
		int? LOOKUPDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

