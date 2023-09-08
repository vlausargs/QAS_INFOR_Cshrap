//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSupplierPartyMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSupplierPartyMaster
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSupplierPartyMasterSp(string VendNum);
	}
}

