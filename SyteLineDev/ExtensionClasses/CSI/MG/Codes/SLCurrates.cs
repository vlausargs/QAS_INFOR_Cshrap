//PROJECT NAME: CodesExt
//CLASS NAME: SLCurrates.cs

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
	[IDOExtensionClass("SLCurrates")]
	public class SLCurrates : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCustomerSellRateSp(string DomesticCurrCode,
		string CustomerCurrCode,
		ref decimal? SellRate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetCustomerSellRateExt = new GetCustomerSellRateFactory().Create(appDb);
				
				var result = iGetCustomerSellRateExt.GetCustomerSellRateSp(DomesticCurrCode,
				CustomerCurrCode,
				SellRate);
				
				int Severity = result.ReturnCode.Value;
				SellRate = result.SellRate;
				return Severity;
			}
		}
	}
}
