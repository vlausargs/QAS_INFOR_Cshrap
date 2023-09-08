//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefCreateO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefCreateO
	{
		(int? ReturnCode,
			string oNewCoNum,
			int? oNewCoLine,
			string Infobar) SSSFSXrefCreateOSp(
			string iFromRefType,
			string iFromRefNum,
			int? iFRomRefLineSuf,
			int? iFromRefRelease,
			string iToRefNum,
			DateTime? iOrderDate,
			string iCustNum,
			int? iCustSeq,
			string iItem,
			string iItemDesc,
			decimal? iQtyOrderedConv,
			string iUM,
			string oNewCoNum,
			int? oNewCoLine,
			string Infobar);
	}
}

