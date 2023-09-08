//PROJECT NAME: Material
//CLASS NAME: IItemQtyDetl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemQtyDetl
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? CallForm) ItemQtyDetlSp(string Site,
		string Type,
		string WhseType,
		string Whse,
		string Item,
		string Loc,
		string Lot,
		decimal? DeltaQty,
		int? Return,
		string Action,
		string TrnNum,
		int? TrnLine,
		decimal? TransNum,
		decimal? RsvdNum,
		string Stat,
		int? Byprod,
		string Workkey,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId = null,
		int? CallForm = 0);
	}
}

