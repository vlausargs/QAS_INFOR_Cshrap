//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBExpenseReportLineViews.cs

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
	[IDOExtensionClass("ESBExpenseReportLineViews")]
	public class ESBExpenseReportLineViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBExpenseReportLinePostSp(string DocumentID,
		                                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBExpenseReportLinePostExt = new LoadESBExpenseReportLinePostFactory().Create(appDb);
				
				int Severity = iLoadESBExpenseReportLinePostExt.LoadESBExpenseReportLinePostSp(DocumentID,
				                                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBExpenseReportLineSp(string DerBODID,
		                                      string EmployeeID,
		                                      string ApproveStatus,
		                                      string LineNumber,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBExpenseReportLineExt = new LoadESBExpenseReportLineFactory().Create(appDb);
				
				int Severity = iLoadESBExpenseReportLineExt.LoadESBExpenseReportLineSp(DerBODID,
				                                                                       EmployeeID,
				                                                                       ApproveStatus,
				                                                                       LineNumber,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}
	}
}
