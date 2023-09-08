//PROJECT NAME: Production
//CLASS NAME: MO_ResourceSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class MO_ResourceSave : IMO_ResourceSave
	{
		readonly IApplicationDB appDB;
		
		
		public MO_ResourceSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MO_ResourceSaveSp(int? InsertFlag,
		string RESID,
		string JobConfigType,
		string DefaultWc,
		decimal? SetupHrsT,
		decimal? SecondsPerCycle,
		string LaborType,
		decimal? ScrapFact,
		int? FixtureRequired,
		int? FixtureMounted,
		string ParentResourceResid,
		decimal? ResourceWeight,
		string ResourceWeightUM,
		decimal? ResourceLength,
		string ResourceLengthUM,
		decimal? ResourceWidth,
		string ResourceWidthUM,
		decimal? ResourceHeight,
		string ResourceHeightUM,
		decimal? MachineClampForce,
		string MachineClampForceUM,
		decimal? MachineInjectionPresure,
		string MachineInjectionPresureUM,
		decimal? MachineInjectionRate,
		string MachineInjectionRateUM,
		string MachineFixtureResid,
		decimal? MachinePlasticizingRate,
		string MachinePlasticizingRateUM,
		decimal? MachineNozzleRadius,
		string MachineNozzleRadiusUM,
		decimal? MachineExtractionStroke,
		string MachineExtractionStrokeUM,
		decimal? MachineCycleTimeMin,
		string MachineCycleTimeMinUM,
		decimal? MachineCycleTimeMax,
		string MachineCycleTimeMaxUM,
		decimal? MachineCapacityWeightMin,
		string MachineCapacityWeightMinUM,
		decimal? MachineCapacityWeightMax,
		string MachineCapacityWeightMaxUM,
		decimal? MachineCapacityHeightMin,
		string MachineCapacityHeightMinUM,
		decimal? MachineCapacityHeightMax,
		string MachineCapacityHeightMaxUM,
		decimal? MachineCapacityWidthMin,
		string MachineCapacityWidthMinUM,
		decimal? MachineCapacityWidthMax,
		string MachineCapacityWidthMaxUM,
		decimal? MachineCapacityLengthMin,
		string MachineCapacityLengthMinUM,
		decimal? MachineCapacityLengthMax,
		string MachineCapacityLengthMaxUM,
		string MaintenanceIdPrefix,
		string ServiceScheduleFrequency,
		string ServiceScheduleFrequencyType,
		decimal? ServiceCycleLast,
		DateTime? ServiceDateLast,
		decimal? ServiceCycleNext,
		DateTime? ServiceDateNext,
		decimal? ServiceCycleAccumulative,
		decimal? ServiceCyclesPlannedMonthly,
		decimal? ServiceCycleLife,
		string CoJob,
		string ProdMix,
		decimal? ServiceDuration,
		string ServiceDurationUnit,
        int? AltNo)
		{            
            ListYesNoType _InsertFlag = InsertFlag;
			ApsResourceType _RESID = RESID;
			MO_JobConfigTypeType _JobConfigType = JobConfigType;
			WcType _DefaultWc = DefaultWc;
			TotalHoursType _SetupHrsT = SetupHrsT;
			MO_CycleTimeType _SecondsPerCycle = SecondsPerCycle;
			MO_LaborType _LaborType = LaborType;
			ScrapFactorType _ScrapFact = ScrapFact;
			ListYesNoType _FixtureRequired = FixtureRequired;
			ListYesNoType _FixtureMounted = FixtureMounted;
			ApsResourceType _ParentResourceResid = ParentResourceResid;
			ItemWeightType _ResourceWeight = ResourceWeight;
			UMType _ResourceWeightUM = ResourceWeightUM;
			QtyTotlType _ResourceLength = ResourceLength;
			UMType _ResourceLengthUM = ResourceLengthUM;
			QtyTotlType _ResourceWidth = ResourceWidth;
			UMType _ResourceWidthUM = ResourceWidthUM;
			QtyTotlType _ResourceHeight = ResourceHeight;
			UMType _ResourceHeightUM = ResourceHeightUM;
			QtyTotlType _MachineClampForce = MachineClampForce;
			UMType _MachineClampForceUM = MachineClampForceUM;
			QtyTotlType _MachineInjectionPresure = MachineInjectionPresure;
			UMType _MachineInjectionPresureUM = MachineInjectionPresureUM;
			QtyTotlType _MachineInjectionRate = MachineInjectionRate;
			UMType _MachineInjectionRateUM = MachineInjectionRateUM;
			ApsResourceType _MachineFixtureResid = MachineFixtureResid;
			QtyTotlType _MachinePlasticizingRate = MachinePlasticizingRate;
			UMType _MachinePlasticizingRateUM = MachinePlasticizingRateUM;
			QtyTotlType _MachineNozzleRadius = MachineNozzleRadius;
			UMType _MachineNozzleRadiusUM = MachineNozzleRadiusUM;
			QtyTotlType _MachineExtractionStroke = MachineExtractionStroke;
			UMType _MachineExtractionStrokeUM = MachineExtractionStrokeUM;
			QtyTotlType _MachineCycleTimeMin = MachineCycleTimeMin;
			UMType _MachineCycleTimeMinUM = MachineCycleTimeMinUM;
			QtyTotlType _MachineCycleTimeMax = MachineCycleTimeMax;
			UMType _MachineCycleTimeMaxUM = MachineCycleTimeMaxUM;
			QtyTotlType _MachineCapacityWeightMin = MachineCapacityWeightMin;
			UMType _MachineCapacityWeightMinUM = MachineCapacityWeightMinUM;
			QtyTotlType _MachineCapacityWeightMax = MachineCapacityWeightMax;
			UMType _MachineCapacityWeightMaxUM = MachineCapacityWeightMaxUM;
			QtyTotlType _MachineCapacityHeightMin = MachineCapacityHeightMin;
			UMType _MachineCapacityHeightMinUM = MachineCapacityHeightMinUM;
			QtyTotlType _MachineCapacityHeightMax = MachineCapacityHeightMax;
			UMType _MachineCapacityHeightMaxUM = MachineCapacityHeightMaxUM;
			QtyTotlType _MachineCapacityWidthMin = MachineCapacityWidthMin;
			UMType _MachineCapacityWidthMinUM = MachineCapacityWidthMinUM;
			QtyTotlType _MachineCapacityWidthMax = MachineCapacityWidthMax;
			UMType _MachineCapacityWidthMaxUM = MachineCapacityWidthMaxUM;
			QtyTotlType _MachineCapacityLengthMin = MachineCapacityLengthMin;
			UMType _MachineCapacityLengthMinUM = MachineCapacityLengthMinUM;
			QtyTotlType _MachineCapacityLengthMax = MachineCapacityLengthMax;
			UMType _MachineCapacityLengthMaxUM = MachineCapacityLengthMaxUM;
			MO_MaintenanceIDPrefixType _MaintenanceIdPrefix = MaintenanceIdPrefix;
			MO_ScheduleFrequencyType _ServiceScheduleFrequency = ServiceScheduleFrequency;
			MO_ScheduleFrequencyTypeType _ServiceScheduleFrequencyType = ServiceScheduleFrequencyType;
			MO_CycleType _ServiceCycleLast = ServiceCycleLast;
			DateTimeType _ServiceDateLast = ServiceDateLast;
			MO_CycleType _ServiceCycleNext = ServiceCycleNext;
			DateTimeType _ServiceDateNext = ServiceDateNext;
			MO_CycleType _ServiceCycleAccumulative = ServiceCycleAccumulative;
			MO_CycleType _ServiceCyclesPlannedMonthly = ServiceCyclesPlannedMonthly;
			MO_CycleType _ServiceCycleLife = ServiceCycleLife;
			JobType _CoJob = CoJob;
			ProdMixType _ProdMix = ProdMix;
			ServiceDurationType _ServiceDuration = ServiceDuration;
			ServiceDurationUnitType _ServiceDurationUnit = ServiceDurationUnit;
            ApsAltNoType _AltNo = AltNo;


            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_ResourceSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobConfigType", _JobConfigType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefaultWc", _DefaultWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupHrsT", _SetupHrsT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SecondsPerCycle", _SecondsPerCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LaborType", _LaborType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrapFact", _ScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixtureRequired", _FixtureRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixtureMounted", _FixtureMounted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentResourceResid", _ParentResourceResid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceWeight", _ResourceWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceWeightUM", _ResourceWeightUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceLength", _ResourceLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceLengthUM", _ResourceLengthUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceWidth", _ResourceWidth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceWidthUM", _ResourceWidthUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceHeight", _ResourceHeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceHeightUM", _ResourceHeightUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineClampForce", _MachineClampForce, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineClampForceUM", _MachineClampForceUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineInjectionPresure", _MachineInjectionPresure, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineInjectionPresureUM", _MachineInjectionPresureUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineInjectionRate", _MachineInjectionRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineInjectionRateUM", _MachineInjectionRateUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineFixtureResid", _MachineFixtureResid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachinePlasticizingRate", _MachinePlasticizingRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachinePlasticizingRateUM", _MachinePlasticizingRateUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineNozzleRadius", _MachineNozzleRadius, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineNozzleRadiusUM", _MachineNozzleRadiusUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineExtractionStroke", _MachineExtractionStroke, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineExtractionStrokeUM", _MachineExtractionStrokeUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCycleTimeMin", _MachineCycleTimeMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCycleTimeMinUM", _MachineCycleTimeMinUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCycleTimeMax", _MachineCycleTimeMax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCycleTimeMaxUM", _MachineCycleTimeMaxUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityWeightMin", _MachineCapacityWeightMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityWeightMinUM", _MachineCapacityWeightMinUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityWeightMax", _MachineCapacityWeightMax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityWeightMaxUM", _MachineCapacityWeightMaxUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityHeightMin", _MachineCapacityHeightMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityHeightMinUM", _MachineCapacityHeightMinUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityHeightMax", _MachineCapacityHeightMax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityHeightMaxUM", _MachineCapacityHeightMaxUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityWidthMin", _MachineCapacityWidthMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityWidthMinUM", _MachineCapacityWidthMinUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityWidthMax", _MachineCapacityWidthMax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityWidthMaxUM", _MachineCapacityWidthMaxUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityLengthMin", _MachineCapacityLengthMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityLengthMinUM", _MachineCapacityLengthMinUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityLengthMax", _MachineCapacityLengthMax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MachineCapacityLengthMaxUM", _MachineCapacityLengthMaxUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaintenanceIdPrefix", _MaintenanceIdPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceScheduleFrequency", _ServiceScheduleFrequency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceScheduleFrequencyType", _ServiceScheduleFrequencyType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceCycleLast", _ServiceCycleLast, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceDateLast", _ServiceDateLast, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceCycleNext", _ServiceCycleNext, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceDateNext", _ServiceDateNext, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceCycleAccumulative", _ServiceCycleAccumulative, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceCyclesPlannedMonthly", _ServiceCyclesPlannedMonthly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceCycleLife", _ServiceCycleLife, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoJob", _CoJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdMix", _ProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceDuration", _ServiceDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceDurationUnit", _ServiceDurationUnit, ParameterDirection.Input);                
                appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
             
                return (Severity);
			}
		}
	}
}
