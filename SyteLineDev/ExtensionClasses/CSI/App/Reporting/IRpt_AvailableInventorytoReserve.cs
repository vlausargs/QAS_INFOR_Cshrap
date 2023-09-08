//PROJECT NAME: Reporting
//CLASS NAME: IRpt_AvailableInventorytoReserve.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_AvailableInventorytoReserve
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_AvailableInventorytoReserveSp(string WhseStarting = null,
		string WhseEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string pSite = null,
		int? IncludeSerialNumber = null);
	}
}

