//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSDrpGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSDrpGen
	{
		(int? ReturnCode, string Infobar) SSSFSDrpGenSp(string FormCaption,
		int? BgTaskID,
		string Infobar,
		int? kDebugLevel = 0,
		int? kDebugQty = 0,
		string StartingItem = null,
		string EndingItem = null);
	}
}

