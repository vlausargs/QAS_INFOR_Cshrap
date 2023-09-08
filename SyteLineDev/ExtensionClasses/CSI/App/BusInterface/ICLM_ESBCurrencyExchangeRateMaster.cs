//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCurrencyExchangeRateMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCurrencyExchangeRateMaster
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCurrencyExchangeRateMasterSp(Guid? ID);
	}
}

