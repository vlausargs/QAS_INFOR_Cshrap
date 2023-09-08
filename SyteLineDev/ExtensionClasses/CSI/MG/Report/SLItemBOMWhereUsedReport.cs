//PROJECT NAME: ReportExt
//CLASS NAME: SLItemBOMWhereUsedReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLItemBOMWhereUsedReport")]
    public class SLItemBOMWhereUsedReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemBOMWhereUsedSp(string ItemStarting,
		                                        string ItemEnding,
		                                        string ProductCodeStarting,
		                                        string ProductCodeEnding,
		                                        string JobType,
		                                        string MaterialType,
		                                        string Source,
		                                        string Stocked,
		                                        string NonStocked,
		                                        string ABCCode,
		                                        DateTime? EffectiveDate,
		                                        [Optional] short? EffectiveDateOffset,
		                                        string DisplayHistory,
		                                        byte? IndentedLevelView,
		                                        byte? PageBetweenItems,
		                                        byte? DisplayHeader,
		                                        [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemBOMWhereUsedExt = new Rpt_ItemBOMWhereUsedFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemBOMWhereUsedExt.Rpt_ItemBOMWhereUsedSp(ItemStarting,
				                                                             ItemEnding,
				                                                             ProductCodeStarting,
				                                                             ProductCodeEnding,
				                                                             JobType,
				                                                             MaterialType,
				                                                             Source,
				                                                             Stocked,
				                                                             NonStocked,
				                                                             ABCCode,
				                                                             EffectiveDate,
				                                                             EffectiveDateOffset,
				                                                             DisplayHistory,
				                                                             IndentedLevelView,
				                                                             PageBetweenItems,
				                                                             DisplayHeader,
				                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
