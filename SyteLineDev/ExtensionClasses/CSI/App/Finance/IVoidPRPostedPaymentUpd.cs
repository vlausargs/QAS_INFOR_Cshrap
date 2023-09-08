//PROJECT NAME: Finance
//CLASS NAME: IVoidPRPostedPaymentUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVoidPRPostedPaymentUpd
	{
		(int? ReturnCode, string Infobar) VoidPRPostedPaymentUpdSp(Guid? SessionID,
		Guid? PRowPointer,
		int? PProcessFlag,
		string Infobar);
	}
}

