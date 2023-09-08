//PROJECT NAME: AdaptersExt
//CLASS NAME: SLCurrencies.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Adapters;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Adapters
{
	[IDOExtensionClass("SLCurrencies")]
	public class SLCurrencies : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalcCurrRateExpireDateSp(string pDomCurrCode,
		string pForCurrCode,
		string pEffectiveDate,
		ref DateTime? pExpireDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCalcCurrRateExpireDateExt = new CalcCurrRateExpireDateFactory().Create(appDb);
				
				var result = iCalcCurrRateExpireDateExt.CalcCurrRateExpireDateSp(pDomCurrCode,
				pForCurrCode,
				pEffectiveDate,
				pExpireDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				pExpireDate = result.pExpireDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
