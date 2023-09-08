//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBBillToPartyMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBBillToPartyMaster
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBBillToPartyMasterSp(string CustNum);
	}
}

