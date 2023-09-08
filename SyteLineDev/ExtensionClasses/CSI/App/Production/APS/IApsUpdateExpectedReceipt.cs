//PROJECT NAME: Production
//CLASS NAME: IApsUpdateExpectedReceipt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsUpdateExpectedReceipt
	{
		int? ApsUpdateExpectedReceiptSp(
			int? AltNo,
			string OrderId);
	}
}

