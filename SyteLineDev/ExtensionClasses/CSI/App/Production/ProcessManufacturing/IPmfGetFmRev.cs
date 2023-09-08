//PROJECT NAME: Production
//CLASS NAME: IPmfGetFmRev.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetFmRev
	{
		Guid? PmfGetFmRevFn(
			Guid? OrigFmRp,
			int? RevType = 0,
			int? SpecificRev = null);
	}
}

