//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBEmployeeWorkScheduleViews.cs

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
	[IDOExtensionClass("ESBEmployeeWorkScheduleViews")]
	public class ESBEmployeeWorkScheduleViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBEmployeeWorkScheduleSp([Optional] string ActionExpression,
		[Optional] string DocumentID,
		[Optional] string EmpNum,
		DateTime? LeaveStartDate,
		string LeaveDuration,
		DateTime? LeaveEndDate,
		string AbsenceType,
		string Status,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBEmployeeWorkScheduleExt = new LoadESBEmployeeWorkScheduleFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBEmployeeWorkScheduleExt.LoadESBEmployeeWorkScheduleSp(ActionExpression,
				DocumentID,
				EmpNum,
				LeaveStartDate,
				LeaveDuration,
				LeaveEndDate,
				AbsenceType,
				Status,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
