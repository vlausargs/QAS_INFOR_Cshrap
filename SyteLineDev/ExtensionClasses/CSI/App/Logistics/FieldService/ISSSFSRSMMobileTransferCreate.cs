//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSRSMMobileTransferCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSRSMMobileTransferCreate
	{
		(int? ReturnCode,
			string oTrnNum,
			int? oTrnLine,
			string Infobar) SSSFSRSMMobileTransferCreateSp(
			DateTime? iTransDate,
			string iItem,
			string iDescription,
			decimal? iQty,
			string iLot,
			string iSerNum,
			string iFromWhse,
			string iFromLoc,
			string iToWhse,
			string iToLoc,
			string oTrnNum,
			int? oTrnLine,
			string Infobar);
	}
}

