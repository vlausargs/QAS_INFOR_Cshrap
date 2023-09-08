//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_ShowCARCostsSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_ShowCARCostsSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_ShowCARCostsSSRSSp(string car = null,
		string pSite = null);
	}
}

