//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VoidAPPostedPayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VoidAPPostedPayment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoidAPPostedPaymentSp(string SessionIDChar,
		string BankCode,
		int? DisplayHeader = 0,
		int? BegCheckNum = null,
		int? EndCheckNum = null,
		string pSite = null,
		string BGUser = null);
	}
}

