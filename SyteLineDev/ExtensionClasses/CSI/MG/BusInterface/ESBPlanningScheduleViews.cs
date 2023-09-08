//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBPlanningScheduleViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBPlanningScheduleViews")]
	public class ESBPlanningScheduleViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBPlanningSchedulePostSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBPlanningSchedulePostExt = new LoadESBPlanningSchedulePostFactory().Create(appDb);
				
				int Severity = iLoadESBPlanningSchedulePostExt.LoadESBPlanningSchedulePostSp(ref Infobar);
				
				return Severity;
			}
		}
	}
}
