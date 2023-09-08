//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefPromptO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefPromptO
	{
		(int? ReturnCode,
			string XrefDestination,
			int? CreateFlag,
			int? CreateLineFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSFSXrefPromptOSp(
			string FCoFile,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Item,
			string TCoFile,
			string XrefDestination,
			int? CreateFlag,
			int? CreateLineFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar,
			string PCustNum,
			int? PCustSeq);
	}
}

