//PROJECT NAME: Production
//CLASS NAME: IPmfFormatDec.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFormatDec
	{
		string PmfFormatDecFn(
			decimal? Value,
			int? MaxDecimals);
	}
}

