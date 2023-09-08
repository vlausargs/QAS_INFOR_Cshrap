//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefPromptJ.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefPromptJ
	{
		(int? ReturnCode,
			string TXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSFSXrefPromptJSp(
			string FFile,
			string RefNum,
			int? RefLineSuf,
			string Item,
			string TXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

