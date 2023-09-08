//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSupplierBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSupplierBalance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSupplierBalanceSp(string VendNum);
	}
}

