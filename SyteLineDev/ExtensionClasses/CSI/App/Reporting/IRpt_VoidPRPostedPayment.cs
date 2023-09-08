//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VoidPRPostedPayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VoidPRPostedPayment
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_VoidPRPostedPaymentSp(string SessionIDChar,
		string BankCode,
		int? BegCheckNum,
		int? EndCheckNum,
		string EmplType,
		int? DisplayHeader = 0,
		string Infobar = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

