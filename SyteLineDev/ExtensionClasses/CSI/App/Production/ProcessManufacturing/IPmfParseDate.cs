//PROJECT NAME: Production
//CLASS NAME: IPmfParseDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfParseDate
	{
		DateTime? PmfParseDateFn(
			DateTime? dt);
	}
}

