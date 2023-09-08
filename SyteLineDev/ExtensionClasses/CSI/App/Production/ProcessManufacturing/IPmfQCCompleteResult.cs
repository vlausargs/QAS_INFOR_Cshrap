//PROJECT NAME: Production
//CLASS NAME: IPmfQCCompleteResult.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfQCCompleteResult
	{
		int? PmfQCCompleteResultSp();
	}
}

