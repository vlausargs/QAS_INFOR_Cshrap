//PROJECT NAME: Production
//CLASS NAME: IPmfGetNextCounter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetNextCounter
	{
		(int? ReturnCode,
			string InfoBar,
			long? NextNo) PmfGetNextCounterSp(
			string InfoBar = null,
			string CounterName = null,
			long? NextNo = 0);
	}
}

