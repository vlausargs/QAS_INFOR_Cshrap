//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefCreateJ.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefCreateJ
	{
		(int? ReturnCode,
			string CurJob,
			int? CurSuffix,
			string Infobar) SSSFSXrefCreateJSp(
			string FromRefType,
			string FromRefNum,
			int? FromRefLineSuf,
			int? FromRefRelease,
			string ToRefNum,
			int? ToRefLineSuf,
			string CustNum,
			string Item,
			string ItemDescription,
			decimal? QtyOrdered,
			DateTime? DueDate,
			string Whse,
			string CurJob,
			int? CurSuffix,
			string Infobar);
	}
}

