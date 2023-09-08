//PROJECT NAME: Finance
//CLASS NAME: IVoidPRPostedPaymentDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVoidPRPostedPaymentDel
	{
		(int? ReturnCode, string Infobar) VoidPRPostedPaymentDelSp(Guid? SessionID,
		string Infobar);
	}
}

