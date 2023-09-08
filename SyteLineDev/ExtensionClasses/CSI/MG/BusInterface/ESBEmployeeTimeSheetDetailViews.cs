//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBEmployeeTimeSheetDetailViews.cs

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
	[IDOExtensionClass("ESBEmployeeTimeSheetDetailViews")]
	public class ESBEmployeeTimeSheetDetailViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBEmployeeTimeSheetDetailSp(string DerBODID,
		string ActionExpression,
		string EmployeeID,
		DateTime? TransactionDate,
		string ReferenceID,
		string Prefix,
		string Duration,
		string Status,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBEmployeeTimeSheetDetailExt = new LoadESBEmployeeTimeSheetDetailFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBEmployeeTimeSheetDetailExt.LoadESBEmployeeTimeSheetDetailSp(DerBODID,
				ActionExpression,
				EmployeeID,
				TransactionDate,
				ReferenceID,
				Prefix,
				Duration,
				Status,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
