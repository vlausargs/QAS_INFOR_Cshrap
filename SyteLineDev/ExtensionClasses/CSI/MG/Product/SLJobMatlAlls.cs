//PROJECT NAME: ProductExt
//CLASS NAME: SLJobMatlAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
	[IDOExtensionClass("SLJobMatlAlls")]
	public class SLJobMatlAlls : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_JobMatlOverUnderSp([Optional] DateTime? CompletedDate,
		[Optional, DefaultParameterValue("%")] string PlanCode,
		[Optional] string FilterString,
		string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_JobMatlOverUnderExt = new CLM_JobMatlOverUnderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_JobMatlOverUnderExt.CLM_JobMatlOverUnderSp(CompletedDate,
				PlanCode,
				FilterString,
				SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
