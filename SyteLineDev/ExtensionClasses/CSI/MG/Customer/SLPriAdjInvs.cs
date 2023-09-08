//PROJECT NAME: CustomerExt
//CLASS NAME: SLPriAdjInvs.cs

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
	[IDOExtensionClass("SLPriAdjInvs")]
	public class SLPriAdjInvs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CoPriceIncludeTaxSp(string CoNum,
		                               ref byte? CoIncludePrice)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCoPriceIncludeTaxExt = new CoPriceIncludeTaxFactory().Create(appDb);
				
				int Severity = iCoPriceIncludeTaxExt.CoPriceIncludeTaxSp(CoNum,
				                                                         ref CoIncludePrice);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PriceAdjCheckSp(string CONum,
		                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPriceAdjCheckExt = new PriceAdjCheckFactory().Create(appDb);
				
				int Severity = iPriceAdjCheckExt.PriceAdjCheckSp(CONum,
				                                                 ref Infobar);
				
				return Severity;
			}
		}
	}
}
