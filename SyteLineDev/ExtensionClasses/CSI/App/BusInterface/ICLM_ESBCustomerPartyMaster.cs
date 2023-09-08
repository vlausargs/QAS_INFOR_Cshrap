//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCustomerPartyMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCustomerPartyMaster
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCustomerPartyMasterSp(string CustNum);
	}
}

