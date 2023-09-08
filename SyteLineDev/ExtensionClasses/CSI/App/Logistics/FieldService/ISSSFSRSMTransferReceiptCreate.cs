//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSRSMTransferReceiptCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSRSMTransferReceiptCreate
	{
		(int? ReturnCode,
			string Infobar) SSSFSRSMTransferReceiptCreateSp(
			string iTrnNum,
			int? iTrnLine,
			string iLot,
			string iSerNum,
			string iToLoc,
			decimal? iQtyReceived,
			string Infobar);
	}
}

