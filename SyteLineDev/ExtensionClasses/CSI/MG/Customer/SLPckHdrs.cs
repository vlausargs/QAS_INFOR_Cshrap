//PROJECT NAME: CustomerExt
//CLASS NAME: SLPckHdrs.cs

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
	[IDOExtensionClass("SLPckHdrs")]
	public class SLPckHdrs : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileReprintPackingSlipSp([Optional] int? PStartSlipNum,
		                                             [Optional] int? PEndSlipNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfileReprintPackingSlipExt = new ProfileReprintPackingSlipFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfileReprintPackingSlipExt.ProfileReprintPackingSlipSp(PStartSlipNum,
				                                                                       PEndSlipNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PurgePackingSlipRegisterSp(int? SPackNum,
		int? EPackNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPurgePackingSlipRegisterExt = new PurgePackingSlipRegisterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPurgePackingSlipRegisterExt.PurgePackingSlipRegisterSp(SPackNum,
				EPackNum,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
