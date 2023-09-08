//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBSupplierInvoiceViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBSupplierInvoiceViews")]
	public class ESBSupplierInvoiceViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBSupplierInvoiceHeaderSp([Optional] string ActionExpression,
		[Optional] string SupplierInvoice,
		[Optional] string VendNum,
		[Optional] decimal? PreSubunitRoundedTotalAmount,
		[Optional] decimal? SubunitRoundingAmount,
		[Optional] string SubunitRoundingCurrCode,
		[Optional] DateTime? InvDate,
		[Optional] DateTime? DueDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBSupplierInvoiceHeaderExt = new LoadESBSupplierInvoiceHeaderFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBSupplierInvoiceHeaderExt.LoadESBSupplierInvoiceHeaderSp(ActionExpression,
				SupplierInvoice,
				VendNum,
				PreSubunitRoundedTotalAmount,
				SubunitRoundingAmount,
				SubunitRoundingCurrCode,
				InvDate,
				DueDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
