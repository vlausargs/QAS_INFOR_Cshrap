//PROJECT NAME: Reporting
//CLASS NAME: IRpt_Ap01RIUnposted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_Ap01RIUnposted
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_Ap01RIUnpostedSp(string PPayType = null,
		string pSite = null,
		string PEFTFormat = null);
	}
}

