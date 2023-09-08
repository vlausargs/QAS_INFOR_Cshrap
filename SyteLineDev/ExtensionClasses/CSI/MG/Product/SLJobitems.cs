//PROJECT NAME: ProductExt
//CLASS NAME: SLJobitems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLJobitems")]
    public class SLJobitems : ExtensionClassBase, IExtFTSLJobitems
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoProductGetRefInfoSp(string OrderType,
                                         string OrderNum,
                                         short? OrderLine,
                                         short? OrderRelease,
                                         ref string CustNum,
                                         ref string CustName,
                                         ref decimal? QtyOrdered,
                                         ref DateTime? OrderDate,
                                         ref DateTime? DueDate,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoProductGetRefInfoExt = new CoProductGetRefInfoFactory().Create(appDb);

                CoNumType oCustNum = CustNum;
                NameType oCustName = CustName;
                QtyUnitType oQtyOrdered = QtyOrdered;
                DateType oOrderDate = OrderDate;
                DateType oDueDate = DueDate;
                InfobarType oInfobar = Infobar;

                int Severity = iCoProductGetRefInfoExt.CoProductGetRefInfoSp(OrderType,
                                                                             OrderNum,
                                                                             OrderLine,
                                                                             OrderRelease,
                                                                             ref oCustNum,
                                                                             ref oCustName,
                                                                             ref oQtyOrdered,
                                                                             ref oOrderDate,
                                                                             ref oDueDate,
                                                                             ref oInfobar);

                CustNum = oCustNum;
                CustName = oCustName;
                QtyOrdered = oQtyOrdered;
                OrderDate = oOrderDate;
                DueDate = oDueDate;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoProductPostDeleteSp(string Job,
                                                short? Suffix,
                                                string Item,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoProductPostDeleteExt = new CoProductPostDeleteFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCoProductPostDeleteExt.CoProductPostDeleteSp(Job,
                                                                             Suffix,
                                                                             Item,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoProductPreSaveSp(string Job,
                                      short? Suffix,
                                      string JobItem,
                                      string JobitemItem,
                                      string JobStat,
                                      decimal? JobQtyReleased,
                                      decimal? NewJobitemQtyReleased,
                                      decimal? OldJobitemQtyReleased,
                                      short? NewRatio1,
                                      short? OldRatio1,
                                      decimal? JobitemQtyComplete,
                                      ref string OrderType,
                                      ref string OrderNum,
                                      ref short? OrderLine,
                                      ref short? OrderRelease,
                                      ref string PromptMsg,
                                      ref string PromptButtons,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoProductPreSaveExt = new CoProductPreSaveFactory().Create(appDb);

                RefTypeIKOTType oOrderType = OrderType;
                CoProjTrnNumType oOrderNum = OrderNum;
                CoProjTaskTrnLineType oOrderLine = OrderLine;
                CoReleaseType oOrderRelease = OrderRelease;
                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iCoProductPreSaveExt.CoProductPreSaveSp(Job,
                                                                       Suffix,
                                                                       JobItem,
                                                                       JobitemItem,
                                                                       JobStat,
                                                                       JobQtyReleased,
                                                                       NewJobitemQtyReleased,
                                                                       OldJobitemQtyReleased,
                                                                       NewRatio1,
                                                                       OldRatio1,
                                                                       JobitemQtyComplete,
                                                                       ref oOrderType,
                                                                       ref oOrderNum,
                                                                       ref oOrderLine,
                                                                       ref oOrderRelease,
                                                                       ref oPromptMsg,
                                                                       ref oPromptButtons,
                                                                       ref oInfobar);

                OrderType = oOrderType;
                OrderNum = oOrderNum;
                OrderLine = oOrderLine;
                OrderRelease = oOrderRelease;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoProductSyncRatio2Sp(string PJob,
                                         short? PSuffix,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoProductSyncRatio2Ext = new CoProductSyncRatio2Factory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCoProductSyncRatio2Ext.CoProductSyncRatio2Sp(PJob,
                                                                             PSuffix,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoProductValidateRatio1Sp(decimal? PQtyReleased,
                                             short? PRatio1,
                                             string PJob,
                                             short? PSuffix,
                                             string PItem,
                                             ref short? PRatio2,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoProductValidateRatio1Ext = new CoProductValidateRatio1Factory().Create(appDb);

                TotalProdMixQuantityType oPRatio2 = PRatio2;
                InfobarType oInfobar = Infobar;

                int Severity = iCoProductValidateRatio1Ext.CoProductValidateRatio1Sp(PQtyReleased,
                                                                                     PRatio1,
                                                                                     PJob,
                                                                                     PSuffix,
                                                                                     PItem,
                                                                                     ref oPRatio2,
                                                                                     ref oInfobar);

                PRatio2 = oPRatio2;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetJobDetailSp(string InJob,
                                  short? InSuffix,
                                  ref byte? JobCoProdMix,
                                  ref string JobFormattedJob,
                                  ref string JobItem,
                                  ref string JobItemDesc,
                                  ref string JobWhse,
                                  ref byte? JobPreassignLots,
                                  ref byte? JobPreassignSerials,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetJobDetailExt = new GetJobDetailFactory().Create(appDb);

                ListYesNoType oJobCoProdMix = JobCoProdMix;
                InfobarType oJobFormattedJob = JobFormattedJob;
                ItemType oJobItem = JobItem;
                DescriptionType oJobItemDesc = JobItemDesc;
                WhseType oJobWhse = JobWhse;
                ListYesNoType oJobPreassignLots = JobPreassignLots;
                ListYesNoType oJobPreassignSerials = JobPreassignSerials;
                InfobarType oInfobar = Infobar;

                int Severity = iGetJobDetailExt.GetJobDetailSp(InJob,
                                                               InSuffix,
                                                               ref oJobCoProdMix,
                                                               ref oJobFormattedJob,
                                                               ref oJobItem,
                                                               ref oJobItemDesc,
                                                               ref oJobWhse,
                                                               ref oJobPreassignLots,
                                                               ref oJobPreassignSerials,
                                                               ref oInfobar);

                JobCoProdMix = oJobCoProdMix;
                JobFormattedJob = oJobFormattedJob;
                JobItem = oJobItem;
                JobItemDesc = oJobItemDesc;
                JobWhse = oJobWhse;
                JobPreassignLots = oJobPreassignLots;
                JobPreassignSerials = oJobPreassignSerials;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JobGenMix1Sp(string PJob,
                                short? PSuffix,
                                Guid? SessionID,
                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iJobGenMix1Ext = new JobGenMix1Factory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iJobGenMix1Ext.JobGenMix1Sp(PJob,
                                                           PSuffix,
                                                           SessionID,
                                                           ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PerformQtyRollupSp(decimal? PNewJobitemQtyReleased,
                                      decimal? POldJobitemQtyReleased,
                                      short? PNewRatio1,
                                      short? POldRatio1,
                                      string PJob,
                                      short? PSuffix,
                                      string PItem,
                                      string PJobItem,
                                      decimal? PJobitemQtyComplete,
                                      decimal? PJobQtyReleased,
                                      string PJobStat,
                                      string PWhse,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPerformQtyRollupExt = new PerformQtyRollupFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iPerformQtyRollupExt.PerformQtyRollupSp(PNewJobitemQtyReleased,
                                                                       POldJobitemQtyReleased,
                                                                       PNewRatio1,
                                                                       POldRatio1,
                                                                       PJob,
                                                                       PSuffix,
                                                                       PItem,
                                                                       PJobItem,
                                                                       PJobitemQtyComplete,
                                                                       PJobQtyReleased,
                                                                       PJobStat,
                                                                       PWhse,
                                                                       ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalculateRatio2Sp(string PJob,
		int? PSuffix,
		string PItem,
		int? POldRatio2,
		ref int? PRatio2,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCalculateRatio2Ext = new CalculateRatio2Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCalculateRatio2Ext.CalculateRatio2Sp(PJob,
				PSuffix,
				PItem,
				POldRatio2,
				PRatio2,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PRatio2 = result.PRatio2;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DropProdMixTTSp(Guid? PSessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDropProdMixTTExt = new DropProdMixTTFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDropProdMixTTExt.DropProdMixTTSp(PSessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
