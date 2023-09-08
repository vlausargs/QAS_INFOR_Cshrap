//PROJECT NAME: Material
//CLASS NAME: IRpt_InvoicePostingBackgroundMsg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRpt_InvoicePostingBackgroundMsg
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoicePostingBackgroundMsgSp(string SessionIdChar = null,
		string PSite = null);
	}
}

