//PROJECT NAME: VendorExt
//CLASS NAME: SLVchStaxs.cs

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
	[IDOExtensionClass("SLVchStaxs")]
	public class SLVchStaxs : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TaxPayableSp(DateTime? PDistDateStarting,
		DateTime? PDistDateEnding,
		string PTaxCodeStarting,
		string PTaxCodeEnding,
		string PVendorStarting,
		string PVendorEnding,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TaxPayableExt = new Rpt_TaxPayableFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TaxPayableExt.Rpt_TaxPayableSp(PDistDateStarting,
				PDistDateEnding,
				PTaxCodeStarting,
				PTaxCodeEnding,
				PVendorStarting,
				PVendorEnding,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
