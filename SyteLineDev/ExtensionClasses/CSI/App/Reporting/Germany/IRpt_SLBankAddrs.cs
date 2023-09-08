//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SLBankAddrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.Germany
{
	public interface IRpt_SLBankAddrs : IRpt_GOBDUMediaService
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLBankAddrsSp(
			DateTime? TransDateBeg,
			DateTime? TransDateEnd,
			string SiteID);
	}
}

