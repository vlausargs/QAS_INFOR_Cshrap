//PROJECT NAME: Finance
//CLASS NAME: IVoidAPPostedPaymentUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVoidAPPostedPaymentUpd
	{
		(int? ReturnCode, string Infobar) VoidAPPostedPaymentUpdSp(Guid? SessionID,
		Guid? PRowPointer,
		int? PProcessFlag,
		string Infobar);
	}
}

