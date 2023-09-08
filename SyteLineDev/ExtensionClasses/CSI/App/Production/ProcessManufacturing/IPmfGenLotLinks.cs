//PROJECT NAME: Production
//CLASS NAME: IPmfGenLotLinks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGenLotLinks
	{
		(int? ReturnCode,
			string Infobar,
			int? RowsAdded) PmfGenLotLinksSp(
			string Infobar = null,
			string Item = null,
			string Lot = null,
			int? UseLotFlag = 0,
			int? Level = 0,
			int? RowsAdded = 0,
			int? Cascade = 0,
			int? GenSession = 0);
	}
}

