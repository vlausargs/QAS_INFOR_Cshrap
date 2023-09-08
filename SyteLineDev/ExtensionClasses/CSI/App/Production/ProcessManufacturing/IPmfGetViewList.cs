//PROJECT NAME: Production
//CLASS NAME: IPmfGetViewList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetViewList
	{
		int? PmfGetViewListSp();
	}
}

