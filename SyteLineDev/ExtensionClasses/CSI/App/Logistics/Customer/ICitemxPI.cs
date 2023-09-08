//PROJECT NAME: Logistics
//CLASS NAME: ICitemxPI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICitemxPI
	{
		(int? ReturnCode,
			string PXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) CitemxPISp(
			string SourceFile,
			string SourceRefType,
			string SourceRefNum,
			int? SourceRefLineSuf,
			int? SourceRefRelease,
			string SourceItem,
			string SourceUM,
			string PPoitemWhse,
			string PPoitemRefNum,
			int? PPoitemRefLineSuf,
			int? PPoitemRefRelease,
			decimal? PPoitemQtyOrdered,
			DateTime? PPoitemDueDate,
			string PPoitemRefType,
			string ItemDescription,
			string Stat,
			string Prefix,
			string PXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

