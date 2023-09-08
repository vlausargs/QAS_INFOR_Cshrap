//PROJECT NAME: APSExt
//CLASS NAME: SchedulerRptParameters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SchedulerRptParameters")]
    public class SchedulerRptParameters : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetRepparParms(ref decimal? LateThreshold,
		                          ref decimal? BotnkUtilThresh)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetRepparParmsExt = new GetRepparParmsFactory().Create(appDb);
				
				var result = iGetRepparParmsExt.GetRepparParmsSp(LateThreshold,
				                                                 BotnkUtilThresh);
				
				int Severity = result.ReturnCode.Value;
				LateThreshold = result.LateThreshold;
				BotnkUtilThresh = result.BotnkUtilThresh;
				return Severity;
			}
		}
    }
}
