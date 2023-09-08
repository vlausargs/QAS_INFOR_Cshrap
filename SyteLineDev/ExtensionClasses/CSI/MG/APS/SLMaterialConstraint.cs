//PROJECT NAME: APSExt
//CLASS NAME: SLMaterialConstraint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
	[IDOExtensionClass("SLMaterialConstraint")]
	public class SLMaterialConstraint : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ItemBottlenecksMRPAPSSp([Optional] DateTime? DateStarting,
		[Optional] DateTime? DateEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] int? ShowTop,
		[Optional] string PlannerCodeStarting,
		[Optional] string PlannerCodeEnding,
		[Optional] string SourceType,
		[Optional] byte? ListDelayedDemands,
		[Optional] string NotebookTab,
		[Optional] string Period,
		[Optional] int? Interval)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ItemBottlenecksMRPAPSExt = new CLM_ItemBottlenecksMRPAPSFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ItemBottlenecksMRPAPSExt.CLM_ItemBottlenecksMRPAPSSp(DateStarting,
				DateEnding,
				ItemStarting,
				ItemEnding,
				ShowTop,
				PlannerCodeStarting,
				PlannerCodeEnding,
				SourceType,
				ListDelayedDemands,
				NotebookTab,
				Period,
				Interval);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ItemBottlenecksMRPAPSSpForBucketed([Optional] DateTime? DateStarting,
		[Optional] DateTime? DateEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] int? ShowTop,
		[Optional] string PlannerCodeStarting,
		[Optional] string PlannerCodeEnding,
		[Optional] string SourceType,
		[Optional] byte? ListDelayedDemands,
		[Optional] string NotebookTab,
		[Optional] string Period,
		[Optional] int? Interval)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ItemBottlenecksMRPAPSExt = new CLM_ItemBottlenecksMRPAPSFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ItemBottlenecksMRPAPSExt.CLM_ItemBottlenecksMRPAPSSp(DateStarting,
				DateEnding,
				ItemStarting,
				ItemEnding,
				ShowTop,
				PlannerCodeStarting,
				PlannerCodeEnding,
				SourceType,
				ListDelayedDemands,
				NotebookTab,
				Period,
				Interval);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
