//PROJECT NAME: FinanceExt
//CLASS NAME: SLFsbChartCharts.cs

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
    [IDOExtensionClass("SLFsbChartCharts")]
    public class SLFsbChartCharts : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidChartAllocationSp(string PAcctNum,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFsbChartChartsExt = new ValidChartAllocationFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLFsbChartChartsExt.ValidChartAllocationSp(PAcctNum,
                                                                           ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
