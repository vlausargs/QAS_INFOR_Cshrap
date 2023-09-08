//PROJECT NAME: POSExt
//CLASS NAME: POSMDrawers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.POS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.POS
{
    [IDOExtensionClass("POSMDrawers")]
    public class POSMDrawers : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSPOSEndOfDayProcessingSp([Optional] string CashDrawer,
		                                      [Optional] DateTime? AdjustmentPostingDate,
		                                      [Optional, DefaultParameterValue(0)] decimal? EndingCashBalance,
		[Optional, DefaultParameterValue(0)] decimal? EndingCheckBalance,
		byte? CheckInBalance,
		byte? CheckInNotBalance,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSPOSEndOfDayProcessingExt = new SSSPOSEndOfDayProcessingFactory().Create(appDb);
				
				var result = iSSSPOSEndOfDayProcessingExt.SSSPOSEndOfDayProcessingSp(CashDrawer,
				                                                                     AdjustmentPostingDate,
				                                                                     EndingCashBalance,
				                                                                     EndingCheckBalance,
				                                                                     CheckInBalance,
				                                                                     CheckInNotBalance,
				                                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
