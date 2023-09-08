//PROJECT NAME: CustomerExt
//CLASS NAME: SLProgbills.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLProgbills")]
	public class SLProgbills : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalcProgBillAmtByPctSp(string CoNum,
		int? CoLine,
		int? Percent,
		ref decimal? BillAmount,
		ref decimal? CoitemPrice,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCalcProgBillAmtByPctExt = new CalcProgBillAmtByPctFactory().Create(appDb);
				
				var result = iCalcProgBillAmtByPctExt.CalcProgBillAmtByPctSp(CoNum,
				CoLine,
				Percent,
				BillAmount,
				CoitemPrice,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				BillAmount = result.BillAmount;
				CoitemPrice = result.CoitemPrice;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
