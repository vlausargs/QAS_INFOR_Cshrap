//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPayableHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPayableHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPayableHeaderSp(string SupplierPartyID,
		int? Voucher);
	}
}

