//PROJECT NAME: Production
//CLASS NAME: IPmfUserHasPerm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfUserHasPerm
	{
		int? PmfUserHasPermSp();

		int? PmfUserHasPermFn();
	}
}

