//PROJECT NAME: Production
//CLASS NAME: IPmftPmfGenLotLinks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmftPmfGenLotLinks
	{
		(int? ReturnCode,
			string Infobar) PmftPmfGenLotLinksSp(
			int? SessionID,
			string item,
			string lot = null,
			string ser = null,
			int? forward = 1,
			int? back = 1,
			string Infobar = null);
	}
}

