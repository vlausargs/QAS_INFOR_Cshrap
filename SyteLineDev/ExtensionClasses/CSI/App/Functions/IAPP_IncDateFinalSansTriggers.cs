//PROJECT NAME: Data
//CLASS NAME: IAPP_IncDateFinalSansTriggers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_IncDateFinalSansTriggers
	{
		(int? ReturnCode,
			string InfoBar) APP_IncDateFinalSansTriggersSp(
			int? Days,
			int? Years,
			int? RecalcPertot,
			int? RecalcTick_Cal,
			int? RecalcMdayCal,
			int? RecalcTicks,
			string Status5,
			string Status6,
			string Status7,
			string Status8,
			string Status9,
			string InfoBar);
	}
}

