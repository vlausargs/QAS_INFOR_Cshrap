//PROJECT NAME: Logistics
//CLASS NAME: IInvAdjS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvAdjS
	{
		(int? ReturnCode, decimal? PSalesTax,
		decimal? PSalesTax2,
		decimal? PLineNet,
		decimal? PPrice,
		int? PSeq,
		string PromptMsg,
		string PromptButtons,
		string InfoBar) InvAdjSSp(string PMode,
		string PRecidCo,
		decimal? PMiscCharges,
		decimal? PFreight,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		decimal? PLineNet,
		decimal? PPrice,
		int? PSeq,
		string PromptMsg,
		string PromptButtons,
		string InfoBar);
	}
}

