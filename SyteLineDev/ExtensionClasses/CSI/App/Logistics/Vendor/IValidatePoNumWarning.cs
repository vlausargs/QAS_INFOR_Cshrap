//PROJECT NAME: Logistics
//CLASS NAME: IValidatePoNumWarning.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidatePoNumWarning
	{
		(int? ReturnCode, string PromptMsg,
		string Buttons,
		string Infobar) ValidatePoNumWarningSp(string PoNum,
		string PromptMsg,
		string Buttons,
		string Infobar);
	}
}

