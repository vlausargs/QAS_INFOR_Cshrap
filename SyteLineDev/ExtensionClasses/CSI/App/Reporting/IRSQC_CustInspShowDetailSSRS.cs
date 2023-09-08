//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_CustInspShowDetailSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_CustInspShowDetailSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_CustInspShowDetailSSRSSp(string i_conum,
		int? i_coline,
		int? i_corel,
		string psite);
	}
}

