//PROJECT NAME: Production
//CLASS NAME: IMO_ResourceSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IMO_ResourceSave
	{
		int? MO_ResourceSaveSp(int? InsertFlag,
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
        int? AltNo);
	}
}

