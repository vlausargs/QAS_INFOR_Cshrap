//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_ShowCarTestsSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_ShowCarTestsSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_ShowCarTestsSSRSSp(string i_num = null,
		string pSite = null);
	}
}

