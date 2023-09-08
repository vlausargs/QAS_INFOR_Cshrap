//PROJECT NAME: VendorExt
//CLASS NAME: SLCommodities.cs

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
	[IDOExtensionClass("SLCommodities")]
	public class SLCommodities : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CARaSCommodityCodeExtractionSp(string StartCommCode,
		                                                string EndCommCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCARaSCommodityCodeExtractionExt = new CARaSCommodityCodeExtractionFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCARaSCommodityCodeExtractionExt.CARaSCommodityCodeExtractionSp(StartCommCode,
				                                                                               EndCommCode);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSupplQtyConvFactorSp(string comm_code,
		                                   ref double? suppl_qty_conv_factor,
		                                   ref byte? suppl_qty_req,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetSupplQtyConvFactorExt = new GetSupplQtyConvFactorFactory().Create(appDb);
				
				int Severity = iGetSupplQtyConvFactorExt.GetSupplQtyConvFactorSp(comm_code,
				                                                                 ref suppl_qty_conv_factor,
				                                                                 ref suppl_qty_req,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SupplUnitsConvFactorUpdateSp(string BegCommCode,
		string EndCommCode,
		int? UpdCoitem,
		int? UpdPoitem,
		int? UpdTrnitem,
		int? UpdRmaitem,
		int? UpdProjmatl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSupplUnitsConvFactorUpdateExt = new SupplUnitsConvFactorUpdateFactory().Create(appDb);
				
				var result = iSupplUnitsConvFactorUpdateExt.SupplUnitsConvFactorUpdateSp(BegCommCode,
				EndCommCode,
				UpdCoitem,
				UpdPoitem,
				UpdTrnitem,
				UpdRmaitem,
				UpdProjmatl);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
