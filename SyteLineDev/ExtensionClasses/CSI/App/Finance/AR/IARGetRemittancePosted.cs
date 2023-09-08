//PROJECT NAME: Finance
//CLASS NAME: IARGetRemittancePosted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARGetRemittancePosted
	{
		int? ARGetRemittancePostedFn(
			string pBankCode,
			string pCustNum,
			int? pDraftNum,
			string pStat);
	}
}

