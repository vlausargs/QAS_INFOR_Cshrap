//PROJECT NAME: Material
//CLASS NAME: IValidateNonNettableItemLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IValidateNonNettableItemLoc
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateNonNettableItemLocSp(string Item,
		string Whse,
		string Loc,
		decimal? TcQtuToReceive,
		int? TtRcvDrReturn,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

