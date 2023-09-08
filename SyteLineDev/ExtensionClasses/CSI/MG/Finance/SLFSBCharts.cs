//PROJECT NAME: FinanceExt
//CLASS NAME: SLFSBCharts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFSBCharts")]
    public class SLFSBCharts : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MultiFSBCopyCOAtoMultiCOASp([Optional] string FSBChartofAccount,
		                                       [Optional] string AccountTypes,
		                                       [Optional] string AccountStarting,
		                                       [Optional] string AccountEnding,
		                                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMultiFSBCopyCOAtoMultiCOAExt = new MultiFSBCopyCOAtoMultiCOAFactory().Create(appDb);
				
				var result = iMultiFSBCopyCOAtoMultiCOAExt.MultiFSBCopyCOAtoMultiCOASp(FSBChartofAccount,
				                                                                       AccountTypes,
				                                                                       AccountStarting,
				                                                                       AccountEnding,
				                                                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
