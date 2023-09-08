//PROJECT NAME: ProductExt
//CLASS NAME: SLPsitems.cs

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
    [IDOExtensionClass("SLPsitems")]
    public class SLPsitems : ExtensionClassBase, IExtFTSLPsitems
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PsitemJobCopySp(string PJob,
                                   byte? PCopyBOMToPSReleases,
                                   byte? PCopyItemBOMToPSBOM,
                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPsitemJobCopyExt = new PsitemJobCopyFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iPsitemJobCopyExt.PsitemJobCopySp(PJob,
                                                                 PCopyBOMToPSReleases,
                                                                 PCopyItemBOMToPSBOM,
                                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PsitemPreDeleteSp(string PPsJob,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPsitemPreDeleteExt = new PsitemPreDeleteFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iPsitemPreDeleteExt.PsitemPreDeleteSp(PPsJob,
                                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PsitemReleaseWoRoutingSp(string PJob,
                                            ref byte? ReleaseExistWoRouting)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPsitemReleaseWoRoutingExt = new PsitemReleaseWoRoutingFactory().Create(appDb);

                ListYesNoType oReleaseExistWoRouting = ReleaseExistWoRouting;

                int Severity = iPsitemReleaseWoRoutingExt.PsitemReleaseWoRoutingSp(PJob,
                                                                                   ref oReleaseExistWoRouting);

                ReleaseExistWoRouting = oReleaseExistWoRouting;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSCmplTransGetVarsSp(ref decimal? JobtranTransNum,
		                                ref byte? TCoby,
		                                ref string Infobar,
		                                [Optional] ref string PromptMsg,
		                                [Optional] ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSCmplTransGetVarsExt = new PSCmplTransGetVarsFactory().Create(appDb);
				
				var result = iPSCmplTransGetVarsExt.PSCmplTransGetVarsSp(JobtranTransNum,
				                                                         TCoby,
				                                                         Infobar,
				                                                         PromptMsg,
				                                                         PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				JobtranTransNum = result.JobtranTransNum;
				TCoby = result.TCoby;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSCmplTransSetVarsSp(string SET,
		                                string Item,
		                                decimal? Qty,
		                                DateTime? TransDate,
		                                string PsNum,
		                                string Employee,
		                                int? OperNum,
		                                string Wc,
		                                string Shift,
		                                string Loc,
		                                string Lot,
		                                string SerialPrefix,
		                                Guid? SessionID,
		                                ref decimal? JobtranTransNum,
		                                ref byte? TCoby,
		                                ref string Infobar,
		                                [Optional] ref string PromptMsg,
		                                [Optional] ref string PromptButtons,
		                                [Optional, DefaultParameterValue((byte)0)] byte? CreateMatPostRecord,
		[Optional] string ContainerNum,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSCmplTransSetVarsExt = new PSCmplTransSetVarsFactory().Create(appDb);
				
				var result = iPSCmplTransSetVarsExt.PSCmplTransSetVarsSp(SET,
				                                                         Item,
				                                                         Qty,
				                                                         TransDate,
				                                                         PsNum,
				                                                         Employee,
				                                                         OperNum,
				                                                         Wc,
				                                                         Shift,
				                                                         Loc,
				                                                         Lot,
				                                                         SerialPrefix,
				                                                         SessionID,
				                                                         JobtranTransNum,
				                                                         TCoby,
				                                                         Infobar,
				                                                         PromptMsg,
				                                                         PromptButtons,
				                                                         CreateMatPostRecord,
				                                                         ContainerNum,
				                                                         DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				JobtranTransNum = result.JobtranTransNum;
				TCoby = result.TCoby;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSCmplTransSp(string Item,
		                         decimal? Qty,
		                         DateTime? TransDate,
		                         string PsNum,
		                         string Employee,
		                         int? OperNum,
		                         string Wc,
		                         string Shift,
		                         string Loc,
		                         string Lot,
		                         string SerialPrefix,
		                         Guid? SessionID,
		                         ref decimal? JobtranTransNum,
		                         ref byte? TCoby,
		                         ref string Infobar,
		                         [Optional] ref string PromptMsg,
		                         [Optional] ref string PromptButtons,
		                         [Optional, DefaultParameterValue((byte)0)] byte? CreateMatPostRecord,
		[Optional] string ContainerNum,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSCmplTransExt = new PSCmplTransFactory().Create(appDb);
				
				var result = iPSCmplTransExt.PSCmplTransSp(Item,
				                                           Qty,
				                                           TransDate,
				                                           PsNum,
				                                           Employee,
				                                           OperNum,
				                                           Wc,
				                                           Shift,
				                                           Loc,
				                                           Lot,
				                                           SerialPrefix,
				                                           SessionID,
				                                           JobtranTransNum,
				                                           TCoby,
				                                           Infobar,
				                                           PromptMsg,
				                                           PromptButtons,
				                                           CreateMatPostRecord,
				                                           ContainerNum,
				                                           DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				JobtranTransNum = result.JobtranTransNum;
				TCoby = result.TCoby;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSScrapTransSp(string Item,
		                          decimal? ScrapQty,
		                          DateTime? TransDate,
		                          string PsNum,
		                          string ReasonCode,
		                          string Employee,
		                          int? OperNum,
		                          string Wc,
		                          string Shift,
		                          Guid? SessionID,
		                          ref decimal? JobtranTransNum,
		                          ref byte? TCoby,
		                          ref string Infobar,
		                          [Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSScrapTransExt = new PSScrapTransFactory().Create(appDb);
				
				var result = iPSScrapTransExt.PSScrapTransSp(Item,
				                                             ScrapQty,
				                                             TransDate,
				                                             PsNum,
				                                             ReasonCode,
				                                             Employee,
				                                             OperNum,
				                                             Wc,
				                                             Shift,
				                                             SessionID,
				                                             JobtranTransNum,
				                                             TCoby,
				                                             Infobar,
				                                             DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				JobtranTransNum = result.JobtranTransNum;
				TCoby = result.TCoby;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdatePsitemHeaderSp(string Job,
		string JobWhse,
		string JobRevision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdatePsitemHeaderExt = new UpdatePsitemHeaderFactory().Create(appDb);
				
				var result = iUpdatePsitemHeaderExt.UpdatePsitemHeaderSp(Job,
				JobWhse,
				JobRevision);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EngWBPsSaveSp(int? InsertFlag,
		string PsNum,
		string PsStatus,
		string PsDescription,
		string Item,
		string Whse,
		string Revision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEngWBPsSaveExt = new EngWBPsSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEngWBPsSaveExt.EngWBPsSaveSp(InsertFlag,
				PsNum,
				PsStatus,
				PsDescription,
				Item,
				Whse,
				Revision);
				
				int Severity = result.Value;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PsitemItemValidSp(string PsNum,
		ref string Item,
		ref string Revision,
		ref string Description,
		ref int? StdBOMExists,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPsitemItemValidExt = new PsitemItemValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPsitemItemValidExt.PsitemItemValidSp(PsNum,
				Item,
				Revision,
				Description,
				StdBOMExists,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				Revision = result.Revision;
				Description = result.Description;
				StdBOMExists = result.StdBOMExists;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PsitemSetGloVarSp([Optional] string JobWhse,
		[Optional] string JobRevision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPsitemSetGloVarExt = new PsitemSetGloVarFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPsitemSetGloVarExt.PsitemSetGloVarSp(JobWhse,
				JobRevision);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PsitemEndDateSp(string PPsNum,
		string PItem,
		string PPsJob,
		ref DateTime? PEndDate,
		ref decimal? PEndTick,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPsitemEndDateExt = new PsitemEndDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPsitemEndDateExt.PsitemEndDateSp(PPsNum,
				PItem,
				PPsJob,
				PEndDate,
				PEndTick,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PEndDate = result.PEndDate;
				PEndTick = result.PEndTick;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
