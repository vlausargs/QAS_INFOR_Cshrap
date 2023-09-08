//PROJECT NAME: DataCollection
//CLASS NAME: ITimeattDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface ITimeattDel
	{
		int? TimeattDelSp(Guid? RowPointer);
	}
}

