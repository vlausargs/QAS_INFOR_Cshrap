//PROJECT NAME: Production
//CLASS NAME: IPmfto2GenLotLinks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfto2GenLotLinks
	{
		(int? ReturnCode,
			string Infobar) Pmfto2GenLotLinksSp(
			int? SessionID,
			string item,
			string lot = null,
			string ser = null,
			int? forward = 1,
			int? back = 1,
			string Infobar = null);
	}
}

