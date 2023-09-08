//PROJECT NAME: Material
//CLASS NAME: IRemoteLotRvallot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRemoteLotRvallot
	{
		(int? ReturnCode, int? AddLot,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string TrxRestrictCode) RemoteLotRvallotSp(string Item,
		string Lot,
		string RemoteSiteLot,
		int? AddLot,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string Site = null,
		string TrxRestrictCode = null);
	}
}

