//PROJECT NAME: Material
//CLASS NAME: ITransferItemValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITransferItemValid
	{
		(int? ReturnCode, string ItemDesc,
		int? Kit,
		string Infobar,
		string PromptMsgOS,
		string PromptBtnsOS) TransferItemValidSp(string Item,
		decimal? Qty,
		string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		string ItemDesc,
		int? Kit,
		string Infobar,
		string PromptMsgOS = null,
		string PromptBtnsOS = null);
	}
}

