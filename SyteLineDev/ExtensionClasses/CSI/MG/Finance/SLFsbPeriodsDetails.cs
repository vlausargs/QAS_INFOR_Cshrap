//PROJECT NAME: FinanceExt
//CLASS NAME: SLFsbPeriodsDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
	[IDOExtensionClass("SLFsbPeriodsDetails")]
	public class SLFsbPeriodsDetails : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateFsbPeriodsSp(int? FiscalYear,
		string PeriodName,
		int? StepMonths)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGenerateFsbPeriodsExt = new GenerateFsbPeriodsFactory().Create(appDb);
				
				var result = iGenerateFsbPeriodsExt.GenerateFsbPeriodsSp(FiscalYear,
				PeriodName,
				StepMonths);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
