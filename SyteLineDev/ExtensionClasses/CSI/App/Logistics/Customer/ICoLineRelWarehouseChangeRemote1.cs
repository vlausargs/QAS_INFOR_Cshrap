//PROJECT NAME: Logistics
//CLASS NAME: ICoLineRelWarehouseChangeRemote1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoLineRelWarehouseChangeRemote1
	{
		(int? ReturnCode,
			string Infobar) CoLineRelWarehouseChangeRemote1Sp(
			string CoOrigSite,
			string CoItemCoNum,
			int? CoItemCoLine,
			int? CoItemCoRelease,
			string OldWhse,
			string NewWhse,
			string CoItemItem,
			string Infobar);
	}
}

