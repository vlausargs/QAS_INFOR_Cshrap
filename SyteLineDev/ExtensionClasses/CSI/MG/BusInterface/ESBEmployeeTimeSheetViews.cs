//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBEmployeeTimeSheetViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBEmployeeTimeSheetViews")]
	public class ESBEmployeeTimeSheetViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBEmployeeTimesheetSp([Optional] string DerBODID,
		[Optional] string ActionExpression)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBEmployeeTimesheetExt = new LoadESBEmployeeTimesheetFactory().Create(appDb);
				
				var result = iLoadESBEmployeeTimesheetExt.LoadESBEmployeeTimesheetSp(DerBODID,
				ActionExpression);
				
				
				return result.Value;
			}
		}
	}
}
