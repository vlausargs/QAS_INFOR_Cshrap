//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_ShowTestsSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_ShowTestsSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_ShowTestsSSRSSp(string i_num,
		string pSite);
	}
}

