//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBPlanningScheduleLinesViews.cs

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
	[IDOExtensionClass("ESBPlanningScheduleLinesViews")]
	public class ESBPlanningScheduleLinesViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBPlanningScheduleLinesSp(string ActionExpression,
		                                          string CustNum,
		                                          string CoNumSeq,
		                                          string CobCoStatus,
		                                          short? CoLine,
		                                          string CoLineStatus,
		                                          string ShipmentLineID,
		                                          string BucketType,
		                                          DateTime? StartDate,
		                                          DateTime? EndDate,
		                                          decimal? ItemQuantity,
		                                          string ISOUM,
		                                          string PlanTypeCode,
		                                          string UsageType,
		                                          string PlanningRevisionID,
		                                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBPlanningScheduleLinesExt = new LoadESBPlanningScheduleLinesFactory().Create(appDb);
				
				int Severity = iLoadESBPlanningScheduleLinesExt.LoadESBPlanningScheduleLinesSp(ActionExpression,
				                                                                               CustNum,
				                                                                               CoNumSeq,
				                                                                               CobCoStatus,
				                                                                               CoLine,
				                                                                               CoLineStatus,
				                                                                               ShipmentLineID,
				                                                                               BucketType,
				                                                                               StartDate,
				                                                                               EndDate,
				                                                                               ItemQuantity,
				                                                                               ISOUM,
				                                                                               PlanTypeCode,
				                                                                               UsageType,
				                                                                               PlanningRevisionID,
				                                                                               ref Infobar);
				
				return Severity;
			}
		}
	}
}
