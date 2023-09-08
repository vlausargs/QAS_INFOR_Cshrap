//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvoiceTaxRepMX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvoiceTaxRepMX
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvoiceTaxRepMXSp(
			string InvNum,
			int? InvSeq);
	}
}

