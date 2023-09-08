//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBExpenseReportHeaderViews.cs

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
	[IDOExtensionClass("ESBExpenseReportHeaderViews")]
	public class ESBExpenseReportHeaderViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadSyncExpenseSp(string EmpNum,
		                             string StatusCode,
		                             decimal? Amount,
		                             string DocumentID,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadSyncExpenseExt = new LoadSyncExpenseFactory().Create(appDb);
				
				int Severity = iLoadSyncExpenseExt.LoadSyncExpenseSp(EmpNum,
				                                                     StatusCode,
				                                                     Amount,
				                                                     DocumentID,
				                                                     ref Infobar);
				
				return Severity;
			}
		}
	}
}
