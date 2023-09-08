//PROJECT NAME: FinanceExt
//CLASS NAME: SLChartDs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Finance
{
	[IDOExtensionClass("SLChartDs")]
    public class SLChartDs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AcctRecursiveTestSp(string PAcct,
        string PDAcct,
        [Optional, DefaultParameterValue(0)] int? NESTLEVEL)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iAcctRecursiveTestExt = new AcctRecursiveTestFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iAcctRecursiveTestExt.AcctRecursiveTestSp(PAcct,
                PDAcct,
                NESTLEVEL);

                int Severity = result == null ? 0 : (int)result; ;
                return Severity;
            }
        }
    }
}
