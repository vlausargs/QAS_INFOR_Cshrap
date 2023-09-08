//PROJECT NAME: AdminExt
//CLASS NAME: SLJourHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLJourHdrs")]
    public class SLJourHdrs : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JourHdrValidateSp(string NewPrefix,
                                     string JournalId,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iJourHdrValidateExt = new JourHdrValidateFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iJourHdrValidateExt.JourHdrValidateSp(NewPrefix,
                                                                     JournalId,
                                                                     ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DelJournalTxSp(string pJourHdrId,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDelJournalTxExt = new DelJournalTxFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iDelJournalTxExt.DelJournalTxSp(pJourHdrId,
                                                               ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckReadOnlyJournalSp(string JournalID,
                                          ref byte? ReadOnly)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckReadOnlyJournalExt = new CheckReadOnlyJournalFactory().Create(appDb);

                ListYesNoType oReadOnly = ReadOnly;

                int Severity = iCheckReadOnlyJournalExt.CheckReadOnlyJournalSp(JournalID,
                                                                               ref oReadOnly);

                ReadOnly = oReadOnly;

                return Severity;
            }
        }
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckJourlockStatSp(string Id,
			ref string Infobar)
		{
			var iCheckJourlockStatExt = this.GetService<ICheckJourlockStat>();
			
			var result = iCheckJourlockStatExt.CheckJourlockStatSp(Id,
				Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeJournalSp(string pJournalId,
		                          DateTime? pCutoffDate,
		                          [Optional] short? CutoffDateOffset,
		                          decimal? UserId,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurgeJournalExt = new PurgeJournalFactory().Create(appDb);
				
				var result = iPurgeJournalExt.PurgeJournalSp(pJournalId,
				                                             pCutoffDate,
				                                             CutoffDateOffset,
				                                             UserId,
				                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SumJourCheckSp(string Id,
		                          [Optional] DateTime? PSDate,
		                          [Optional] DateTime? PEDate,
		                          ref string Buttons,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSumJourCheckExt = new SumJourCheckFactory().Create(appDb);
				
				var result = iSumJourCheckExt.SumJourCheckSp(Id,
				                                             PSDate,
				                                             PEDate,
				                                             Buttons,
				                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				Buttons = result.Buttons;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SumJourSp(string Id,
		int? Repair)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSumJourExt = new SumJourFactory().Create(appDb);
				
				var result = iSumJourExt.SumJourSp(Id,
				Repair);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SumJourFixSp(string Id,
		[Optional] DateTime? PSDate,
		[Optional] DateTime? PEDate,
		ref string Infobar,
		[Optional] int? StartingTransDateOffset,
		[Optional] int? EndingTransDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSumJourFixExt = new SumJourFixFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSumJourFixExt.SumJourFixSp(Id,
				PSDate,
				PEDate,
				Infobar,
				StartingTransDateOffset,
				EndingTransDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
