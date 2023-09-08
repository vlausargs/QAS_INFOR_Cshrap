//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSalesOrderBlanketLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSalesOrderBlanketLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSalesOrderBlanketLineSp(string CoNum,
		int? CoLine);
	}
}

