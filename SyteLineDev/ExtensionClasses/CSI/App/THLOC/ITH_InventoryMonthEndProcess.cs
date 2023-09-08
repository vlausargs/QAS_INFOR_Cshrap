//PROJECT NAME: THLOC
//CLASS NAME: ITH_InventoryMonthEndProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.THLOC
{
	public interface ITH_InventoryMonthEndProcess
	{
		(int? ReturnCode, string Infobar) TH_InventoryMonthEndProcessSp(DateTime? pDateStarting,
		DateTime? pDateEnding,
		string pItemStarting,
		string pItemEnding,
		string pWhseStarting,
		string pWhseEnding,
		string pLocStarting,
		string pLocEnding,
		string Infobar);
	}
}

