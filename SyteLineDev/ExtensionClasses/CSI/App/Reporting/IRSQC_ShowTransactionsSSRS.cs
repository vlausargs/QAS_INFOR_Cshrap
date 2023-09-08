//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_ShowTransactionsSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_ShowTransactionsSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_ShowTransactionsSSRSSp(string i_num,
		string pSite);
	}
}

