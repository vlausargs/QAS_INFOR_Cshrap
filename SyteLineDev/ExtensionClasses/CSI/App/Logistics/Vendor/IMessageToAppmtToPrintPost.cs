//PROJECT NAME: Logistics
//CLASS NAME: IMessageToAppmtToPrintPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IMessageToAppmtToPrintPost
	{
		(int? ReturnCode, string Infobar) MessageToAppmtToPrintPostSp(Guid? PSessionID,
		Guid? AppmtRowPointer,
		string Message,
		string Infobar);
	}
}

