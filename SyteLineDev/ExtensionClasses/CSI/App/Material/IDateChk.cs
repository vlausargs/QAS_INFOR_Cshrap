//PROJECT NAME: Material
//CLASS NAME: IDateChk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IDateChk
	{
		(int? ReturnCode, string Infobar,
		string PromptMsg,
		string PromptButtons) DateChkSp(DateTime? PDate = null,
		string FieldLabel = null,
		string FunctionLabel = null,
		string Infobar = null,
		string PromptMsg = null,
		string PromptButtons = null);
	}
}

