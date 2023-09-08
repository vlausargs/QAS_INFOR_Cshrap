//PROJECT NAME: Production
//CLASS NAME: IPmfLotInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfLotInit
	{
		(int? ReturnCode,
			string InfoBar) PmfLotInitSp(
			string InfoBar = null);
	}
}

