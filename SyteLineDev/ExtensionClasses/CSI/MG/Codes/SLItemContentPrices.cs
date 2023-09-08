//PROJECT NAME: CodesExt
//CLASS NAME: SLItemContentPrices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("SLItemContentPrices")]
    public class SLItemContentPrices : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetParmsTimeZone(ref string ParmsTimeZone)
		{
			var iGetParmsTimeZoneExt = new GetParmsTimeZoneFactory().Create(this, true);

			var result = iGetParmsTimeZoneExt.GetParmsTimeZoneSP(ParmsTimeZone);

			ParmsTimeZone = result.ParmsTimeZone;

			return result.ReturnCode ?? 0;
		}
	}
}
