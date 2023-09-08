//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjcostdetailAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjcostdetailAlls")]
	public class SLProjcostdetailAlls : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ProjectJobAccumulatedByPeriodSp(string ProjNum,
		                                                     int? StartTaskNum,
		                                                     int? EndTaskNum,
		                                                     string StartCostCode,
		                                                     string EndCostCode,
		                                                     string StartYear,
		                                                     string StartMonth,
		                                                     int? NumberMonths,
		                                                     string CostCodeType,
		                                                     string ProjLevel,
		                                                     string MatlCostClass,
		                                                     string LaborCostClass,
		                                                     string OtherCostClass,
		                                                     [Optional] string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ProjectJobAccumulatedByPeriodExt = new CLM_ProjectJobAccumulatedByPeriodFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ProjectJobAccumulatedByPeriodExt.CLM_ProjectJobAccumulatedByPeriodSp(ProjNum,
				                                                                                       StartTaskNum,
				                                                                                       EndTaskNum,
				                                                                                       StartCostCode,
				                                                                                       EndCostCode,
				                                                                                       StartYear,
				                                                                                       StartMonth,
				                                                                                       NumberMonths,
				                                                                                       CostCodeType,
				                                                                                       ProjLevel,
				                                                                                       MatlCostClass,
				                                                                                       LaborCostClass,
				                                                                                       OtherCostClass,
				                                                                                       SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ProjectJobCostCodeDetailByPeriodSp(string StartProjNum,
		                                                        string EndProjNum,
		                                                        int? StartTaskNum,
		                                                        int? EndTaskNum,
		                                                        string StartProdCode,
		                                                        string EndProdCode,
		                                                        string StartCostCode,
		                                                        string EndCostCode,
		                                                        string StartYear,
		                                                        string StartMonth,
		                                                        int? NumberMonths,
		                                                        string CostCodeType,
		                                                        string ProjLevel,
		                                                        string MatlCostClass,
		                                                        string LaborCostClass,
		                                                        string OtherCostClass,
		                                                        string ActiveProjStat,
		                                                        string InactiveProjStat,
		                                                        string CompleteProjStat,
		                                                        string HistoryProjStat,
		                                                        [Optional] string ProjMgr,
		                                                        [Optional] string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ProjectJobCostCodeDetailByPeriodExt = new CLM_ProjectJobCostCodeDetailByPeriodFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ProjectJobCostCodeDetailByPeriodExt.CLM_ProjectJobCostCodeDetailByPeriodSp(StartProjNum,
				                                                                                             EndProjNum,
				                                                                                             StartTaskNum,
				                                                                                             EndTaskNum,
				                                                                                             StartProdCode,
				                                                                                             EndProdCode,
				                                                                                             StartCostCode,
				                                                                                             EndCostCode,
				                                                                                             StartYear,
				                                                                                             StartMonth,
				                                                                                             NumberMonths,
				                                                                                             CostCodeType,
				                                                                                             ProjLevel,
				                                                                                             MatlCostClass,
				                                                                                             LaborCostClass,
				                                                                                             OtherCostClass,
				                                                                                             ActiveProjStat,
				                                                                                             InactiveProjStat,
				                                                                                             CompleteProjStat,
				                                                                                             HistoryProjStat,
				                                                                                             ProjMgr,
				                                                                                             SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
