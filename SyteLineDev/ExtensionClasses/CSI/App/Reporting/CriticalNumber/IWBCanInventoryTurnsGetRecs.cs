//PROJECT NAME: Reporting
//CLASS NAME: IWBCanInventoryTurnsGetRecs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.CriticalNumber
{
	public interface IWBCanInventoryTurnsGetRecs
	{
		int? WBCanInventoryTurnsGetRecsSp(
			int? KPINum,
			DateTime? AsOfDate,
			string Item = null,
			string Whse = null,
			string ProductCode = null,
			string FamilyCode = null);
	}
}

