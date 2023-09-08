//PROJECT NAME: CustomerExt
//CLASS NAME: SLInvoiceBuilders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
//using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLInvoiceBuilders")]
	public class SLInvoiceBuilders : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LoadInvoiceBuilderHeadSp(string PCustNum,
		                                              string FormType,
		                                              byte? NonDraftCust,
		                                              [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_LoadInvoiceBuilderHeadExt = new CLM_LoadInvoiceBuilderHeadFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_LoadInvoiceBuilderHeadExt.CLM_LoadInvoiceBuilderHeadSp(PCustNum,
				                                                                         FormType,
				                                                                         NonDraftCust,
				                                                                         FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable TableSharedSitesSp(string TableName)
		{
			var iTableSharedSitesExt = new TableSharedSitesFactory().Create(this, true);
			
			var result = iTableSharedSitesExt.TableSharedSitesSp(TableName);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable VendorSharedSitesSp([Optional] string SiteFilter)
		{
			var iVendorSharedSitesExt = new VendorSharedSitesFactory().Create(this, true);
			
			var result = iVendorSharedSitesExt.VendorSharedSitesSp(SiteFilter);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

	}
}
