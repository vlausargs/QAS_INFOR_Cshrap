//PROJECT NAME: MG
//CLASS NAME: CCIParms.cs

////PROJECT NAME: CCIExt
////CLASS NAME: CCIParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.CreditCard;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.CCI
{
    [IDOExtensionClass("CCIParms")]
    public class CCIParms : CSIExtensionClassBase, ICCIParms
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSCCIEncryptPasswordWrapSp(string Password,
                                               ref string EncryptedPassword,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iSSSCCIEncryptPasswordWrapExt = new SSSCCIEncryptPasswordWrapFactory().Create(appDb,
                                                                                                  mgInvoker,
                                                                                                  new CSI.Data.SQL.SQLParameterProvider(),
                                                                                                  true);

                var result = iSSSCCIEncryptPasswordWrapExt.SSSCCIEncryptPasswordWrapSp(Password,
                                                                                       EncryptedPassword,
                                                                                       Infobar);

                EncryptedPassword = result.EncryptedPassword;
                Infobar = result.Infobar;

                return result.ReturnCode.Value;
            }
        }

        //[IDOMethod(MethodFlags.None, "Infobar")]
        //public int SSSCCIEncryptPasswordWrapSp(string Password,
        //                                       ref string EncryptedPassword,
        //                                       ref string Infobar)
        //{
        //    using (var MGAppDB = this.CreateAppDB())
        //    {
        //        var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

            //        var iSSSCCIEncryptPasswordWrapExt = new SSSCCIEncryptPasswordWrapFactory().Create(appDb);

            //        PasswordType oEncryptedPassword = EncryptedPassword;
            //        InfobarType oInfobar = Infobar;

            //        int Severity = iSSSCCIEncryptPasswordWrapExt.SSSCCIEncryptPasswordWrapSp(Password,
            //                                                                                 ref oEncryptedPassword,
            //                                                                                 ref oInfobar);

            //        EncryptedPassword = oEncryptedPassword;
            //        Infobar = oInfobar;


            //        return Severity;
            //    }
            //}

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int Portal_SSSCCIParmsInfoSp(string CardSystemId,
		                                    ref string UserName,
		                                    ref string Password,
		                                    ref string PaymentSvr,
		                                    ref byte? AutoPostOpenPayment,
		                                    ref string CardSystem,
		                                    ref byte? PurchaseAuth,
		                                    ref string GatewayVendID,
		                                    ref string DBName,
		                                    ref string ServerName,
		                                    ref string CurrCode,
		                                    ref string GatewayEncryptionKey)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPortal_SSSCCIParmsInfoExt = new Portal_SSSCCIParmsInfoFactory().Create(appDb);
				
				int Severity = iPortal_SSSCCIParmsInfoExt.Portal_SSSCCIParmsInfoSp(CardSystemId,
				                                                                   ref UserName,
				                                                                   ref Password,
				                                                                   ref PaymentSvr,
				                                                                   ref AutoPostOpenPayment,
				                                                                   ref CardSystem,
				                                                                   ref PurchaseAuth,
				                                                                   ref GatewayVendID,
				                                                                   ref DBName,
				                                                                   ref ServerName,
				                                                                   ref CurrCode,
				                                                                   ref GatewayEncryptionKey);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSCCIParmsInfoSp(string CardSystemId,
		                             ref string UserName,
		                             ref string Password,
		                             ref string PaymentSvr,
		                             ref byte? AutoPostOpenPayment,
		                             ref string CardSystem,
		                             ref byte? PurchaseAuth,
		                             ref string GatewayVendID,
		                             ref string DBName,
		                             ref string ServerName,
		                             ref string CurrCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSCCIParmsInfoExt = new SSSCCIParmsInfoFactory().Create(appDb);
				
				int Severity = iSSSCCIParmsInfoExt.SSSCCIParmsInfoSp(CardSystemId,
				                                                     ref UserName,
				                                                     ref Password,
				                                                     ref PaymentSvr,
				                                                     ref AutoPostOpenPayment,
				                                                     ref CardSystem,
				                                                     ref PurchaseAuth,
				                                                     ref GatewayVendID,
				                                                     ref DBName,
				                                                     ref ServerName,
				                                                     ref CurrCode);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSCCIParmsDebugSp(ref int? Debug)
        {
            var iSSSCCIParmsDebugExt = new SSSCCIParmsDebugFactory().Create(this, true);

            var result = iSSSCCIParmsDebugExt.SSSCCIParmsDebugSp(Debug);

            Debug = result.Debug;

            return result.ReturnCode ?? 0;
        }
    }
}

