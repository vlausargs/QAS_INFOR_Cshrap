//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPayFromPartyMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPayFromPartyMaster
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPayFromPartyMasterSp(string CustNum);
	}
}

