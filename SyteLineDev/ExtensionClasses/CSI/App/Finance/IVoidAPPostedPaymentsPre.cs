//PROJECT NAME: Finance
//CLASS NAME: IVoidAPPostedPaymentsPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVoidAPPostedPaymentsPre
	{
		(ICollectionLoadResponse Data, int? ReturnCode) VoidAPPostedPaymentsPreSp(Guid? SessionID,
		string pBankCode,
		int? pBegCheckNum,
		int? pEndCheckNum,
		string PayType);
	}
}

