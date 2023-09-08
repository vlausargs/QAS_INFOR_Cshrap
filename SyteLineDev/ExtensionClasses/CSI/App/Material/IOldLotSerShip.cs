//PROJECT NAME: Material
//CLASS NAME: IOldLotSerShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IOldLotSerShip
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) OldLotSerShipSp(decimal? RefId,
		string RefType = null,
		Guid? ProcessId = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null);
	}
}

