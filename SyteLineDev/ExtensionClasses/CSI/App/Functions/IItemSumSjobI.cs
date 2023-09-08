//PROJECT NAME: Data
//CLASS NAME: IItemSumSjobI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemSumSjobI
	{
		(int? ReturnCode,
			decimal? ItemAsmSetup,
			decimal? ItemAsmRun,
			decimal? ItemAsmFixed,
			decimal? ItemAsmVar,
			decimal? ItemAsmOutside,
			decimal? ItemAsmMatl,
			decimal? ItemAsmTool,
			decimal? ItemAsmFixture,
			decimal? ItemAsmOther,
			decimal? ItemCompSetup,
			decimal? ItemCompRun,
			decimal? ItemCompFixed,
			decimal? ItemCompVar,
			decimal? ItemCompOutside,
			decimal? ItemCompMatl,
			decimal? ItemCompTool,
			decimal? ItemCompFixture,
			decimal? ItemCompOther,
			decimal? ItemSubMatl,
			string Infobar) ItemSumSjobISp(
			DateTime? EffectDate,
			string RollupType,
			decimal? ItemLotSize,
			string ItemJob,
			int? ItemSuffix,
			decimal? ItemAsmSetup,
			decimal? ItemAsmRun,
			decimal? ItemAsmFixed,
			decimal? ItemAsmVar,
			decimal? ItemAsmOutside,
			decimal? ItemAsmMatl,
			decimal? ItemAsmTool,
			decimal? ItemAsmFixture,
			decimal? ItemAsmOther,
			decimal? ItemCompSetup,
			decimal? ItemCompRun,
			decimal? ItemCompFixed,
			decimal? ItemCompVar,
			decimal? ItemCompOutside,
			decimal? ItemCompMatl,
			decimal? ItemCompTool,
			decimal? ItemCompFixture,
			decimal? ItemCompOther,
			decimal? ItemSubMatl,
			string Infobar,
			int? FromTemp = null,
			int? FromJobmatlTemp = null,
			int? CurrencyPlacesCp = null,
			int? CostItemAtWhse = null,
			string DefWhse = null);
	}
}

