//PROJECT NAME: Data
//CLASS NAME: IEnableExternalWarehouse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEnableExternalWarehouse
	{
		int? EnableExternalWarehouseFn(
			string PWhse);
	}
}

