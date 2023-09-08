//PROJECT NAME: POSExt
//CLASS NAME: POSMPayments.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.POS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.POS
{
    [IDOExtensionClass("POSMPayments")]
    public class POSMPayments : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSPOSPaymentAmtValidSp(string POSNum,
                                           decimal? PNRef,
                                           decimal? Amount,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSPOSPaymentAmtValidExt = new SSSPOSPaymentAmtValidFactory().Create(appDb);

                int Severity = iSSSPOSPaymentAmtValidExt.SSSPOSPaymentAmtValidSp(POSNum,
                                                                                 PNRef,
                                                                                 Amount,
                                                                                 ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSPOSValCustTransTypeSp(string CustNum,
                                            ref byte? CanOnAcct,
                                            ref byte? CanCash,
                                            ref byte? CanCreditCard,
                                            ref byte? CanCheck,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSPOSValCustTransTypeExt = new SSSPOSValCustTransTypeFactory().Create(appDb);

                int Severity = iSSSPOSValCustTransTypeExt.SSSPOSValCustTransTypeSp(CustNum,
                                                                                   ref CanOnAcct,
                                                                                   ref CanCash,
                                                                                   ref CanCreditCard,
                                                                                   ref CanCheck,
                                                                                   ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSPOSPaymentDefaultSp(string POSNum,
		ref string PayType,
		ref decimal? Amount,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSPOSPaymentDefaultExt = new SSSPOSPaymentDefaultFactory().Create(appDb);
				
				var result = iSSSPOSPaymentDefaultExt.SSSPOSPaymentDefaultSp(POSNum,
				PayType,
				Amount,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PayType = result.PayType;
				Amount = result.Amount;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
