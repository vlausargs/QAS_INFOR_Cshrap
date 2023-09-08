//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReceivableTrackerLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReceivableTrackerLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBReceivableTrackerLineSp(string CustomerPartyID,
		string Invoice,
		int? Sequence,
        string ArTranType,
        string BankCode,
        string ArpmtType);
	}
}

