//PROJECT NAME: Material
//CLASS NAME: ITrcombSerError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITrcombSerError
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) TrcombSerErrorSp(string Site,
		string Item,
		string SerNum,
		int? UseExisting,
		int? SelectFlag = 1,
		string FromSite = null,
		string ToSite = null,
		int? FromSerialTracked = null,
		int? ToSerialTracked = null,
		decimal? QtyShip = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null);
	}
}

