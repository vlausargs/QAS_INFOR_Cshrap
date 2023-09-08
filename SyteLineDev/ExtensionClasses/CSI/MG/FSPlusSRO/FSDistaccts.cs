//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSDistaccts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSDistaccts")]
    public class FSDistaccts : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSDistDefsSp(ref int? AmortizeContracts,
            ref int? TotalPeriods,
            ref string Infobar)
        {
            var iSSSFSDistDefsExt = new SSSFSDistDefsFactory().Create(this, true);

            var result = iSSSFSDistDefsExt.SSSFSDistDefsSp(AmortizeContracts,
                TotalPeriods,
                Infobar);

            AmortizeContracts = result.AmortizeContracts;
            TotalPeriods = result.TotalPeriods;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }
    }
}
