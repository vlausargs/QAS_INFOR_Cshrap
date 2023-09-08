//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSerialInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSerialInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSerialInvoiceSp(string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string InvNum);
	}
}

