//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSalesOrderLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSalesOrderLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSalesOrderLineSp(string CoNum);
	}
}

