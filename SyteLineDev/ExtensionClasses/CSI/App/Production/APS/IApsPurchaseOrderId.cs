//PROJECT NAME: Production
//CLASS NAME: IApsPurchaseOrderId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPurchaseOrderId
	{
		string ApsPurchaseOrderIdFn(
			string POrderNum,
			int? PLineNum,
			int? PRelease);
	}
}

