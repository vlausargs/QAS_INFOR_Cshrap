//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBExpenseReportLineDetailViews.cs

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
	[IDOExtensionClass("ESBExpenseReportLineDetailViews")]
	public class ESBExpenseReportLineDetailViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBExpenseReportLineDetailSp(string DerBODID,
		                                            string EmployeeID,
		                                            decimal? BaseAmount,
		                                            string ProjectReference,
		                                            string CurrCode,
		                                            string CostCenterCode,
		                                            string PersonalIndicator,
		                                            string ItemizedIndicator,
		                                            string ExpenseType,
		                                            string SpecialCode,
		                                            string PaymentType,
		                                            string PaymentMethod,
		                                            string LineNumber,
		                                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBExpenseReportLineDetailExt = new LoadESBExpenseReportLineDetailFactory().Create(appDb);
				
				int Severity = iLoadESBExpenseReportLineDetailExt.LoadESBExpenseReportLineDetailSp(DerBODID,
				                                                                                   EmployeeID,
				                                                                                   BaseAmount,
				                                                                                   ProjectReference,
				                                                                                   CurrCode,
				                                                                                   CostCenterCode,
				                                                                                   PersonalIndicator,
				                                                                                   ItemizedIndicator,
				                                                                                   ExpenseType,
				                                                                                   SpecialCode,
				                                                                                   PaymentType,
				                                                                                   PaymentMethod,
				                                                                                   LineNumber,
				                                                                                   ref Infobar);
				
				return Severity;
			}
		}
	}
}
