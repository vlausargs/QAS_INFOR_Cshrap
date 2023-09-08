//PROJECT NAME: Data
//CLASS NAME: ITrnrX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrnrX
	{
		(int? ReturnCode,
			string XrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) TrnrXSp(
			string SourceFile,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Item,
			string XrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

