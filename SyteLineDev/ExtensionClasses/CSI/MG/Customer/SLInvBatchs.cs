//PROJECT NAME: CustomerExt
//CLASS NAME: SLInvBatchs.cs

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
	[IDOExtensionClass("SLInvBatchs")]
	public class SLInvBatchs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateInvoiceBatchSp(DateTime? CloseDate,
		                                  [Optional, DefaultParameterValue((byte)0)] byte? ExcludeInvoicesOnClosingDate,
		[Optional, DefaultParameterValue((byte)0)] byte? OverrideInvBatchCreateRules,
		[Optional] string Description,
		[Optional] string StartCustNum,
		[Optional] string EndCustNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGenerateInvoiceBatchExt = new GenerateInvoiceBatchFactory().Create(appDb);
				
				var result = iGenerateInvoiceBatchExt.GenerateInvoiceBatchSp(CloseDate,
				                                                             ExcludeInvoicesOnClosingDate,
				                                                             OverrideInvBatchCreateRules,
				                                                             Description,
				                                                             StartCustNum,
				                                                             EndCustNum,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
