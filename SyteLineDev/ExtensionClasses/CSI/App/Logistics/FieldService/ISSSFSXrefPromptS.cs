//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefPromptS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefPromptS
	{
		(int? ReturnCode,
			string PXrefDestination,
			int? CreateFlag,
			int? CreateLineFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSFSXrefPromptSSp(
			string PToFile,
			string PToRefNum,
			int? PToRefLineSuf,
			int? PToRefRelease,
			string PFromFile,
			string PFromRefType,
			string PFromRefNum,
			int? PFromRefLineSuf,
			int? PFromRefRelease,
			string PCustNum,
			int? PCustSeq,
			string PXrefDestination,
			int? CreateFlag,
			int? CreateLineFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

