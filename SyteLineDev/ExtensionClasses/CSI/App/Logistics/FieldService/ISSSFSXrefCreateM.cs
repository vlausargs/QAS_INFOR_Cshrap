//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefCreateM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefCreateM
	{
		(int? ReturnCode,
			string NewRmaNum,
			int? NewRmaLine,
			string Infobar) SSSFSXrefCreateMSp(
			string FromRefType,
			string FromRefNum,
			int? FromRefLineSuf,
			int? FromRefRelease,
			string ToRefNum,
			int? ToRefLine,
			string Item,
			string Whse,
			decimal? Qty,
			string CustNum,
			DateTime? OrderDate,
			string UM,
			string Desc,
			string NewRmaNum,
			int? NewRmaLine,
			string Infobar);
	}
}

