//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitWarrSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitWarrSave
	{
		(int? ReturnCode, string Infobar) SSSFSUnitWarrSaveSp(int? CompId,
		string WarrCode,
		DateTime? StartDate,
		DateTime? EndDate,
		int? StartMeterAmt,
		int? EndMeterAmt,
		string Infobar);
	}
}

