//PROJECT NAME: CodesExt
//CLASS NAME: SLISOCountries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLISOCountries")]
	public class SLISOCountries : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetISOCountryInfoSp(string ISOCountry, [Optional] ref string ISOCountryCode)
		{
			var iGetISOCountryInfoExt = new GetISOCountryInfoFactory().Create(this, true);

			var result = iGetISOCountryInfoExt.GetISOCountryInfoSp(ISOCountry, ISOCountryCode);

			ISOCountryCode = result.ISOCountryCode;

			return result.ReturnCode ?? 0;
		}
	}
}
