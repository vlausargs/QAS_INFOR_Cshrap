//PROJECT NAME: Data
//CLASS NAME: IAPP_IncDateProcessingTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_IncDateProcessingTable
	{
		(int? ReturnCode,
			int? RecalcPertot,
			int? RecalcTick_Cal,
			int? RecalcMdayCal,
			int? RecalcTicks,
			string Status5,
			string Status6,
			string Status7,
			string Status8,
			string Status9,
			string InfoBar) APP_IncDateProcessingTableSp(
			int? Days,
			int? Years,
			string SpanUnit,
			string TableName,
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

