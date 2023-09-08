//PROJECT NAME: Logistics
//CLASS NAME: IAptrxg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAptrxg
	{
		(int? ReturnCode, int? RCheck1,
		decimal? RSalesTax1,
		int? RCheck2,
		decimal? RSalesTax2,
		string PromptMsg,
		string PromptButtons,
		string Infobar) AptrxgSp(int? PAskFlag,
		Guid? PRecidAptrx,
		int? RCheck1,
		decimal? RSalesTax1,
		int? RCheck2,
		decimal? RSalesTax2,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

