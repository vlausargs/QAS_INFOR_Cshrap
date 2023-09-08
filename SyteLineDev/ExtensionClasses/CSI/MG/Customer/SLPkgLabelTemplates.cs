//PROJECT NAME: CustomerExt
//CLASS NAME: SLPkgLabelTemplates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLPkgLabelTemplates")]
	public class SLPkgLabelTemplates : CSIExtensionClassBase
	{
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetLabelFilenameSp(string TemplateName,
            ref string Filename)
        {
            var iGetLabelFilenameExt = new GetLabelFilenameFactory().Create(this, true);

            var result = iGetLabelFilenameExt.GetLabelFilenameSp(TemplateName,
                Filename);

            Filename = result.Filename;

            return result.ReturnCode ?? 0;
        }
    }
}
