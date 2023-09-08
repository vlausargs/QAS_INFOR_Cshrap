//PROJECT NAME: CodesExt
//CLASS NAME: SLUserNames.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("SLUserNames")]
    public class SLUserNames : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckAndAddUserLocalSp()
        {
            var iCheckAndAddUserLocalExt = new CheckAndAddUserLocalFactory().Create(this, true);

            var result = iCheckAndAddUserLocalExt.CheckAndAddUserLocalSp();

            return result ?? 0;
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
		public int AlertNotifyTaskBODDistributionPersonIdSp(string Username, ref string DistributionPersonId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAlertNotifyTaskBODDistributionPersonIdExt = new AlertNotifyTaskBODDistributionPersonIdFactory().Create(appDb,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);
				
				var result = iAlertNotifyTaskBODDistributionPersonIdExt.AlertNotifyTaskBODDistributionPersonIdSp(Username, DistributionPersonId);
				
				int Severity = result.ReturnCode.Value;
				DistributionPersonId = result.DistributionPersonId;
				return Severity;
			}
		}
    }
}
