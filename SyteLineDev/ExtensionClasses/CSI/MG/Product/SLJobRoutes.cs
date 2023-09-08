//PROJECT NAME: ProductExt
//CLASS NAME: SLJobRoutes.cs

using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using CSI.Data.SQL.UDDT;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLJobRoutes")]
    public class SLJobRoutes : CSIExtensionClassBase, IExtFTSLJobRoutes
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CalcJobrouteRunDurSp(string pItemJob,
                                        short? pItemSuffix,
                                        int? pJobrouteOperNum,
                                        decimal? pJobrouteEfficiency,
                                        ref decimal? rJobrouteRunDur,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCalcJobrouteRunDurExt = new CalcJobrouteRunDurFactory().Create(appDb);

                QtyUnitType orJobrouteRunDur = rJobrouteRunDur;
                InfobarType oInfobar = Infobar;

                int Severity = iCalcJobrouteRunDurExt.CalcJobrouteRunDurSp(pItemJob,
                                                                           pItemSuffix,
                                                                           pJobrouteOperNum,
                                                                           pJobrouteEfficiency,
                                                                           ref orJobrouteRunDur,
                                                                           ref oInfobar);

                rJobrouteRunDur = orJobrouteRunDur;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CopyBomJobChangeSp(string FromCategory,
                                      ref string Job,
                                      ref short? Suffix,
                                      ref string PsNum,
                                      ref string Item,
                                      ref string ItemRev,
                                      ref int? StartOper,
                                      ref int? EndOper,
                                      ref byte? CopyBom,
                                      ref byte? CoProductMix,
                                      ref string Model,
                                      ref string ConfigId,
                                      ref string ConfigGid,
                                      ref string OrdNum,
                                      ref short? OrdLine,
                                      ref string OrdType,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCopyBomJobChangeExt = new CopyBomJobChangeFactory().Create(appDb);

                int Severity = iCopyBomJobChangeExt.CopyBomJobChangeSp(FromCategory,
                                                                       ref Job,
                                                                       ref Suffix,
                                                                       ref PsNum,
                                                                       ref Item,
                                                                       ref ItemRev,
                                                                       ref StartOper,
                                                                       ref EndOper,
                                                                       ref CopyBom,
                                                                       ref CoProductMix,
                                                                       ref Model,
                                                                       ref ConfigId,
                                                                       ref ConfigGid,
                                                                       ref OrdNum,
                                                                       ref OrdLine,
                                                                       ref OrdType,
                                                                       ref Infobar);

                return Severity;
            }
        }

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
        public int CompleteJobOperationSP(string FromJob,
                                          string ToJob,
                                          short? FromSuffix,
                                          short? ToSuffix,
                                          int? FromOperation,
                                          int? ToOperation,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCompleteJobOperationExt = new CompleteJobOperationFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCompleteJobOperationExt.CompleteJobOperationSP(FromJob,
                                                                               ToJob,
                                                                               FromSuffix,
                                                                               ToSuffix,
                                                                               FromOperation,
                                                                               ToOperation,
                                                                               ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CopyBomLeaveItemRevSp(string FromCategory,
		                                 string Item,
		                                 string ItemRev,
		                                 string ItemRevPrev,
		                                 ref string Job,
		                                 ref short? Suffix,
		                                 ref int? StartOper,
		                                 ref int? EndOper,
		                                 ref byte? ErrorFlag,
		                                 ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCopyBomLeaveItemRevExt = new CopyBomLeaveItemRevFactory().Create(appDb);
				
				int Severity = iCopyBomLeaveItemRevExt.CopyBomLeaveItemRevSp(FromCategory,
				                                                             Item,
				                                                             ItemRev,
				                                                             ItemRevPrev,
				                                                             ref Job,
				                                                             ref Suffix,
				                                                             ref StartOper,
				                                                             ref EndOper,
				                                                             ref ErrorFlag,
				                                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CopyBomLeaveJobSuffixSp(string FromCategory,
		                                   ref string Job,
		                                   ref short? Suffix,
		                                   ref string PsNum,
		                                   ref string Item,
		                                   ref string ItemRev,
		                                   ref int? StartOper,
		                                   ref int? EndOper,
		                                   ref string Infobar,
		                                   ref byte? Rework)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCopyBomLeaveJobSuffixExt = new CopyBomLeaveJobSuffixFactory().Create(appDb);
				
				int Severity = iCopyBomLeaveJobSuffixExt.CopyBomLeaveJobSuffixSp(FromCategory,
				                                                                 ref Job,
				                                                                 ref Suffix,
				                                                                 ref PsNum,
				                                                                 ref Item,
				                                                                 ref ItemRev,
				                                                                 ref StartOper,
				                                                                 ref EndOper,
				                                                                 ref Infobar,
				                                                                 ref Rework);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetJobParmsSp(ref byte? PAnyCanAdd,
		                         ref byte? PAnyCanDelete,
		                         ref byte? PAnyCanUpdate,
		                         ref string PSfcParmValue,
		                         string PSfcParmName,
		                         ref string PApsParmValue,
		                         string PApsParmName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetJobParmsExt = new GetJobParmsFactory().Create(appDb);
				
				int Severity = iGetJobParmsExt.GetJobParmsSp(ref PAnyCanAdd,
				                                             ref PAnyCanDelete,
				                                             ref PAnyCanUpdate,
				                                             ref PSfcParmValue,
				                                             PSfcParmName,
				                                             ref PApsParmValue,
				                                             PApsParmName);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetSharedForCoJobSp(string Job,
			int? OperNum,
			int? Suffix,
			ref int? Shared,
			ref string WC,
			ref int? IsCojob)
        {
            var iGetSharedForCoJobExt = new GetSharedForCoJobFactory().Create(this, true);

            var result = iGetSharedForCoJobExt.GetSharedForCoJobSp(Job,
				OperNum,
				Suffix,
				Shared,
				WC,
				IsCojob);

            Shared = result.Shared;
            WC = result.WC;
            IsCojob = result.IsCojob;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_GETParamtersSp(ref int? NumberOfManualHandling_steps,
		                             ref int? NumberOfSidesToPrint)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPP_GETParamtersExt = new PP_GETParamtersFactory().Create(appDb);
				
				int Severity = iPP_GETParamtersExt.PP_GETParamtersSp(ref NumberOfManualHandling_steps,
				                                                     ref NumberOfSidesToPrint);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EngWBJobrouteSp(Guid? JobrouteRowPointer,
		                           ref int? JobrouteOperNum,
		                           ref string JobrouteWc,
		                           ref DateTime? JrtSchStartDate,
		                           ref DateTime? JrtSchEndDate,
		                           ref byte? JobrouteCntrlPoint,
		                           ref string JobrouteBflushType,
		                           ref string JobrouteRunBasisLbr,
		                           ref string JobrouteRunBasisMch,
		                           ref byte? UseFixedSchedule,
		                           ref decimal? JrtSchSchedHrs,
		                           ref decimal? JrtSchPcsPerLbrHr,
		                           ref decimal? JrtSchPcsPerMchHr,
		                           ref decimal? JrtSchMoveHrs,
		                           ref decimal? JrtSchQueueHrs,
		                           ref decimal? JrtSchSetupHrs,
		                           ref byte? UseOffsetHrs,
		                           ref decimal? JrtSchOffsetHrs,
		                           ref string WcDescription,
		                           ref decimal? JrtSchFinishHrs,
		                           ref byte? JobrouteComplete,
		                           ref string JrtSchSchedDrv,
		                           ref decimal? JrtSchRunLbrHrs,
		                           ref decimal? JrtSchRunMchHrs,
		                           ref decimal? JobrouteSetupRate,
		                           ref decimal? JobrouteRunRateLbr,
		                           ref decimal? JobrouteVovhdRateMch,
		                           ref decimal? JobrouteFovhdRateMch,
		                           ref decimal? JobrouteVarovhdRate,
		                           ref decimal? JobrouteFixovhdRate,
		                           ref decimal? JobrouteEfficiency,
		                           ref short? JrtSchSchedsteprule,
		                           [Optional] ref decimal? JrtYield,
		                           ref short? JrtSchWhenRule,
		                           ref string JrtSchMatrixType,
		                           ref string JrtSchTabid,
		                           ref byte? JrtSchPlannerstep,
		                           ref string JrtSchSetuprgid,
		                           ref short? JrtSchSetuprule,
		                           ref short? JrtSchCrsBrkRule,
		                           ref byte? JrtSchAllowReallocation,
		                           ref double? JrtSchSplitSize)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iEngWBJobrouteExt = new EngWBJobrouteFactory().Create(appDb);
				
				var result = iEngWBJobrouteExt.EngWBJobrouteSp(JobrouteRowPointer,
				                                               JobrouteOperNum,
				                                               JobrouteWc,
				                                               JrtSchStartDate,
				                                               JrtSchEndDate,
				                                               JobrouteCntrlPoint,
				                                               JobrouteBflushType,
				                                               JobrouteRunBasisLbr,
				                                               JobrouteRunBasisMch,
				                                               UseFixedSchedule,
				                                               JrtSchSchedHrs,
				                                               JrtSchPcsPerLbrHr,
				                                               JrtSchPcsPerMchHr,
				                                               JrtSchMoveHrs,
				                                               JrtSchQueueHrs,
				                                               JrtSchSetupHrs,
				                                               UseOffsetHrs,
				                                               JrtSchOffsetHrs,
				                                               WcDescription,
				                                               JrtSchFinishHrs,
				                                               JobrouteComplete,
				                                               JrtSchSchedDrv,
				                                               JrtSchRunLbrHrs,
				                                               JrtSchRunMchHrs,
				                                               JobrouteSetupRate,
				                                               JobrouteRunRateLbr,
				                                               JobrouteVovhdRateMch,
				                                               JobrouteFovhdRateMch,
				                                               JobrouteVarovhdRate,
				                                               JobrouteFixovhdRate,
				                                               JobrouteEfficiency,
				                                               JrtSchSchedsteprule,
				                                               JrtYield,
				                                               JrtSchWhenRule,
				                                               JrtSchMatrixType,
				                                               JrtSchTabid,
				                                               JrtSchPlannerstep,
				                                               JrtSchSetuprgid,
				                                               JrtSchSetuprule,
				                                               JrtSchCrsBrkRule,
				                                               JrtSchAllowReallocation,
				                                               JrtSchSplitSize);
				
				int Severity = result.ReturnCode.Value;
				JobrouteOperNum = result.JobrouteOperNum;
				JobrouteWc = result.JobrouteWc;
				JrtSchStartDate = result.JrtSchStartDate;
				JrtSchEndDate = result.JrtSchEndDate;
				JobrouteCntrlPoint = result.JobrouteCntrlPoint;
				JobrouteBflushType = result.JobrouteBflushType;
				JobrouteRunBasisLbr = result.JobrouteRunBasisLbr;
				JobrouteRunBasisMch = result.JobrouteRunBasisMch;
				UseFixedSchedule = result.UseFixedSchedule;
				JrtSchSchedHrs = result.JrtSchSchedHrs;
				JrtSchPcsPerLbrHr = result.JrtSchPcsPerLbrHr;
				JrtSchPcsPerMchHr = result.JrtSchPcsPerMchHr;
				JrtSchMoveHrs = result.JrtSchMoveHrs;
				JrtSchQueueHrs = result.JrtSchQueueHrs;
				JrtSchSetupHrs = result.JrtSchSetupHrs;
				UseOffsetHrs = result.UseOffsetHrs;
				JrtSchOffsetHrs = result.JrtSchOffsetHrs;
				WcDescription = result.WcDescription;
				JrtSchFinishHrs = result.JrtSchFinishHrs;
				JobrouteComplete = result.JobrouteComplete;
				JrtSchSchedDrv = result.JrtSchSchedDrv;
				JrtSchRunLbrHrs = result.JrtSchRunLbrHrs;
				JrtSchRunMchHrs = result.JrtSchRunMchHrs;
				JobrouteSetupRate = result.JobrouteSetupRate;
				JobrouteRunRateLbr = result.JobrouteRunRateLbr;
				JobrouteVovhdRateMch = result.JobrouteVovhdRateMch;
				JobrouteFovhdRateMch = result.JobrouteFovhdRateMch;
				JobrouteVarovhdRate = result.JobrouteVarovhdRate;
				JobrouteFixovhdRate = result.JobrouteFixovhdRate;
				JobrouteEfficiency = result.JobrouteEfficiency;
				JrtSchSchedsteprule = result.JrtSchSchedsteprule;
				JrtYield = result.JrtYield;
				JrtSchWhenRule = result.JrtSchWhenRule;
				JrtSchMatrixType = result.JrtSchMatrixType;
				JrtSchTabid = result.JrtSchTabid;
				JrtSchPlannerstep = result.JrtSchPlannerstep;
				JrtSchSetuprgid = result.JrtSchSetuprgid;
				JrtSchSetuprule = result.JrtSchSetuprule;
				JrtSchCrsBrkRule = result.JrtSchCrsBrkRule;
				JrtSchAllowReallocation = result.JrtSchAllowReallocation;
				JrtSchSplitSize = result.JrtSchSplitSize;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EngWBSetSessionVarsSp([Optional, DefaultParameterValue("")] string Job)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iEngWBSetSessionVarsExt = new EngWBSetSessionVarsFactory().Create(appDb);
				
				var result = iEngWBSetSessionVarsExt.EngWBSetSessionVarsSp(Job);
				
				
				return result.Value;
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SaveBomIBJobrouteSp(Guid? ProcessId,
		string Job,
		int? Suffix,
		int? OperNum,
		string Wc,
		string WcDescription)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSaveBomIBJobrouteExt = new SaveBomIBJobrouteFactory().Create(appDb);
				
				var result = iSaveBomIBJobrouteExt.SaveBomIBJobrouteSp(ProcessId,
				Job,
				Suffix,
				OperNum,
				Wc,
				WcDescription);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateEcnValForCurrOperSp(string Item,
		int? OperNum,
		ref string Job,
		ref int? Suffix,
		ref string JobType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateEcnValForCurrOperExt = new ValidateEcnValForCurrOperFactory().Create(appDb);
				
				var result = iValidateEcnValForCurrOperExt.ValidateEcnValForCurrOperSp(Item,
				OperNum,
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateEcnValForJobOperSp(string Job,
		int? Suffix,
		string JobType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateEcnValForJobOperExt = new ValidateEcnValForJobOperFactory().Create(appDb);
				
				var result = iValidateEcnValForJobOperExt.ValidateEcnValForJobOperSp(Job,
				Suffix,
				JobType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateJobSuffixSp(string Job,
		int? Suffix,
		ref string JobSuffix,
		ref string JobStat,
		ref decimal? QtyReleasesd,
		ref string JobItem,
		ref int? CoProductMix,
		ref string ItmDescription,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateJobSuffixExt = new ValidateJobSuffixFactory().Create(appDb);
				
				var result = iValidateJobSuffixExt.ValidateJobSuffixSp(Job,
				Suffix,
				JobSuffix,
				JobStat,
				QtyReleasesd,
				JobItem,
				CoProductMix,
				ItmDescription,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				JobSuffix = result.JobSuffix;
				JobStat = result.JobStat;
				QtyReleasesd = result.QtyReleasesd;
				JobItem = result.JobItem;
				CoProductMix = result.CoProductMix;
				ItmDescription = result.ItmDescription;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckOperNumForCurrOperSp(string Item,
		string Job,
		int? Suffix,
		string JobType,
		int? OperNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckOperNumForCurrOperExt = new CheckOperNumForCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckOperNumForCurrOperExt.CheckOperNumForCurrOperSp(Item,
				Job,
				Suffix,
				JobType,
				OperNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CopyBomLeaveItemSp(string FromCategory,
		ref string PsNum,
		ref string Item,
		ref string Job,
		ref int? Suffix,
		ref string ItemRev,
		ref int? StartOper,
		ref int? EndOper,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCopyBomLeaveItemExt = new CopyBomLeaveItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCopyBomLeaveItemExt.CopyBomLeaveItemSp(FromCategory,
				PsNum,
				Item,
				Job,
				Suffix,
				ItemRev,
				StartOper,
				EndOper,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PsNum = result.PsNum;
				Item = result.Item;
				Job = result.Job;
				Suffix = result.Suffix;
				ItemRev = result.ItemRev;
				StartOper = result.StartOper;
				EndOper = result.EndOper;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CopyNotesSp(string FromObject,
		Guid? FromRowPointer,
		string ToObject,
		Guid? ToRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCopyNotesExt = new CopyNotesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCopyNotesExt.CopyNotesSp(FromObject,
				FromRowPointer,
				ToObject,
				ToRowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EcnTrackSp(string PJob,
		int? PSuffix,
		string PType,
		ref int? PTrackEcn,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEcnTrackExt = new EcnTrackFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEcnTrackExt.EcnTrackSp(PJob,
				PSuffix,
				PType,
				PTrackEcn,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PTrackEcn = result.PTrackEcn;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EngWBCreateResourceGroupSp(string Job,
		int? Suffix,
		int? OperNum,
		string JrtWc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEngWBCreateResourceGroupExt = new EngWBCreateResourceGroupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEngWBCreateResourceGroupExt.EngWBCreateResourceGroupSp(Job,
				Suffix,
				OperNum,
				JrtWc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EngWBUpdateResourceGroupSp(string Job,
		int? Suffix,
		int? OperNum,
		[Optional] string UpdateResourceGroupFrom,
		Guid? FromJobRouteRowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEngWBUpdateResourceGroupExt = new EngWBUpdateResourceGroupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEngWBUpdateResourceGroupExt.EngWBUpdateResourceGroupSp(Job,
				Suffix,
				OperNum,
				UpdateResourceGroupFrom,
				FromJobRouteRowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetEcnValueForCurrOperSp(string Item,
		int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetEcnValueForCurrOperExt = new GetEcnValueForCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetEcnValueForCurrOperExt.GetEcnValueForCurrOperSp(Item,
				OperNum,
				Job,
				Suffix,
				JobType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
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
		public int JobOperationsSp(string OpCategory,
		ref string job,
		string SchedId,
		string Item,
		DateTime? Release,
		ref int? Suffix,
		ref string Type,
		[Optional] string AlternateID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJobOperationsExt = new JobOperationsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJobOperationsExt.JobOperationsSp(OpCategory,
				job,
				SchedId,
				Item,
				Release,
				Suffix,
				Type,
				AlternateID);
				
				int Severity = result.ReturnCode.Value;
				job = result.job;
				Suffix = result.Suffix;
				Type = result.Type;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobRouteCheckCostDistSp(string PJob,
		int? PSuffix,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJobRouteCheckCostDistExt = new JobRouteCheckCostDistFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJobRouteCheckCostDistExt.JobRouteCheckCostDistSp(PJob,
				PSuffix,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobRouteDeleteResourceGrpSp(string PJob,
		int? PSuffix,
		int? POperNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJobRouteDeleteResourceGrpExt = new JobRouteDeleteResourceGrpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJobRouteDeleteResourceGrpExt.JobRouteDeleteResourceGrpSp(PJob,
				PSuffix,
				POperNum);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobRouteGetPermSp(ref int? PAnyCanAdd,
		ref int? PAnyCanDelete,
		ref int? PAnyCanUpdate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJobRouteGetPermExt = new JobRouteGetPermFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJobRouteGetPermExt.JobRouteGetPermSp(PAnyCanAdd,
				PAnyCanDelete,
				PAnyCanUpdate);
				
				int Severity = result.ReturnCode.Value;
				PAnyCanAdd = result.PAnyCanAdd;
				PAnyCanDelete = result.PAnyCanDelete;
				PAnyCanUpdate = result.PAnyCanUpdate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobRouteOperNumSp(string PJob,
		int? PSuffix,
		int? POperNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJobRouteOperNumExt = new JobRouteOperNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJobRouteOperNumExt.JobRouteOperNumSp(PJob,
				PSuffix,
				POperNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LocalDisplayForCurrOperSp(string Item,
		int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		ref int? WcStat,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLocalDisplayForCurrOperExt = new LocalDisplayForCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLocalDisplayForCurrOperExt.LocalDisplayForCurrOperSp(Item,
				OperNum,
				Job,
				Suffix,
				JobType,
				WcStat,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				WcStat = result.WcStat;
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
		public int PP_CalcSetupAndRunTimes_LookupSp(string Job,
		int? Suffix,
		int? OperNum,
		decimal? JobQuantity,
		string PpjrOperationType,
		string PpjrOperationTypeCode,
		string PpjrItem,
		string PpjrResourceGroupID,
		decimal? PpjrSheetCount,
		decimal? PpjrOperDifficultFactor,
		string PpjrPaperMassBasis,
		int? PpjrNumberOfOrigColors,
		int? PpjrNumberOfSpclColors,
		ref decimal? SetupHrs,
		ref decimal? FinishHrs,
		ref decimal? PcsPerLbrHr,
		ref string RunBasisLbr,
		ref decimal? PcsPerMchHr,
		ref string RunBasisMch,
		ref int? OperTimesFound,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPP_CalcSetupAndRunTimes_LookupExt = new PP_CalcSetupAndRunTimes_LookupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPP_CalcSetupAndRunTimes_LookupExt.PP_CalcSetupAndRunTimes_LookupSp(Job,
				Suffix,
				OperNum,
				JobQuantity,
				PpjrOperationType,
				PpjrOperationTypeCode,
				PpjrItem,
				PpjrResourceGroupID,
				PpjrSheetCount,
				PpjrOperDifficultFactor,
				PpjrPaperMassBasis,
				PpjrNumberOfOrigColors,
				PpjrNumberOfSpclColors,
				SetupHrs,
				FinishHrs,
				PcsPerLbrHr,
				RunBasisLbr,
				PcsPerMchHr,
				RunBasisMch,
				OperTimesFound,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				SetupHrs = result.SetupHrs;
				FinishHrs = result.FinishHrs;
				PcsPerLbrHr = result.PcsPerLbrHr;
				RunBasisLbr = result.RunBasisLbr;
				PcsPerMchHr = result.PcsPerMchHr;
				RunBasisMch = result.RunBasisMch;
				OperTimesFound = result.OperTimesFound;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_PostSavePrintingEstWorkbenchOperSp(string Job,
		int? Suffix,
		int? OperNum,
		string WC,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPP_PostSavePrintingEstWorkbenchOperExt = new PP_PostSavePrintingEstWorkbenchOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPP_PostSavePrintingEstWorkbenchOperExt.PP_PostSavePrintingEstWorkbenchOperSp(Job,
				Suffix,
				OperNum,
				WC,
				Infobar);
				
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreSaveCostAltCurrOperSp(string CostingAlt,
		string Item,
		int? OperNum,
		string Wc,
		ref string Job,
		ref int? Suffix,
		ref string JobType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPreSaveCostAltCurrOperExt = new PreSaveCostAltCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPreSaveCostAltCurrOperExt.PreSaveCostAltCurrOperSp(CostingAlt,
				Item,
				OperNum,
				Wc,
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreSaveCurrOperSp(string Item,
		int? OperNum,
		string Wc,
		ref string Job,
		ref int? Suffix,
		ref string JobType,
		ref string Infobar,
		[Optional] string AlternateID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPreSaveCurrOperExt = new PreSaveCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPreSaveCurrOperExt.PreSaveCurrOperSp(Item,
				OperNum,
				Wc,
				Job,
				Suffix,
				JobType,
				Infobar,
				AlternateID);
				
				int Severity = result.ReturnCode.Value;
				Job = result.Job;
				Suffix = result.Suffix;
				JobType = result.JobType;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetItemValuesForCurrOperSp(string Item,
		ref int? OperNum,
		ref string Wc,
		ref string WcDescription,
		ref DateTime? EffectDate,
		ref DateTime? ObsDate,
		ref int? CntrlPoint,
		ref string BflushType,
		ref decimal? JshSchedHrs,
		ref string RunBasisMch,
		ref string RunBasisLbr,
		ref decimal? JshRunMchHrs,
		ref decimal? JshRunLbrHrs,
		ref decimal? JshMoveHrs,
		ref decimal? JshQueueHrs,
		ref decimal? JshSetupHrs,
		ref decimal? JshOffsetHrs,
		ref decimal? Efficiency,
		ref decimal? SetupRate,
		ref decimal? RunRateLbr,
		ref decimal? VovhdRateMch,
		ref decimal? FovhdRateMch,
		ref decimal? VarovhdRate,
		ref decimal? FixovhdRate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSetItemValuesForCurrOperExt = new SetItemValuesForCurrOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSetItemValuesForCurrOperExt.SetItemValuesForCurrOperSp(Item,
				OperNum,
				Wc,
				WcDescription,
				EffectDate,
				ObsDate,
				CntrlPoint,
				BflushType,
				JshSchedHrs,
				RunBasisMch,
				RunBasisLbr,
				JshRunMchHrs,
				JshRunLbrHrs,
				JshMoveHrs,
				JshQueueHrs,
				JshSetupHrs,
				JshOffsetHrs,
				Efficiency,
				SetupRate,
				RunRateLbr,
				VovhdRateMch,
				FovhdRateMch,
				VarovhdRate,
				FixovhdRate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				OperNum = result.OperNum;
				Wc = result.Wc;
				WcDescription = result.WcDescription;
				EffectDate = result.EffectDate;
				ObsDate = result.ObsDate;
				CntrlPoint = result.CntrlPoint;
				BflushType = result.BflushType;
				JshSchedHrs = result.JshSchedHrs;
				RunBasisMch = result.RunBasisMch;
				RunBasisLbr = result.RunBasisLbr;
				JshRunMchHrs = result.JshRunMchHrs;
				JshRunLbrHrs = result.JshRunLbrHrs;
				JshMoveHrs = result.JshMoveHrs;
				JshQueueHrs = result.JshQueueHrs;
				JshSetupHrs = result.JshSetupHrs;
				JshOffsetHrs = result.JshOffsetHrs;
				Efficiency = result.Efficiency;
				SetupRate = result.SetupRate;
				RunRateLbr = result.RunRateLbr;
				VovhdRateMch = result.VovhdRateMch;
				FovhdRateMch = result.FovhdRateMch;
				VarovhdRate = result.VarovhdRate;
				FixovhdRate = result.FixovhdRate;
				Infobar = result.Infobar;
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_UpdateAlternateDescSp(string Job,
		int? JobSuffix,
		[Optional] string AlternateDescription)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMO_UpdateAlternateDescExt = new MO_UpdateAlternateDescFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMO_UpdateAlternateDescExt.MO_UpdateAlternateDescSp(Job,
				JobSuffix,
				AlternateDescription);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
