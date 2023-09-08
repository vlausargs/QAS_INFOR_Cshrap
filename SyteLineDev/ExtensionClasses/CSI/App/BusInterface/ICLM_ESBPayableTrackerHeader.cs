//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPayableTrackerHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPayableTrackerHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPayableTrackerHeaderSp(string SupplierPartyID,
		int? Voucher,
		int? Sequence);
	}
}

