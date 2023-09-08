//PROJECT NAME: CodesExt
//CLASS NAME: SLSitesSelection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLSitesSelection")]
	public class SLSitesSelection : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetSiteSelectionSp([Optional] string FilterGroupSelection,
		[Optional] string FilterUnClickSite,
		[Optional] string FilterDeleteSite,
		[Optional] string FilterIntranetName,
		[Optional] string FilterSourceSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetSiteSelectionExt = new CLM_GetSiteSelectionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetSiteSelectionExt.CLM_GetSiteSelectionSp(FilterGroupSelection,
				FilterUnClickSite,
				FilterDeleteSite,
				FilterIntranetName,
				FilterSourceSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
