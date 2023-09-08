//PROJECT NAME: Material
//CLASS NAME: ISerialNumUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ISerialNumUsed
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) SerialNumUsedSp(string SerNum,
		int? Mode = 1,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		decimal? Quantity = null,
		string Item = null);
	}
}

