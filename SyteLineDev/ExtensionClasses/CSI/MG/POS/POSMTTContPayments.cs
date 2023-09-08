//PROJECT NAME: POSExt
//CLASS NAME: POSMTTContPayments.cs

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
    [IDOExtensionClass("POSMTTContPayments")]
    public class POSMTTContPayments : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSPOSConPostInvSp(string pContract,
                                      DateTime? pBilledThruDateTime,
                                      DateTime? pBilledThruDate,
                                      Guid? PSessionID,
                                      string pContractStatus,
                                      string pUserName,
                                      decimal? pUserID,
                                      string pPartnerID,
                                      string pDrawer,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSPOSConPostInvExt = new SSSPOSConPostInvFactory().Create(appDb);

                int Severity = iSSSPOSConPostInvExt.SSSPOSConPostInvSp(pContract,
                                                                       pBilledThruDateTime,
                                                                       pBilledThruDate,
                                                                       PSessionID,
                                                                       pContractStatus,
                                                                       pUserName,
                                                                       pUserID,
                                                                       pPartnerID,
                                                                       pDrawer,
                                                                       ref Infobar);

                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSPOSConPosPSp([Optional] Guid? SessionId,
		[Optional] string RequestingUser,
		decimal? UserID,
		[Optional, DefaultParameterValue("POSCheckoutCheckin")] string CalledFromForm,
		string PartnerId,
		string Drawer,
		string Contract,
		DateTime? BilledThruDate,
		string InvNum,
		int? InvSeq,
		string InvCred,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSPOSConPosPExt = new SSSPOSConPosPFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSPOSConPosPExt.SSSPOSConPosPSp(SessionId,
				RequestingUser,
				UserID,
				CalledFromForm,
				PartnerId,
				Drawer,
				Contract,
				BilledThruDate,
				InvNum,
				InvSeq,
				InvCred,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
