//PROJECT NAME: Material
//CLASS NAME: IPhyinvSerialV2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhyinvSerialV2
	{
		(int? ReturnCode, string Infobar,
		string PromptMsg,
		string PromptButtons) PhyinvSerialV2Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string SerNum,
		int? Step,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
		string ImportDocId,
		Guid? CurrentRowPointer = null);
	}
}

