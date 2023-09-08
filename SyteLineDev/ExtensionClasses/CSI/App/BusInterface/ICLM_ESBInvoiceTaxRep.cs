//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvoiceTaxRep.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvoiceTaxRep
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvoiceTaxRepSp(string InvNum,
		int? InvSeq);
	}
}

