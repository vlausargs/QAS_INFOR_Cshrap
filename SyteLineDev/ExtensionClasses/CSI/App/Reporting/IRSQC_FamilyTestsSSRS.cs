//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_FamilyTestsSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_FamilyTestsSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_FamilyTestsSSRSSp(string family,
		string pSite);
	}
}

