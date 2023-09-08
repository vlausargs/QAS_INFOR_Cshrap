//PROJECT NAME: Finance
//CLASS NAME: IVoidPRPostedPayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVoidPRPostedPayment
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) VoidPRPostedPaymentSp(Guid? pRowPointer,
		Guid? SessionID,
		int? ProcessFlag,
		string Infobar);
	}
}

