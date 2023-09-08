//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReceivableTrackerHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReceivableTrackerHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBReceivableTrackerHeaderSp(string CustomerPartyID,
		string Invoice,
		int? Sequence,
        string ArTranType,
        string BankCode,
        string ArpmtType);
	}
}

