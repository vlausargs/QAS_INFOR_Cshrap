//PROJECT NAME: Material
//CLASS NAME: ITrrcvSerError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITrrcvSerError
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) TrrcvSerErrorSp(string Site,
		string Item,
		string SerNum,
		int? UseExisting,
		int? SelectFlag = 1,
		string FromSite = null,
		string ToSite = null,
		string FobSite = null,
		int? FromSerialTracked = null,
		int? ToSerialTracked = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		decimal? QtyReceived = null);
	}
}

