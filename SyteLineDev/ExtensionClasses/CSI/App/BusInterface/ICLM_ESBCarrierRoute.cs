//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCarrierRoute.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCarrierRoute
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCarrierRouteSp(string CarrierRouteID);
	}
}

