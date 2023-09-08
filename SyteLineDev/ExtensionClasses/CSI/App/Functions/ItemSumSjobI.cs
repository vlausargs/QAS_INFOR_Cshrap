//PROJECT NAME: Data
//CLASS NAME: ItemSumSjobI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemSumSjobI : IItemSumSjobI
	{
		readonly IApplicationDB appDB;
		
		public ItemSumSjobI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string DefWhse = null)
		{
			DateType _EffectDate = EffectDate;
			StringType _RollupType = RollupType;
			QtyPerType _ItemLotSize = ItemLotSize;
			JobType _ItemJob = ItemJob;
			SuffixType _ItemSuffix = ItemSuffix;
			CostPrcType _ItemAsmSetup = ItemAsmSetup;
			CostPrcType _ItemAsmRun = ItemAsmRun;
			CostPrcType _ItemAsmFixed = ItemAsmFixed;
			CostPrcType _ItemAsmVar = ItemAsmVar;
			CostPrcType _ItemAsmOutside = ItemAsmOutside;
			CostPrcType _ItemAsmMatl = ItemAsmMatl;
			CostPrcType _ItemAsmTool = ItemAsmTool;
			CostPrcType _ItemAsmFixture = ItemAsmFixture;
			CostPrcType _ItemAsmOther = ItemAsmOther;
			CostPrcType _ItemCompSetup = ItemCompSetup;
			CostPrcType _ItemCompRun = ItemCompRun;
			CostPrcType _ItemCompFixed = ItemCompFixed;
			CostPrcType _ItemCompVar = ItemCompVar;
			CostPrcType _ItemCompOutside = ItemCompOutside;
			CostPrcType _ItemCompMatl = ItemCompMatl;
			CostPrcType _ItemCompTool = ItemCompTool;
			CostPrcType _ItemCompFixture = ItemCompFixture;
			CostPrcType _ItemCompOther = ItemCompOther;
			CostPrcType _ItemSubMatl = ItemSubMatl;
			InfobarType _Infobar = Infobar;
			IntType _FromTemp = FromTemp;
			ListYesNoType _FromJobmatlTemp = FromJobmatlTemp;
			DecimalPlacesType _CurrencyPlacesCp = CurrencyPlacesCp;
			ListYesNoType _CostItemAtWhse = CostItemAtWhse;
			WhseType _DefWhse = DefWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemSumSjobISp";
				
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RollupType", _RollupType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLotSize", _ItemLotSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemJob", _ItemJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemSuffix", _ItemSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemAsmSetup", _ItemAsmSetup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAsmRun", _ItemAsmRun, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAsmFixed", _ItemAsmFixed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAsmVar", _ItemAsmVar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAsmOutside", _ItemAsmOutside, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAsmMatl", _ItemAsmMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAsmTool", _ItemAsmTool, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAsmFixture", _ItemAsmFixture, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAsmOther", _ItemAsmOther, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompSetup", _ItemCompSetup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompRun", _ItemCompRun, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompFixed", _ItemCompFixed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompVar", _ItemCompVar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompOutside", _ItemCompOutside, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompMatl", _ItemCompMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompTool", _ItemCompTool, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompFixture", _ItemCompFixture, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCompOther", _ItemCompOther, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSubMatl", _ItemSubMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromTemp", _FromTemp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobmatlTemp", _FromJobmatlTemp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlacesCp", _CurrencyPlacesCp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostItemAtWhse", _CostItemAtWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefWhse", _DefWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemAsmSetup = _ItemAsmSetup;
				ItemAsmRun = _ItemAsmRun;
				ItemAsmFixed = _ItemAsmFixed;
				ItemAsmVar = _ItemAsmVar;
				ItemAsmOutside = _ItemAsmOutside;
				ItemAsmMatl = _ItemAsmMatl;
				ItemAsmTool = _ItemAsmTool;
				ItemAsmFixture = _ItemAsmFixture;
				ItemAsmOther = _ItemAsmOther;
				ItemCompSetup = _ItemCompSetup;
				ItemCompRun = _ItemCompRun;
				ItemCompFixed = _ItemCompFixed;
				ItemCompVar = _ItemCompVar;
				ItemCompOutside = _ItemCompOutside;
				ItemCompMatl = _ItemCompMatl;
				ItemCompTool = _ItemCompTool;
				ItemCompFixture = _ItemCompFixture;
				ItemCompOther = _ItemCompOther;
				ItemSubMatl = _ItemSubMatl;
				Infobar = _Infobar;
				
				return (Severity, ItemAsmSetup, ItemAsmRun, ItemAsmFixed, ItemAsmVar, ItemAsmOutside, ItemAsmMatl, ItemAsmTool, ItemAsmFixture, ItemAsmOther, ItemCompSetup, ItemCompRun, ItemCompFixed, ItemCompVar, ItemCompOutside, ItemCompMatl, ItemCompTool, ItemCompFixture, ItemCompOther, ItemSubMatl, Infobar);
			}
		}
	}
}
