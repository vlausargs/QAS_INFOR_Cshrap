//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSrpt_WarrantyExpiration.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSrpt_WarrantyExpiration
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSrpt_WarrantyExpirationSp(string beg_Item,
		string end_Item,
		string beg_ChildItem,
		string end_ChildItem,
		DateTime? beg_warr_expire,
		DateTime? end_warr_expire,
		int? IncludeSub,
		string pSite = null);
	}
}

