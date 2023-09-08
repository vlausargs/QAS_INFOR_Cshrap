//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsItemChg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CurrentMaterialsItemChg : ICurrentMaterialsItemChg
	{
		readonly IApplicationDB appDB;
		
		
		public CurrentMaterialsItemChg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? BomSeq,
		int? DerMatlExist,
		decimal? DerUOMConvFactor,
		int? MatlSerialTracked,
		int? MatlLotTracked,
		string Description,
		string MatlType,
		string Units,
		string MatlStat,
		string UM,
		string DerUM,
		string MatlUM,
		int? MatlLowLevel,
		int? Backflush,
		string BflushLoc,
		string RefType,
		int? PhantomFlag,
		int? DerBflushLocRequired,
		decimal? Cost,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? CostConv,
		decimal? MatlCostConv,
		decimal? LbrCostConv,
		decimal? FovhdCostConv,
		decimal? VovhdCostConv,
		decimal? OutCostConv,
		decimal? Fmatlovhd,
		decimal? Vmatlovhd,
		int? Kit,
		int? PreassignLots,
		string LotPrefix,
		string Infobar,
		int? MOShared,
		decimal? MOSecondsPerCycle,
		decimal? MOFormulaMatlWeight,
		string MOFormulaMatlWeightUnits,
		string Revision) CurrentMaterialsItemChgSp(string Item,
		string WC,
		int? LocalNegFlag,
		string Job,
		int? Suffix,
		Guid? JobmatlRowPointer,
		int? BomSeq,
		int? DerMatlExist,
		decimal? DerUOMConvFactor,
		int? MatlSerialTracked,
		int? MatlLotTracked,
		string Description,
		string MatlType,
		string Units,
		string MatlStat,
		string UM,
		string DerUM,
		string MatlUM,
		int? MatlLowLevel,
		int? Backflush,
		string BflushLoc,
		string RefType,
		int? PhantomFlag,
		int? DerBflushLocRequired,
		decimal? Cost,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? CostConv,
		decimal? MatlCostConv,
		decimal? LbrCostConv,
		decimal? FovhdCostConv,
		decimal? VovhdCostConv,
		decimal? OutCostConv,
		decimal? Fmatlovhd,
		decimal? Vmatlovhd,
		int? Kit,
		int? PreassignLots,
		string LotPrefix,
		string Infobar,
		int? OperNum = null,
		int? MOShared = null,
		decimal? MOSecondsPerCycle = null,
		decimal? MOFormulaMatlWeight = null,
		string MOFormulaMatlWeightUnits = null,
		string Revision = null)
		{
			ItemType _Item = Item;
			WcType _WC = WC;
			ListYesNoType _LocalNegFlag = LocalNegFlag;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
			EcnBomSeqType _BomSeq = BomSeq;
			ByteType _DerMatlExist = DerMatlExist;
			UMConvFactorType _DerUOMConvFactor = DerUOMConvFactor;
			ListYesNoType _MatlSerialTracked = MatlSerialTracked;
			ListYesNoType _MatlLotTracked = MatlLotTracked;
			DescriptionType _Description = Description;
			MatlTypeType _MatlType = MatlType;
			JobmatlUnitsType _Units = Units;
			ItemStatusType _MatlStat = MatlStat;
			UMType _UM = UM;
			UMType _DerUM = DerUM;
			UMType _MatlUM = MatlUM;
			LowLevelType _MatlLowLevel = MatlLowLevel;
			ListYesNoType _Backflush = Backflush;
			LocType _BflushLoc = BflushLoc;
			RefTypeIJPRTType _RefType = RefType;
			ListYesNoType _PhantomFlag = PhantomFlag;
			ListYesNoType _DerBflushLocRequired = DerBflushLocRequired;
			CostPrcType _Cost = Cost;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			CostPrcType _CostConv = CostConv;
			CostPrcType _MatlCostConv = MatlCostConv;
			CostPrcType _LbrCostConv = LbrCostConv;
			CostPrcType _FovhdCostConv = FovhdCostConv;
			CostPrcType _VovhdCostConv = VovhdCostConv;
			CostPrcType _OutCostConv = OutCostConv;
			OverheadRateType _Fmatlovhd = Fmatlovhd;
			OverheadRateType _Vmatlovhd = Vmatlovhd;
			ListYesNoType _Kit = Kit;
			ListYesNoType _PreassignLots = PreassignLots;
			LotPrefixType _LotPrefix = LotPrefix;
			Infobar _Infobar = Infobar;
			OperNumType _OperNum = OperNum;
			ListYesNoType _MOShared = MOShared;
			MO_CycleTimeType _MOSecondsPerCycle = MOSecondsPerCycle;
			WeightType _MOFormulaMatlWeight = MOFormulaMatlWeight;
			WeightUnitsType _MOFormulaMatlWeightUnits = MOFormulaMatlWeightUnits;
			RevisionType _Revision = Revision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CurrentMaterialsItemChgSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WC", _WC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocalNegFlag", _LocalNegFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRowPointer", _JobmatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BomSeq", _BomSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerMatlExist", _DerMatlExist, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerUOMConvFactor", _DerUOMConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlSerialTracked", _MatlSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlLotTracked", _MatlLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlStat", _MatlStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerUM", _DerUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlUM", _MatlUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlLowLevel", _MatlLowLevel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Backflush", _Backflush, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BflushLoc", _BflushLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PhantomFlag", _PhantomFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerBflushLocRequired", _DerBflushLocRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCostConv", _MatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCostConv", _LbrCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCostConv", _FovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCostConv", _VovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCostConv", _OutCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Fmatlovhd", _Fmatlovhd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Vmatlovhd", _Vmatlovhd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Kit", _Kit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MOShared", _MOShared, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MOSecondsPerCycle", _MOSecondsPerCycle, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MOFormulaMatlWeight", _MOFormulaMatlWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MOFormulaMatlWeightUnits", _MOFormulaMatlWeightUnits, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BomSeq = _BomSeq;
				DerMatlExist = _DerMatlExist;
				DerUOMConvFactor = _DerUOMConvFactor;
				MatlSerialTracked = _MatlSerialTracked;
				MatlLotTracked = _MatlLotTracked;
				Description = _Description;
				MatlType = _MatlType;
				Units = _Units;
				MatlStat = _MatlStat;
				UM = _UM;
				DerUM = _DerUM;
				MatlUM = _MatlUM;
				MatlLowLevel = _MatlLowLevel;
				Backflush = _Backflush;
				BflushLoc = _BflushLoc;
				RefType = _RefType;
				PhantomFlag = _PhantomFlag;
				DerBflushLocRequired = _DerBflushLocRequired;
				Cost = _Cost;
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovhdCost = _FovhdCost;
				VovhdCost = _VovhdCost;
				OutCost = _OutCost;
				CostConv = _CostConv;
				MatlCostConv = _MatlCostConv;
				LbrCostConv = _LbrCostConv;
				FovhdCostConv = _FovhdCostConv;
				VovhdCostConv = _VovhdCostConv;
				OutCostConv = _OutCostConv;
				Fmatlovhd = _Fmatlovhd;
				Vmatlovhd = _Vmatlovhd;
				Kit = _Kit;
				PreassignLots = _PreassignLots;
				LotPrefix = _LotPrefix;
				Infobar = _Infobar;
				MOShared = _MOShared;
				MOSecondsPerCycle = _MOSecondsPerCycle;
				MOFormulaMatlWeight = _MOFormulaMatlWeight;
				MOFormulaMatlWeightUnits = _MOFormulaMatlWeightUnits;
				Revision = _Revision;
				
				return (Severity, BomSeq, DerMatlExist, DerUOMConvFactor, MatlSerialTracked, MatlLotTracked, Description, MatlType, Units, MatlStat, UM, DerUM, MatlUM, MatlLowLevel, Backflush, BflushLoc, RefType, PhantomFlag, DerBflushLocRequired, Cost, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, CostConv, MatlCostConv, LbrCostConv, FovhdCostConv, VovhdCostConv, OutCostConv, Fmatlovhd, Vmatlovhd, Kit, PreassignLots, LotPrefix, Infobar, MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, Revision);
			}
		}
	}
}
