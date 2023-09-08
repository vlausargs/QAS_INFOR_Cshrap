//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PriceChangeError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PriceChangeError
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PriceChangeErrorSp(string SessionIDChar = null,
		int? DisplayHeader = 0,
		string pSite = null);
	}
}

