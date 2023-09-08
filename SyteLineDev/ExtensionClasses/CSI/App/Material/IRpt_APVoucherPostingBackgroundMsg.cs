//PROJECT NAME: Material
//CLASS NAME: IRpt_APVoucherPostingBackgroundMsg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRpt_APVoucherPostingBackgroundMsg
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_APVoucherPostingBackgroundMsgSp(string SessionIdChar = null,
		string pSite = null);
	}
}

