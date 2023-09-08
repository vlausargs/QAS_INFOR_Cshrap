//PROJECT NAME: Material
//CLASS NAME: IPhyinvLotV2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhyinvLotV2
	{
		(int? ReturnCode, string Infobar,
		string PromptMsg,
		string PromptButtons) PhyinvLotV2Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		int? Step,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
		string Revision = null);
	}
}

