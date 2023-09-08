//PROJECT NAME: Logistics
//CLASS NAME: ISequencePreSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISequencePreSave
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) SequencePreSaveSp(string PType,
		string PCategory,
		int? PClosed,
		string PStartInv,
		string PEndInv,
		int? Action,
		Guid? PRowPointer = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null);
	}
}

