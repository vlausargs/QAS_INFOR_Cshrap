//PROJECT NAME: ProductExt
//CLASS NAME: SLTmpJobSplits.cs

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
    [IDOExtensionClass("SLTmpJobSplits")]
    public class SLTmpJobSplits : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DeleteTmpJobSplitSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDeleteTmpJobSplitExt = new DeleteTmpJobSplitFactory().Create(appDb);

                int Severity = iDeleteTmpJobSplitExt.DeleteTmpJobSplitSp();

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JobSplitPreassignedLotsSp(string NewJob,
                                             short? NewSuffix,
                                             string Job,
                                             short? Suffix,
                                             string Item,
                                             string Lot,
                                             decimal? Qty,
                                             ref string Infobar,
                                             byte? Copy)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iJobSplitPreassignedLotsExt = new JobSplitPreassignedLotsFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iJobSplitPreassignedLotsExt.JobSplitPreassignedLotsSp(NewJob,
                                                                                     NewSuffix,
                                                                                     Job,
                                                                                     Suffix,
                                                                                     Item,
                                                                                     Lot,
                                                                                     Qty,
                                                                                     ref oInfobar,
                                                                                     Copy);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JobSplitPreassignedSerialsSp(string NewJob,
                                                short? NewSuffix,
                                                string Item,
                                                string SerNum,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iJobSplitPreassignedSerialsExt = new JobSplitPreassignedSerialsFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iJobSplitPreassignedSerialsExt.JobSplitPreassignedSerialsSp(NewJob,
                                                                                           NewSuffix,
                                                                                           Item,
                                                                                           SerNum,
                                                                                           ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JobSplitValidationSp(string PJob,
                                        short? PSuffix,
                                        int? PToJob,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iJobSplitValidationExt = new JobSplitValidationFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iJobSplitValidationExt.JobSplitValidationSp(PJob,
                                                                           PSuffix,
                                                                           PToJob,
                                                                           ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JobSplitValidSp(string Job,
                                   short? Suffix,
                                   string NewJob,
                                   short? NewSuffix,
                                   ref string OutNewJob,
                                   ref short? OutNewSuffix,
                                   ref decimal? QtyReleased,
                                   ref decimal? QtyCompleted,
                                   ref decimal? QtyToSplit,
                                   ref string Infobar,
                                   ref byte? PreassignLots,
                                   ref byte? PreassignSerials,
                                   ref string Item)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iJobSplitValidExt = new JobSplitValidFactory().Create(appDb);

                JobType oOutNewJob = OutNewJob;
                SuffixType oOutNewSuffix = OutNewSuffix;
                QtyUnitType oQtyReleased = QtyReleased;
                QtyUnitType oQtyCompleted = QtyCompleted;
                QtyUnitType oQtyToSplit = QtyToSplit;
                InfobarType oInfobar = Infobar;
                ListYesNoType oPreassignLots = PreassignLots;
                ListYesNoType oPreassignSerials = PreassignSerials;
                ItemType oItem = Item;

                int Severity = iJobSplitValidExt.JobSplitValidSp(Job,
                                                                 Suffix,
                                                                 NewJob,
                                                                 NewSuffix,
                                                                 ref oOutNewJob,
                                                                 ref oOutNewSuffix,
                                                                 ref oQtyReleased,
                                                                 ref oQtyCompleted,
                                                                 ref oQtyToSplit,
                                                                 ref oInfobar,
                                                                 ref oPreassignLots,
                                                                 ref oPreassignSerials,
                                                                 ref oItem);

                OutNewJob = oOutNewJob;
                OutNewSuffix = oOutNewSuffix;
                QtyReleased = oQtyReleased;
                QtyCompleted = oQtyCompleted;
                QtyToSplit = oQtyToSplit;
                Infobar = oInfobar;
                PreassignLots = oPreassignLots;
                PreassignSerials = oPreassignSerials;
                Item = oItem;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobsmlSp(string Job,
		                    short? Suffix,
		                    string NewJob,
		                    short? NewSuffix,
		                    decimal? QtyToSplit,
		                    string Title,
		                    byte? Process,
		                    ref string Infobar,
		                    [Optional, DefaultParameterValue((byte)0)] byte? CopyUetValues)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iJobsmlExt = new JobsmlFactory().Create(appDb);
				
				var result = iJobsmlExt.JobsmlSp(Job,
				                                 Suffix,
				                                 NewJob,
				                                 NewSuffix,
				                                 QtyToSplit,
				                                 Title,
				                                 Process,
				                                 Infobar,
				                                 CopyUetValues);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobSplitAdjustmentSp(int? Mode,
		string NewJob,
		int? NewSuffix,
		int? OperNum,
		decimal? OpQtyReceived,
		decimal? OpQtyComplete,
		decimal? OpQtyMoved,
		decimal? OpSetupHrsT,
		decimal? OpRunHrsTLbr,
		decimal? OpRunHrsTMch,
		string MatlItem,
		string MatlType,
		decimal? MatlQtyIssuedConv,
		decimal? MatlAMatlCost,
		decimal? MatlALbrCost,
		decimal? MatlAOutCost,
		decimal? MatlAFovhdCost,
		decimal? MatlAVovhdCost,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJobSplitAdjustmentExt = new JobSplitAdjustmentFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJobSplitAdjustmentExt.JobSplitAdjustmentSp(Mode,
				NewJob,
				NewSuffix,
				OperNum,
				OpQtyReceived,
				OpQtyComplete,
				OpQtyMoved,
				OpSetupHrsT,
				OpRunHrsTLbr,
				OpRunHrsTMch,
				MatlItem,
				MatlType,
				MatlQtyIssuedConv,
				MatlAMatlCost,
				MatlALbrCost,
				MatlAOutCost,
				MatlAFovhdCost,
				MatlAVovhdCost,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
