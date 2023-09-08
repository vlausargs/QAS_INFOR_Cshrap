//PROJECT NAME: Material
//CLASS NAME: IRValContainer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRValContainer
	{
		(int? ReturnCode, string ContainerNum,
		int? AddContainer,
		string PromptMsg,
		string PromptButtons,
		string Infobar) RValContainerSp(string ContainerNum,
		string Whse,
		string Loc,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? AddContainer,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

