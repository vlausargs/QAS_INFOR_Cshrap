//PROJECT NAME: APSExt
//CLASS NAME: SLRESRCnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.MOIndPack;
using CSI.Data.RecordSets;
using CSI.Production;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLRESRCnnns")]
    public class SLRESRCnnns : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetResourceServiceInfoSp(string RESID,
		                                    ref string SrvSchFrequency,
		                                    ref string SrvSchFrequencyType,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetResourceServiceInfoExt = new GetResourceServiceInfoFactory().Create(appDb);
				
				int Severity = iGetResourceServiceInfoExt.GetResourceServiceInfoSp(RESID,
				                                                                   ref SrvSchFrequency,
				                                                                   ref SrvSchFrequencyType,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetRESRCSp(short? AltNo,
		                                   [Optional] string RESID,
		                                   [Optional] string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetRESRCExt = new CLM_ApsGetRESRCFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetRESRCExt.CLM_ApsGetRESRCSp(AltNo,
				                                                   RESID,
				                                                   Filter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ResrcDelSp(string Resid,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iResrcDelExt = new ResrcDelFactory().Create(appDb);
				
				var result = iResrcDelExt.ResrcDelSp(Resid,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateResourceSp(ref string RESID,
		int? AltNo,
		ref string DESCR,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateResourceExt = new ValidateResourceFactory().Create(appDb);
				
				var result = iValidateResourceExt.ValidateResourceSp(RESID,
				AltNo,
				DESCR,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RESID = result.RESID;
				DESCR = result.DESCR;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsRESRCDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsRESRCDelExt = new ApsRESRCDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsRESRCDelExt.ApsRESRCDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsRESRCSaveSp(int? InsertFlag,
		int? AltNo,
		string RESID,
		string DESCR,
		string RESTYPE,
		string fa_num,
		int? SEQRL,
		int? SELRL,
		int? TIEREDRL1,
		int? TIEREDRL2,
		int? TIEREDRL3,
		decimal? SELVALUE,
		decimal? SETUPDEL,
		string PARTSETUP,
		string ALLOCCD,
		string INFINITEFG,
		string SUPER,
		string SUMFG,
		string SCHEDFG,
		string FINALQFG,
		string LOADFG,
		string SHIFTID1,
		string SHIFTID2,
		string SHIFTID3,
		string SHIFTID4,
		decimal? MAXORUN,
		string MUSTCOMPFG,
		                          int? RESIDQTY,
                                  string plant,
                                  string RESID_alias)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsRESRCSaveExt = new ApsRESRCSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsRESRCSaveExt.ApsRESRCSaveSp(InsertFlag,
				AltNo,
				RESID,
				DESCR,
				RESTYPE,
				fa_num,
				SEQRL,
				SELRL,
				TIEREDRL1,
				TIEREDRL2,
				TIEREDRL3,
				SELVALUE,
				SETUPDEL,
				PARTSETUP,
				ALLOCCD,
				INFINITEFG,
				SUPER,
				SUMFG,
				SCHEDFG,
				FINALQFG,
				LOADFG,
				SHIFTID1,
				SHIFTID2,
				SHIFTID3,
				SHIFTID4,
				MAXORUN,
				MUSTCOMPFG,
				                                               RESIDQTY,
                                                               plant,
                                                               RESID_alias);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_ResourceDelSp(string RESID, int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMO_ResourceDelExt = new MO_ResourceDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMO_ResourceDelExt.MO_ResourceDelSp(RESID, AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_ResourceJobDeleteSp(int? DeleteFlag,
		string RESID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMO_ResourceJobDeleteExt = new MO_ResourceJobDeleteFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMO_ResourceJobDeleteExt.MO_ResourceJobDeleteSp(DeleteFlag,
				RESID);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_ResourceSaveSp(int? InsertFlag,
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
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMO_ResourceSaveExt = new MO_ResourceSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
                
				var result = iMO_ResourceSaveExt.MO_ResourceSaveSp(InsertFlag,
				RESID,
				JobConfigType,
				DefaultWc,
				SetupHrsT,
				SecondsPerCycle,
				LaborType,
				ScrapFact,
				FixtureRequired,
				FixtureMounted,
				ParentResourceResid,
				ResourceWeight,
				ResourceWeightUM,
				ResourceLength,
				ResourceLengthUM,
				ResourceWidth,
				ResourceWidthUM,
				ResourceHeight,
				ResourceHeightUM,
				MachineClampForce,
				MachineClampForceUM,
				MachineInjectionPresure,
				MachineInjectionPresureUM,
				MachineInjectionRate,
				MachineInjectionRateUM,
				MachineFixtureResid,
				MachinePlasticizingRate,
				MachinePlasticizingRateUM,
				MachineNozzleRadius,
				MachineNozzleRadiusUM,
				MachineExtractionStroke,
				MachineExtractionStrokeUM,
				MachineCycleTimeMin,
				MachineCycleTimeMinUM,
				MachineCycleTimeMax,
				MachineCycleTimeMaxUM,
				MachineCapacityWeightMin,
				MachineCapacityWeightMinUM,
				MachineCapacityWeightMax,
				MachineCapacityWeightMaxUM,
				MachineCapacityHeightMin,
				MachineCapacityHeightMinUM,
				MachineCapacityHeightMax,
				MachineCapacityHeightMaxUM,
				MachineCapacityWidthMin,
				MachineCapacityWidthMinUM,
				MachineCapacityWidthMax,
				MachineCapacityWidthMaxUM,
				MachineCapacityLengthMin,
				MachineCapacityLengthMinUM,
				MachineCapacityLengthMax,
				MachineCapacityLengthMaxUM,
				MaintenanceIdPrefix,
				ServiceScheduleFrequency,
				ServiceScheduleFrequencyType,
				ServiceCycleLast,
				ServiceDateLast,
				ServiceCycleNext,
				ServiceDateNext,
				ServiceCycleAccumulative,
				ServiceCyclesPlannedMonthly,
				ServiceCycleLife,
				CoJob,
				ProdMix,
				ServiceDuration,
				ServiceDurationUnit,
                AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_JobRouteOEESp(decimal? OEE)
		{
			var iCLM_JobRouteOEEExt = new CLM_JobRouteOEEFactory().Create(this, true);
			
			var result = iCLM_JobRouteOEEExt.CLM_JobRouteOEESp(OEE);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

    }
}
