//PROJECT NAME: VendorExt
//CLASS NAME: SLGrnLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.DataCollection;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLGrnLines")]
	public class SLGrnLines : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GrnLineGetQtyShippedSp(string PPoNum,
		                                  short? PPoLine,
		                                  short? PPoRelease,
		                                  ref decimal? PShippedQty,
		                                  ref string PUM,
		                                  ref string PPoType,
		                                  ref string PItem,
		                                  ref string PItemDesc,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGrnLineGetQtyShippedExt = new GrnLineGetQtyShippedFactory().Create(appDb);
				
				int Severity = iGrnLineGetQtyShippedExt.GrnLineGetQtyShippedSp(PPoNum,
				                                                               PPoLine,
				                                                               PPoRelease,
				                                                               ref PShippedQty,
				                                                               ref PUM,
				                                                               ref PPoType,
				                                                               ref PItem,
				                                                               ref PItemDesc,
				                                                               ref Infobar);
				
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoitemInfoSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		ref string OutItem,
		ref string OutItemDesc,
		ref string OutUM,
		ref decimal? QtyShipped)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoitemInfoExt = new PoitemInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoitemInfoExt.PoitemInfoSp(PoNum,
				PoLine,
				PoRelease,
				OutItem,
				OutItemDesc,
				OutUM,
				QtyShipped);
				
				int Severity = result.ReturnCode.Value;
				OutItem = result.OutItem;
				OutItemDesc = result.OutItemDesc;
				OutUM = result.OutUM;
				QtyShipped = result.QtyShipped;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoNumValidSp(string PoNum,
		ref string OutType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoNumValidExt = new PoNumValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoNumValidExt.PoNumValidSp(PoNum,
				OutType);
				
				int Severity = result.ReturnCode.Value;
				OutType = result.OutType;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetumcfSp(string OtherUM,
		string Item,
		string VendNum,
		string Area,
		ref decimal? ConvFactor,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetumcfExt = new GetumcfFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetumcfExt.GetumcfSp(OtherUM,
				Item,
				VendNum,
				Area,
				ConvFactor,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				ConvFactor = result.ConvFactor;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
