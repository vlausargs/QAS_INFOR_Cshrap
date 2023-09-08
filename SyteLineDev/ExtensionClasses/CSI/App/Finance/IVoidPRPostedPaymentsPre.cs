//PROJECT NAME: Finance
//CLASS NAME: IVoidPRPostedPaymentsPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVoidPRPostedPaymentsPre
	{
		(ICollectionLoadResponse Data, int? ReturnCode) VoidPRPostedPaymentsPreSp(Guid? SessionID,
		string pBankCode,
		int? pBegCheckNum,
		int? pEndCheckNum,
		string pOptdfEmplType);
	}
}

