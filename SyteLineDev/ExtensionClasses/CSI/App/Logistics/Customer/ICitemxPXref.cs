//PROJECT NAME: Logistics
//CLASS NAME: ICitemxPXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICitemxPXref
	{
		(int? ReturnCode,
			string CurPoNum,
			int? CurPoLine,
			int? CurPoRel,
			string Infobar) CitemxPXrefSp(
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
			string PItemDescription,
			string PStat,
			string PPrefix,
			int? PoChangeOrd,
			string CurPoNum,
			int? CurPoLine,
			int? CurPoRel,
			string Infobar,
			string ExportType);
	}
}

