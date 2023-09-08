//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSalesOrderSubLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSalesOrderSubLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSalesOrderSubLineSp(string CoitemItem);
	}
}

