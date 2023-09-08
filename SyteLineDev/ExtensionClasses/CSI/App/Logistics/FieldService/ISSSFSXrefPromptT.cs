//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefPromptT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefPromptT
	{
		(int? ReturnCode,
			string XrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSFSXrefPromptTSp(
			string FFile,
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

