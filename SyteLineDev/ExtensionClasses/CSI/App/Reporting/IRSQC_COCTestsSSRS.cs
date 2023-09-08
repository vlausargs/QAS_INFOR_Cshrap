//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_COCTestsSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_COCTestsSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_COCTestsSSRSSp(int? i_num,
		string pSite = null);
	}
}

