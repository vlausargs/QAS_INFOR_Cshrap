//PROJECT NAME: MG
//CLASS NAME: TaxDebugs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.TaxInterface;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.TaxInterface
{
    [IDOExtensionClass("TaxDebugs")]
    public class TaxDebugs : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSVTXDeleteDebugSp()
        {
            var iSSSVTXDeleteDebugExt = new SSSVTXDeleteDebugFactory().Create(this, true);

            var result = iSSSVTXDeleteDebugExt.SSSVTXDeleteDebugSp();


            return result ?? 0;
        }
    }
}
