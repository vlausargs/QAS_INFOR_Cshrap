//PROJECT NAME: Data
//CLASS NAME: IPochange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPochange
	{
		int? PochangeSp(
			Guid? PRowPointer,
			string PPoNum,
			string PTableName);
	}
}

