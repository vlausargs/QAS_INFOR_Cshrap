//PROJECT NAME: Data
//CLASS NAME: IValidPoBeforeSyncCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidPoBeforeSyncCo
	{
		(int? ReturnCode,
			string Infobar) ValidPoBeforeSyncCoSp(
			string DemandingPO,
			int? UpdateHeader = 0,
			int? BlanketLine = 0,
			int? PoItemsPoLine = null,
			int? PoItemsPoRelease = null,
			string PoItems = null,
			int? PreassignLots = null,
			int? PreassignSerials = null,
			int? AutoReceiveDemandingSitePO = null,
			string Infobar = null);
	}
}

