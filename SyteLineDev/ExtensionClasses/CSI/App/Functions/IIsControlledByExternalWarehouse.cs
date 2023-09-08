//PROJECT NAME: Data
//CLASS NAME: IIsControlledByExternalWarehouse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsControlledByExternalWarehouse
	{
		int? IsControlledByExternalWarehouseFn(
			string PWhse,
			string PSite);
	}
}

