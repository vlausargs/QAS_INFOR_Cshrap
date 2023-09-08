//PROJECT NAME: ProductExt
//CLASS NAME: SLBatchRoutes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLBatchRoutes")]
    public class SLBatchRoutes : ExtensionClassBase
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
		public int PreSaveBatchOperSp(string Batch,
		ref int? OperNum,
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
				
				var iPreSaveBatchOperExt = new PreSaveBatchOperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPreSaveBatchOperExt.PreSaveBatchOperSp(Batch,
				OperNum,
				Wc,
				Job,
				Suffix,
				JobType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				OperNum = result.OperNum;
				Job = result.Job;
				Suffix = result.Suffix;
				JobType = result.JobType;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
