//PROJECT NAME: Data
//CLASS NAME: IItemlocCheckI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemlocCheckI
	{
		(int? ReturnCode,
			string Infobar,
			string Prompt,
			string PromptButtons) ItemlocCheckISp(
			string Item,
			string Whse,
			string Site,
			string Loc,
			int? ForTransitLoc = 0,
			int? Outgoing = 0,
			string Infobar = null,
			string Prompt = null,
			string PromptButtons = null);
	}
}

