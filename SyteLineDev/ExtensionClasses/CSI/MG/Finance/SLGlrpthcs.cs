//PROJECT NAME: FinanceExt
//CLASS NAME: SLGlrpthcs.cs

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
	[IDOExtensionClass("SLGlrpthcs")]
	public class SLGlrpthcs : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PeriodsGetDatesSp(int? FiscalYear,
		int? Period,
		[Optional] string Site,
		ref DateTime? PerStart,
		ref DateTime? PerEnd,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPeriodsGetDatesExt = new PeriodsGetDatesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPeriodsGetDatesExt.PeriodsGetDatesSp(FiscalYear,
				Period,
				Site,
				PerStart,
				PerEnd,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PerStart = result.PerStart;
				PerEnd = result.PerEnd;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
