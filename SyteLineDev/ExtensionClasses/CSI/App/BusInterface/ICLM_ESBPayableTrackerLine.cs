//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPayableTrackerLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPayableTrackerLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPayableTrackerLineSp(string SupplierPartyID,
		int? Voucher,
		int? Sequence);
	}
}

