//PROJECT NAME: Finance
//CLASS NAME: IVoidAPPostedPaymentDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVoidAPPostedPaymentDel
	{
		(int? ReturnCode, string Infobar) VoidAPPostedPaymentDelSp(Guid? SessionID,
		string Infobar);
	}
}

