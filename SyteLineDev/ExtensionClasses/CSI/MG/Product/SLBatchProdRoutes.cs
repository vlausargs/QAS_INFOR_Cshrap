//PROJECT NAME: ProductExt
//CLASS NAME: SLBatchProdRoutes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLBatchProdRoutes")]
    public class SLBatchProdRoutes : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EDWcValuesCurrOperSp(string Item,
                                        string Job,
                                        short? Suffix,
                                        string JobType,
                                        string Wc,
                                        ref byte? EcnTrack,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEDWcValuesCurrOperExt = new EDWcValuesCurrOperFactory().Create(appDb);

                ListYesNoType oEcnTrack = EcnTrack;
                Infobar oInfobar = Infobar;

                int Severity = iEDWcValuesCurrOperExt.EDWcValuesCurrOperSp(Item,
                                                                           Job,
                                                                           Suffix,
                                                                           JobType,
                                                                           Wc,
                                                                           ref oEcnTrack,
                                                                           ref oInfobar);

                EcnTrack = oEcnTrack;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int LDvjrtstdForCurrOperSp(string Job,
                                          short? Suffix,
                                          string JobType,
                                          int? OperNum,
                                          string Wc,
                                          ref string QtyPerFormat,
                                          ref byte? EcnTrack,
                                          ref byte? SchedDriverEnable,
                                          ref byte? FixedScheduleCheck,
                                          ref byte? SchedHrsEnable,
                                          ref byte? UseOffsetCheck,
                                          ref byte? OffsetHoursEnable,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iLDvjrtstdForCurrOperExt = new LDvjrtstdForCurrOperFactory().Create(appDb);

                InputMaskType oQtyPerFormat = QtyPerFormat;
                ListYesNoType oEcnTrack = EcnTrack;
                ListYesNoType oSchedDriverEnable = SchedDriverEnable;
                ListYesNoType oFixedScheduleCheck = FixedScheduleCheck;
                ListYesNoType oSchedHrsEnable = SchedHrsEnable;
                ListYesNoType oUseOffsetCheck = UseOffsetCheck;
                ListYesNoType oOffsetHoursEnable = OffsetHoursEnable;
                Infobar oInfobar = Infobar;

                int Severity = iLDvjrtstdForCurrOperExt.LDvjrtstdForCurrOperSp(Job,
                                                                               Suffix,
                                                                               JobType,
                                                                               OperNum,
                                                                               Wc,
                                                                               ref oQtyPerFormat,
                                                                               ref oEcnTrack,
                                                                               ref oSchedDriverEnable,
                                                                               ref oFixedScheduleCheck,
                                                                               ref oSchedHrsEnable,
                                                                               ref oUseOffsetCheck,
                                                                               ref oOffsetHoursEnable,
                                                                               ref oInfobar);

                QtyPerFormat = oQtyPerFormat;
                EcnTrack = oEcnTrack;
                SchedDriverEnable = oSchedDriverEnable;
                FixedScheduleCheck = oFixedScheduleCheck;
                SchedHrsEnable = oSchedHrsEnable;
                UseOffsetCheck = oUseOffsetCheck;
                OffsetHoursEnable = oOffsetHoursEnable;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SetWcValuesForCurrOperSp(string Wc,
                                            ref byte? CntrlPoint,
                                            ref string BflushType,
                                            ref decimal? SetupRate,
                                            ref decimal? Efficiency,
                                            ref decimal? FovhdRateMch,
                                            ref decimal? VovhdRateMch,
                                            ref decimal? RunRateLbr,
                                            ref decimal? JshQueueHrs,
                                            ref decimal? JshMoveHrs,
                                            ref decimal? VarovhdRate,
                                            ref decimal? FixovhdRate,
                                            ref decimal? FinishHrs,
                                            ref string SchedDrv,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSetWcValuesForCurrOperExt = new SetWcValuesForCurrOperFactory().Create(appDb);

                ListYesNoType oCntrlPoint = CntrlPoint;
                BflushTypeType oBflushType = BflushType;
                RunRateType oSetupRate = SetupRate;
                EfficiencyType oEfficiency = Efficiency;
                OverheadRateType oFovhdRateMch = FovhdRateMch;
                OverheadRateType oVovhdRateMch = VovhdRateMch;
                RunRateType oRunRateLbr = RunRateLbr;
                SchedHoursType oJshQueueHrs = JshQueueHrs;
                SchedHoursType oJshMoveHrs = JshMoveHrs;
                OverheadRateType oVarovhdRate = VarovhdRate;
                OverheadRateType oFixovhdRate = FixovhdRate;
                SchedHoursType oFinishHrs = FinishHrs;
                SchedDriverType oSchedDrv = SchedDrv;
                Infobar oInfobar = Infobar;

                int Severity = iSetWcValuesForCurrOperExt.SetWcValuesForCurrOperSp(Wc,
                                                                                   ref oCntrlPoint,
                                                                                   ref oBflushType,
                                                                                   ref oSetupRate,
                                                                                   ref oEfficiency,
                                                                                   ref oFovhdRateMch,
                                                                                   ref oVovhdRateMch,
                                                                                   ref oRunRateLbr,
                                                                                   ref oJshQueueHrs,
                                                                                   ref oJshMoveHrs,
                                                                                   ref oVarovhdRate,
                                                                                   ref oFixovhdRate,
                                                                                   ref oFinishHrs,
                                                                                   ref oSchedDrv,
                                                                                   ref oInfobar);

                CntrlPoint = oCntrlPoint;
                BflushType = oBflushType;
                SetupRate = oSetupRate;
                Efficiency = oEfficiency;
                FovhdRateMch = oFovhdRateMch;
                VovhdRateMch = oVovhdRateMch;
                RunRateLbr = oRunRateLbr;
                JshQueueHrs = oJshQueueHrs;
                JshMoveHrs = oJshMoveHrs;
                VarovhdRate = oVarovhdRate;
                FixovhdRate = oFixovhdRate;
                FinishHrs = oFinishHrs;
                SchedDrv = oSchedDrv;
                Infobar = oInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetVariablesForCurrOperSp(string Item,
		ref string Job,
		ref int? Suffix,
		ref string JobType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetVariablesForCurrOperExt = new SetVariablesForCurrOperFactory().Create(appDb);
				
				var result = iSetVariablesForCurrOperExt.SetVariablesForCurrOperSp(Item,
				Job,
				Suffix,
				JobType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Job = result.Job;
				Suffix = result.Suffix;
				JobType = result.JobType;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetPPBatchedOperationTypeSp(int? BatchId,
			string BatchDefinition)
		{
			var iCLM_GetPPBatchedOperationTypeExt = this.GetService<ICLM_GetPPBatchedOperationType>();
			
			var result = iCLM_GetPPBatchedOperationTypeExt.CLM_GetPPBatchedOperationTypeSp(BatchId,
				BatchDefinition);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetOperNumForCurrOperSp(string Item,
		ref int? OperNum,
		ref string Infobar,
		[Optional] string AlternateID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetOperNumForCurrOperExt = new GetOperNumForCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetOperNumForCurrOperExt.GetOperNumForCurrOperSp(Item,
				OperNum,
				Infobar,
				AlternateID);
				
				int Severity = result.ReturnCode.Value;
				OperNum = result.OperNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PostDeleteCurrOperSp(string Job,
		int? Suffix,
		string JobType,
		string Item,
		int? OperNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPostDeleteCurrOperExt = new PostDeleteCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPostDeleteCurrOperExt.PostDeleteCurrOperSp(Job,
				Suffix,
				JobType,
				Item,
				OperNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PostSaveCurrOperSp(string Job,
		int? Suffix,
		int? OperNum,
		string RunBasisLbr,
		decimal? RunLbrHours,
		string RunBasisMch,
		decimal? RunMchHours,
		decimal? SchedHours,
		decimal? MoveHours,
		decimal? QueueHours,
		decimal? SetupHours,
		decimal? OffsetHours,
		DateTime? EffectDate,
		DateTime? ObsDate,
		string Item,
		DateTime? PrevEffectDate,
		DateTime? PrevObsDate,
		string JobType,
		decimal? JshFinishHrs,
		int? JshWhenRule,
		string JshMatrixType,
		string JshTabid,
		int? JshPlannerstep,
		string JshSetuprgid,
		int? JshSetuprule,
		string JshSchedStepRule,
		int? JshCrsBrkRule,
		int? JshReallocate,
		decimal? JshSplitSize,
		string JshSchedDrv,
		ref string Infobar,
		[Optional] string UpdateResourceGroupFrom,
		string BatchDef,
		[Optional] int? JshSplitRule,
		[Optional] string JshSplitGroup,
		[Optional] Guid? OldJobrouteRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPostSaveCurrOperExt = new PostSaveCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPostSaveCurrOperExt.PostSaveCurrOperSp(Job,
				Suffix,
				OperNum,
				RunBasisLbr,
				RunLbrHours,
				RunBasisMch,
				RunMchHours,
				SchedHours,
				MoveHours,
				QueueHours,
				SetupHours,
				OffsetHours,
				EffectDate,
				ObsDate,
				Item,
				PrevEffectDate,
				PrevObsDate,
				JobType,
				JshFinishHrs,
				JshWhenRule,
				JshMatrixType,
				JshTabid,
				JshPlannerstep,
				JshSetuprgid,
				JshSetuprule,
				JshSchedStepRule,
				JshCrsBrkRule,
				JshReallocate,
				JshSplitSize,
				JshSchedDrv,
				Infobar,
				UpdateResourceGroupFrom,
				BatchDef,
				JshSplitRule,
				JshSplitGroup,
				OldJobrouteRowPointer);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_SavePrintingJobRouteDataSp(string Job,
		int? Suffix,
		int? OperNum,
		string JobType,
		string OperationType,
		string OperationTypeCode,
		[Optional, DefaultParameterValue(0)] decimal? CartonLength,
		[Optional, DefaultParameterValue(0)] decimal? CartonWidth,
		[Optional, DefaultParameterValue(0)] decimal? length,
		[Optional, DefaultParameterValue(0)] int? NumOfHoles,
		[Optional, DefaultParameterValue(0)] int? ColorsFront_C,
		[Optional, DefaultParameterValue(0)] int? ColorsFront_M,
		[Optional, DefaultParameterValue(0)] int? ColorsFront_Y,
		[Optional, DefaultParameterValue(0)] int? ColorsFront_K,
		[Optional, DefaultParameterValue(0)] int? ColorsBack_C,
		[Optional, DefaultParameterValue(0)] int? ColorsBack_M,
		[Optional, DefaultParameterValue(0)] int? ColorsBack_Y,
		[Optional, DefaultParameterValue(0)] int? ColorsBack_K,
		[Optional, DefaultParameterValue(0)] int? Out,
		[Optional, DefaultParameterValue(0)] int? NumOfWords,
		[Optional, DefaultParameterValue(0)] decimal? SheetCount,
		[Optional, DefaultParameterValue(0)] int? Up,
		[Optional, DefaultParameterValue(0)] int? NumOfSpclColors,
		[Optional, DefaultParameterValue(0)] decimal? Width,
		[Optional, DefaultParameterValue(0)] decimal? OperDifficultFactor,
		[Optional, DefaultParameterValue(0)] int? NumOfManualHandleSteps,
		[Optional, DefaultParameterValue(0)] int? NumOfSidesToPrint,
		[Optional, DefaultParameterValue(0)] int? NumberOfAddlColors,
		[Optional, DefaultParameterValue(0)] decimal? JobQtyPerSheet,
		[Optional, DefaultParameterValue(0)] decimal? PaperConsumptionQty,
		[Optional, DefaultParameterValue(0)] decimal? OperRating1,
		[Optional, DefaultParameterValue(0)] decimal? OperRating2,
		[Optional, DefaultParameterValue(0)] decimal? OperRating3,
		[Optional, DefaultParameterValue(0)] decimal? OperRating4,
		[Optional, DefaultParameterValue(0)] decimal? OperRating5,
		[Optional, DefaultParameterValue(0)] decimal? OperRating6,
		[Optional, DefaultParameterValue(0)] decimal? OperRating7,
		[Optional, DefaultParameterValue(0)] decimal? OperRating8,
		[Optional, DefaultParameterValue(0)] decimal? OperRating9,
		[Optional, DefaultParameterValue(0)] decimal? OperRating10,
		[Optional, DefaultParameterValue(0)] decimal? OperRating11,
		[Optional, DefaultParameterValue(0)] decimal? OperRating12,
		[Optional, DefaultParameterValue(0)] decimal? OperRating13,
		[Optional, DefaultParameterValue(0)] decimal? OperRating14,
		[Optional, DefaultParameterValue(0)] decimal? OperRating15,
		[Optional, DefaultParameterValue(0)] decimal? OperRating16,
		[Optional, DefaultParameterValue(0)] decimal? OperRating17,
		[Optional, DefaultParameterValue(0)] decimal? OperRating18,
		[Optional, DefaultParameterValue(0)] decimal? OperRating19,
		[Optional, DefaultParameterValue(0)] decimal? OperRating20,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected1,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected2,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected3,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected4,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected5,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected6,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected7,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected8,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected9,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected10,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected11,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected12,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected13,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected14,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected15,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected16,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected17,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected18,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected19,
		[Optional, DefaultParameterValue(0)] int? SetupRunFinishSelected20,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPP_SavePrintingJobRouteDataExt = new PP_SavePrintingJobRouteDataFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPP_SavePrintingJobRouteDataExt.PP_SavePrintingJobRouteDataSp(Job,
				Suffix,
				OperNum,
				JobType,
				OperationType,
				OperationTypeCode,
				CartonLength,
				CartonWidth,
				length,
				NumOfHoles,
				ColorsFront_C,
				ColorsFront_M,
				ColorsFront_Y,
				ColorsFront_K,
				ColorsBack_C,
				ColorsBack_M,
				ColorsBack_Y,
				ColorsBack_K,
				Out,
				NumOfWords,
				SheetCount,
				Up,
				NumOfSpclColors,
				Width,
				OperDifficultFactor,
				NumOfManualHandleSteps,
				NumOfSidesToPrint,
				NumberOfAddlColors,
				JobQtyPerSheet,
				PaperConsumptionQty,
				OperRating1,
				OperRating2,
				OperRating3,
				OperRating4,
				OperRating5,
				OperRating6,
				OperRating7,
				OperRating8,
				OperRating9,
				OperRating10,
				OperRating11,
				OperRating12,
				OperRating13,
				OperRating14,
				OperRating15,
				OperRating16,
				OperRating17,
				OperRating18,
				OperRating19,
				OperRating20,
				SetupRunFinishSelected1,
				SetupRunFinishSelected2,
				SetupRunFinishSelected3,
				SetupRunFinishSelected4,
				SetupRunFinishSelected5,
				SetupRunFinishSelected6,
				SetupRunFinishSelected7,
				SetupRunFinishSelected8,
				SetupRunFinishSelected9,
				SetupRunFinishSelected10,
				SetupRunFinishSelected11,
				SetupRunFinishSelected12,
				SetupRunFinishSelected13,
				SetupRunFinishSelected14,
				SetupRunFinishSelected15,
				SetupRunFinishSelected16,
				SetupRunFinishSelected17,
				SetupRunFinishSelected18,
				SetupRunFinishSelected19,
				SetupRunFinishSelected20,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PpJobExistSp(string PJob, ref int? PpJobExist, ref string Infobar)
        {
            var iPpJobExistExt = new PpJobExistFactory().Create(this, true);

            var result = iPpJobExistExt.PpJobExistSp(PJob,
				PpJobExist,
				Infobar);

            PpJobExist = result.PpJobExist;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PreDeleteCurrOperSp(string Job,
		int? Suffix,
		string JobType,
		int? OperNum,
		string Item,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPreDeleteCurrOperExt = new PreDeleteCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPreDeleteCurrOperExt.PreDeleteCurrOperSp(Job,
				Suffix,
				JobType,
				OperNum,
				Item,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
