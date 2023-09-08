//PROJECT NAME: CustomerExt
//CLASS NAME: SLArEftImportArpmtds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.AR;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLArEftImportArpmtds")]
    public class SLArEftImportArpmtds : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AREFTImportValidateSp(string SourceSite,
                                         decimal? BatchId,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAREFTImportValidateExt = new AREFTImportValidateFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iAREFTImportValidateExt.AREFTImportValidateSp(SourceSite,
                                                                             BatchId,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None)]
        public int GetCustNumFromArtranAllSp(string InvNum,
                        string Site,
                        ref string CustNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var mgInvoker = new MGInvoker(this.Context);
                var mgCommandProvider = new MGCommandProvider(MGAppDB);
                var mgParameterProvider = new SQLParameterProvider();
                var mgMessageProvider = new MGMessageProvider(this.GetMessageProvider());
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                //var iArCalcdiscExt = new ArCalcdiscFactory().Create(appDb);
                var iGetCustNumFromArtranAllExt = new GetCustNumFromArtranAllFactory().Create(appDb, mgInvoker, mgParameterProvider, true, mgMessageProvider);

                int Severity = iGetCustNumFromArtranAllExt.GetCustNumFromArtranAllSp(InvNum,
                                                                                     Site,
                                                                                     ref CustNum);
                return Severity;
            }

        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArCalcdiscSp(string PCurApplyCustNum,
		string PCurInvNum,
		DateTime? PPaymentReceiptDate,
		[Optional] string Site,
		ref decimal? TDisc,
		ref decimal? TBal,
		[Optional, DefaultParameterValue(0)] ref decimal? TaxDiscount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArCalcdiscExt = new ArCalcdiscFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArCalcdiscExt.ArCalcdiscSp(PCurApplyCustNum,
				PCurInvNum,
				PPaymentReceiptDate,
				Site,
				TDisc,
				TBal,
				TaxDiscount);
				
				int Severity = result.ReturnCode.Value;
				TDisc = result.TDisc;
				TBal = result.TBal;
				TaxDiscount = result.TaxDiscount;
				return Severity;
			}
		}
    }
}
