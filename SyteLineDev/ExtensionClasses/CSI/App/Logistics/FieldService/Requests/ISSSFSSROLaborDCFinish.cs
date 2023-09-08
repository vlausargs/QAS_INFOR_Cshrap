//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROLaborDCFinish.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROLaborDCFinish
	{
		(int? ReturnCode, string Infobar) SSSFSSROLaborDCFinishSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string WorkCode,
		decimal? HrsWorked,
		decimal? HrsToBill,
		DateTime? EndDate,
		string NoteContent,
		string Infobar = null,
		string BillCode = null,
		decimal? UnitCost = null,
		decimal? UnitRate = null,
		int? LogTran = 0,
		Guid? DcRowPointer = null);
	}
}

