//PROJECT NAME: AdminExt
//CLASS NAME: SLFormActionThresholds.cs

using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.Admin.FormActionThresholdCheck;
using CSI.MG.MGCore;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using CSI.Data.SQL;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLFormActionThresholds")]
    public class SLFormActionThresholds : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FormActionThresholdCheck(string FormName,
                                            string FormAction,
                                            string FilterParmsValue,
                                            ref int? RecordCount,
                                            ref string PromptMsgObj,
                                            ref string PromptMsg,
                                            ref string NotificationMsg,
                                            ref byte? IsExceedPromptThreshold,
                                            ref byte? IsExceedNotificationThreshold)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var mgInvoker = new MGInvoker(this.Context);
                var mgCommandProvider = new MGCommandProvider(MGAppDB);
                var mgParameterProvider = new SQLParameterProvider();
                var mgMessageProvider = new MGMessageProvider(this.GetMessageProvider());
                var userName = new UserName();
                var iCheckFormActionThresholdExt = new FormActionThresholdCheckFactory().Create(appDb, mgInvoker, new CSI.Data.SQL.SQLParameterProvider(), true, mgMessageProvider, userName);

                int Severity = iCheckFormActionThresholdExt.CheckThreshold(FormName,
                                                                    FormAction,
                                                                    FilterParmsValue,
                                                                    IDORuntime.Context.Site,
                                                                    IDORuntime.ConfigurationName,
                                                                    ref RecordCount,
                                                                    ref PromptMsgObj,
                                                                    ref PromptMsg,
                                                                    ref NotificationMsg,
                                                                    ref IsExceedPromptThreshold,
                                                                    ref IsExceedNotificationThreshold);

                return Severity;
            }
        }
 		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FireGenericNotifyToGCSp(string GlobalConstants,
		string Subject,
		[Optional] string Category,
		string Body,
		[Optional] string HTMLBody,
		ref string Infobar)
		{
			var iFireGenericNotifyToGCExt = new FireGenericNotifyToGCFactory().Create(this, true);
			
			var result = iFireGenericNotifyToGCExt.FireGenericNotifyToGCSp(GlobalConstants,
			Subject,
			Category,
			Body,
			HTMLBody,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}
           } 
        }

    

