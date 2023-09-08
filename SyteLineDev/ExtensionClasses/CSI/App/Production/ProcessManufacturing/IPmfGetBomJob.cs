//PROJECT NAME: Production
//CLASS NAME: IPmfGetBomJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetBomJob
	{
		Guid? PmfGetBomJobFn(
			string Item,
			int? BomSource);
	}
}

