//PROJECT NAME: Production
//CLASS NAME: IApsTransferInOrderId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsTransferInOrderId
	{
		string ApsTransferInOrderIdFn(
			string PTrnNum,
			int? PTrnLine);
	}
}

