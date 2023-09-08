//PROJECT NAME: Data
//CLASS NAME: ISvallotAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISvallotAll
	{
		(int? ReturnCode,
			int? AddLot,
			string PromptAddMsg,
			string PromptAddButtons,
			string PromptExpLotMsg,
			string PromptExpLotButtons,
			string Infobar) SvallotAllSp(
			string Whse,
			string Item,
			string Loc,
			string Lot,
			string Action,
			int? NoPerm = 0,
			string Title = null,
			int? AddLot = null,
			string PromptAddMsg = null,
			string PromptAddButtons = null,
			string PromptExpLotMsg = null,
			string PromptExpLotButtons = null,
			string Infobar = null,
			string Site = null);
	}
}

