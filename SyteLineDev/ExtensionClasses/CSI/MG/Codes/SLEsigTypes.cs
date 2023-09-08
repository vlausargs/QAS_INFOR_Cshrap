//PROJECT NAME: CodesExt
//CLASS NAME: SLEsigTypes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLEsigTypes")]
	public class SLEsigTypes : CSIExtensionClassBase, IExtFTSLEsigTypes
	{
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetDataForEsigTypeSp(string EsigType,
            ref string Description,
            ref int? Enabled)
        {
            var iGetDataForEsigTypeExt = new GetDataForEsigTypeFactory().Create(this, true);

            var result = iGetDataForEsigTypeExt.GetDataForEsigTypeSp(EsigType,
                Description,
                Enabled);

            Description = result.Description;
            Enabled = result.Enabled;

            return result.ReturnCode ?? 0;
        }
    }
}
