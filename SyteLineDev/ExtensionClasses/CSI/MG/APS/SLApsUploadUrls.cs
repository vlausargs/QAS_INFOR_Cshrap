//PROJECT NAME: APSExt
//CLASS NAME: SLApsUploadUrls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLApsUploadUrls")]
    public class SLApsUploadUrls : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsSupportFilesPrepSp(string Prefix, string UploadURL)
        {
            var iApsSupportFilesPrepExt = new ApsSupportFilesPrepFactory().Create(this, true);

            var result = iApsSupportFilesPrepExt.ApsSupportFilesPrepSp(Prefix, UploadURL);

            return result ?? 0;
        }
    }
}
