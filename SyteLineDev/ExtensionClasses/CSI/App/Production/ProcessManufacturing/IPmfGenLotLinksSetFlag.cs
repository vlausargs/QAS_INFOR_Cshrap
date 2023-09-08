//PROJECT NAME: Production
//CLASS NAME: IPmfGenLotLinksSetFlag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGenLotLinksSetFlag
	{
		(int? ReturnCode,
			string Infobar) PmfGenLotLinksSetFlagSp(
			string Infobar = null);
	}
}

