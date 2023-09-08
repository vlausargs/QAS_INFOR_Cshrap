//PROJECT NAME: CustomerExt
//CLASS NAME: SLSalesPeriods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Material;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLSalesPeriods")]
	public class SLSalesPeriods : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSalesPeriodStartDateSp(ref string StartDate, ref string Infobar)
		{
			var iGetSalesPeriodStartDateExt = new GetSalesPeriodStartDateFactory().Create(this, true);

			var result = iGetSalesPeriodStartDateExt.GetSalesPeriodStartDateSp(StartDate, Infobar);

			StartDate = result.StartDate;
			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AccountingPeriodToSalesPeriodSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAccountingPeriodToSalesPeriodExt = new AccountingPeriodToSalesPeriodFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAccountingPeriodToSalesPeriodExt.AccountingPeriodToSalesPeriodSp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
