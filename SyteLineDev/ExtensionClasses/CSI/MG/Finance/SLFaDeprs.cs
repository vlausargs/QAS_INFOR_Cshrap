//PROJECT NAME: FinanceExt
//CLASS NAME: SLFaDeprs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.FixedAssets;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFaDeprs")]
    public class SLFaDeprs : ExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable FaUpdPreFetchSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSLFaDeprsExt = new FaUpdPreFetchFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSLFaDeprsExt.FaUpdPreFetchSp();

                return dt;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FaUpdSp(DateTime? TPostDate,
                           int? ErrorCnt,
                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFaDeprsExt = new FaUpdFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLFaDeprsExt.FaUpdSp(TPostDate,
                                                     ErrorCnt,
                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FaUpdPreSp(decimal? PUserID,
                               int? ErrorCnt,
                               ref string PromptMsg,
                               ref string PromptButtons,
                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFaDeprsExt = new FaUpdPreFactory().Create(appDb);

                InfobarType oPromptMsg = PromptMsg;
                Infobar oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iSLFaDeprsExt.FaUpdPreSp(PUserID,
                                                        ErrorCnt,
                                                        ref oPromptMsg,
                                                        ref oPromptButtons,
                                                        ref oInfobar);

                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FaUpdPostSp(decimal? PUserID,
                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFaDeprsExt = new FaUpdPostFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLFaDeprsExt.FaUpdPostSp(PUserID,
                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FAFindMaxDeprCodeSp(string AssetNumber,
                                         ref int? MaxDeprCode)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFaDeprsExt = new FAFindMaxDeprCodeFactory().Create(appDb);

                IntType oMaxDeprCode = MaxDeprCode;

                int Severity = iSLFaDeprsExt.FAFindMaxDeprCodeSp(AssetNumber,
                                                                 ref oMaxDeprCode);

                MaxDeprCode = oMaxDeprCode;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FaEndSp(string AssetNumStart,
                            string AssetNumEnd,
                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFaDeprsExt = new FaEndFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLFaDeprsExt.FaEndSp(AssetNumStart,
                                                     AssetNumEnd,
                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenDeprSp(string AssetNumStart,
		                     string AssetNumEnd,
		                     [Optional, DefaultParameterValue((byte)0)] byte? YearEndProcessing,
		DateTime? AsOfDate,
		short? AsOfDateIncrementDate,
		ref string Infobar,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGenDeprExt = new GenDeprFactory().Create(appDb);
				
				var result = iGenDeprExt.GenDeprSp(AssetNumStart,
				                                   AssetNumEnd,
				                                   YearEndProcessing,
				                                   AsOfDate,
				                                   AsOfDateIncrementDate,
				                                   Infobar,
				                                   BGUser);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int THAGetAcqDateSp(string FaNum,
		ref DateTime? AcqDate,
		ref int? AddOne,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHAGetAcqDateExt = new THAGetAcqDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHAGetAcqDateExt.THAGetAcqDateSp(FaNum,
				AcqDate,
				AddOne,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				AcqDate = result.AcqDate;
				AddOne = result.AddOne;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
