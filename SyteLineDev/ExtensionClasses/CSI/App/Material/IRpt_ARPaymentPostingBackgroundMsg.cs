//PROJECT NAME: Material
//CLASS NAME: IRpt_ARPaymentPostingBackgroundMsg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRpt_ARPaymentPostingBackgroundMsg
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARPaymentPostingBackgroundMsgSp(string SessionIdChar = null,
		string pSite = null);
	}
}

