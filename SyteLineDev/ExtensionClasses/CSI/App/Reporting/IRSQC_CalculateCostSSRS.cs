//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_CalculateCostSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_CalculateCostSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_CalculateCostSSRSSp(string i_num = null,
		string pSite = null);
	}
}

