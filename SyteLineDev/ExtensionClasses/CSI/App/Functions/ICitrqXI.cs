//PROJECT NAME: Data
//CLASS NAME: ICitrqXI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICitrqXI
	{
		(int? ReturnCode,
			string TXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) CitrqXISp(
			string SourceFile,
			string SourceRefType,
			string SourceRefNum,
			int? SourceRefLineSuf,
			int? SourceRefRelease,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			decimal? PQtyOrdered,
			DateTime? PDueDate,
			string PRefType,
			string PStat,
			string PStatFldName,
			string PItem,
			string PItemDescription,
			decimal? PItemCurUCost,
			string PItemUM,
			string PPrefix,
			string TXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

