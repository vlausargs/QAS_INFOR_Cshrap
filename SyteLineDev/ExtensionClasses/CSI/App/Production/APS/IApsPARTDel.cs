//PROJECT NAME: Production
//CLASS NAME: IApsPARTDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPARTDel
	{
		int? ApsPARTDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

