//PROJECT NAME: Production
//CLASS NAME: IPmfEntryClear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfEntryClear
	{
		int? PmfEntryClearSp(Guid? SessionId = null);
	}
}

