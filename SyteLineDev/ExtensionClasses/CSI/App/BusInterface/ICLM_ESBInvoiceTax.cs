//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvoiceTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvoiceTax
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvoiceTaxSp(string InvNum,
		int? InvSeq);
	}
}

