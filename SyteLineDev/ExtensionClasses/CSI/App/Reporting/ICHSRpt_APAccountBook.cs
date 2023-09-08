//PROJECT NAME: Reporting
//CLASS NAME: ICHSRpt_APAccountBook.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ICHSRpt_APAccountBook
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_APAccountBookSp(string BegVendNum,
		string EndVendNum,
		DateTime? BegDate,
		DateTime? EndDate,
		string CurrencyCode,
		int? ViewDetailStats,
		string pSite = null);
	}
}

