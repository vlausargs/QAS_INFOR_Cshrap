//PROJECT NAME: AdminExt
//CLASS NAME: SLPortalsDocumentObjectGroupViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Admin
{
	[IDOExtensionClass("SLPortalsDocumentObjectGroupViews")]
	public class SLPortalsDocumentObjectGroupViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DocumentObjectGroupViewSp([Optional] string filterString,
		                                               string IdoFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_DocumentObjectGroupViewExt = new CLM_DocumentObjectGroupViewFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_DocumentObjectGroupViewExt.CLM_DocumentObjectGroupViewSp(filterString,
				                                                                           IdoFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
