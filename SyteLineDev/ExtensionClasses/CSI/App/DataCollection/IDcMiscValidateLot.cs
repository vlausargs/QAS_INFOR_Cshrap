//PROJECT NAME: DataCollection
//CLASS NAME: IDcMiscValidateLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcMiscValidateLot
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) DcMiscValidateLotSp(int? Connected,
		int? TransType,
		int? ItemQty,
		string Item,
		string Location,
		string Lot,
		string CurWhse,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

