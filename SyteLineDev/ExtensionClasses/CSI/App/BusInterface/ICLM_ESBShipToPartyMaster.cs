//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipToPartyMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBShipToPartyMaster
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBShipToPartyMasterSp(string CustNum,
		int? CustSeq);
	}
}

