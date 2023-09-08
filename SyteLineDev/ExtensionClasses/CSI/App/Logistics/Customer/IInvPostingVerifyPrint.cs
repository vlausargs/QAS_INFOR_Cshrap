//PROJECT NAME: Logistics
//CLASS NAME: IInvPostingVerifyPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvPostingVerifyPrint
	{
		(int? ReturnCode, Guid? PSessionID,
		string Infobar) InvPostingVerifyPrintSp(Guid? PSessionID,
		string Infobar,
		string ToSite = null);
	}
}

