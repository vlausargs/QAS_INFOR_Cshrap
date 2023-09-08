//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvoiceTaxMX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvoiceTaxMX
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvoiceTaxMXSp(
			string InvNum,
			int? InvSeq);
	}
}

