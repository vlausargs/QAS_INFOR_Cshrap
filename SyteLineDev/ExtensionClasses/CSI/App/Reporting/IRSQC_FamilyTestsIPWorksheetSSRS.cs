//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_FamilyTestsIPWorksheetSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_FamilyTestsIPWorksheetSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_FamilyTestsIPWorksheetSSRSSp(string family,
		int? numentries,
		string pSite);
	}
}

