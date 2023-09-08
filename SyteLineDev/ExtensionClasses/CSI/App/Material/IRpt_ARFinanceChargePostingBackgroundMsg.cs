//PROJECT NAME: Material
//CLASS NAME: IRpt_ARFinanceChargePostingBackgroundMsg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRpt_ARFinanceChargePostingBackgroundMsg
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARFinanceChargePostingBackgroundMsgSp(string SessionIdChar = null,
		string PSite = null);
	}
}

