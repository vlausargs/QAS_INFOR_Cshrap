//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_FamilyTestsSupplierWorksheetSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_FamilyTestsSupplierWorksheetSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_FamilyTestsSupplierWorksheetSSRSSp(string family = null,
		int? numentries = null,
		string pSite = null);
	}
}

