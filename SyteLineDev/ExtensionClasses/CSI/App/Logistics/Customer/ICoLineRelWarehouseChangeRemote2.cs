//PROJECT NAME: Logistics
//CLASS NAME: ICoLineRelWarehouseChangeRemote2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoLineRelWarehouseChangeRemote2
	{
		int? CoLineRelWarehouseChangeRemote2Sp(
			string CoItemCoNum,
			int? CoItemCoLine,
			int? CoItemCoRelease,
			string OldWhse,
			string NewWhse);
	}
}

