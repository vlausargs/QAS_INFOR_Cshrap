//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIPayOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIPayOne
	{
		(int? ReturnCode,
			int? oSuccess,
			string Infobar) SSSCCIPayOneSp(
			string iInvNum,
			string iCustNum,
			int? oSuccess,
			string Infobar,
			int? TaskID = null);
	}
}

