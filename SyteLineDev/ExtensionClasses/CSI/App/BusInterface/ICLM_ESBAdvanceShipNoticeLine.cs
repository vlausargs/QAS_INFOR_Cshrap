//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBAdvanceShipNoticeLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBAdvanceShipNoticeLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBAdvanceShipNoticeLineSP(string TrnsNum,
		DateTime? SchShipDateTime);
	}
}

