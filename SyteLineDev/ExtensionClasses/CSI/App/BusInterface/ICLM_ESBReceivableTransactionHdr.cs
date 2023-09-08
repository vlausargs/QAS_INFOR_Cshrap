//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReceivableTransactionHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReceivableTransactionHdr
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBReceivableTransactionHdrSp(string CustNum,
		string invNum);
	}
}

