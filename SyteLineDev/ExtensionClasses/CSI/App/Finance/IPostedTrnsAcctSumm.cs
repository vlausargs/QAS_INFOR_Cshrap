//PROJECT NAME: Finance
//CLASS NAME: IPostedTrnsAcctSumm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPostedTrnsAcctSumm
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) PostedTrnsAcctSummSp(string PAcct,
		int? PFiscalYear,
		string Infobar,
		string FilterString);
	}
}

