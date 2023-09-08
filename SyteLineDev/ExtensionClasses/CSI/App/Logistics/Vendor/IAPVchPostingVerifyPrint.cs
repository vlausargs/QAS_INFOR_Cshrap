//PROJECT NAME: Logistics
//CLASS NAME: IAPVchPostingVerifyPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAPVchPostingVerifyPrint
	{
		(int? ReturnCode, Guid? PSessionID,
		string Infobar) APVchPostingVerifyPrintSp(Guid? PSessionID,
		string Infobar);
	}
}

