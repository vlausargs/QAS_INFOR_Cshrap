//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSRSMTransferRequestCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSRSMTransferRequestCreate
	{
		(int? ReturnCode,
			string oTrnNum,
			int? oTrnLine,
			string Infobar) SSSFSRSMTransferRequestCreateSp(
			string iItem,
			string iDescription,
			decimal? iQty,
			string iUM,
			string iFromWhse,
			string iToWhse,
			DateTime? iDueDate,
			string oTrnNum,
			int? oTrnLine,
			string Infobar);
	}
}

