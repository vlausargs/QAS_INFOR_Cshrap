//PROJECT NAME: VendorExt
//CLASS NAME: SLEdiVinvs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLEdiVinvs")]
	public class SLEdiVinvs : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeEDIVendorInvoicesSp([Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string PoStarting,
		[Optional] string PoEnding,
		[Optional] DateTime? CDateStarting,
		[Optional] DateTime? CDateEnding,
		[Optional] string ExOptprPostedEmp,
		[Optional] int? CDateStartingOffset,
		[Optional] int? CDateEndingOffset,
		[Optional] ref string Message)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPurgeEDIVendorInvoicesExt = new PurgeEDIVendorInvoicesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPurgeEDIVendorInvoicesExt.PurgeEDIVendorInvoicesSp(VendorStarting,
				VendorEnding,
				PoStarting,
				PoEnding,
				CDateStarting,
				CDateEnding,
				ExOptprPostedEmp,
				CDateStartingOffset,
				CDateEndingOffset,
				Message);
				
				int Severity = result.ReturnCode.Value;
				Message = result.Message;
				return Severity;
			}
		}
	}
}
