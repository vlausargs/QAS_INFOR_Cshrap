//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefPromptM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefPromptM
	{
		(int? ReturnCode,
			string XrefDestination,
			int? CreateFlag,
			int? CreateLineFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSFSXrefPromptMSp(
			string FRmaFile,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Item,
			string TRmaFile,
			string XrefDestination,
			int? CreateFlag,
			int? CreateLineFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

