//PROJECT NAME: ReportExt
//CLASS NAME: SLOrderVerificationDetailReport.cs

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
    [IDOExtensionClass("SLOrderVerificationDetailReport")]
    public class SLOrderVerificationDetailReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_OrderVerificationSp([Optional] byte? CoTypeRegular,
		                                         [Optional] byte? CoTypeBlanket,
                                                 [Optional] string CoStatus,
                                                 [Optional] string CoLineReleaseStat,
		                                         [Optional] string PrintItemCustItem,
		                                         [Optional] byte? PrintOrderText,
		                                         [Optional] byte? PrintStandardOrderText,
		                                         [Optional] byte? PrintCompanyName,
		                                         [Optional] string DisplayDate,
		                                         [Optional] DateTime? DateToAppear,
		                                         [Optional] short? DateToAppearOffset,
		                                         [Optional] byte? PrintBlanketLineText,
		                                         [Optional] byte? PrintBlanketLineDes,
		                                         [Optional] byte? PrintLineReleaseNotes,
		                                         [Optional] byte? PrintLineReleaseDes,
		                                         [Optional] byte? PrintShipToNotes,
		                                         [Optional] byte? printBillToNotes,
		                                         [Optional] byte? PrintPlanningItemMaterials,
		                                         [Optional] byte? IncludeSerialNumbers,
		                                         [Optional] byte? PrintEuroValue,
		                                         [Optional] byte? PrintPrice,
		                                         [Optional] string Sortby,
		                                         [Optional] string OrderStarting,
		                                         [Optional] string OrderEnding,
		                                         [Optional] string SalespersonStarting,
		                                         [Optional] string SalespersonEnding,
		                                         [Optional] int? OrderLineStarting,
		                                         [Optional] int? OrderReleaseStarting,
		                                         [Optional] int? OrderLineEnding,
		                                         [Optional] int? OrderReleaseEnding,
		                                         [Optional] byte? ShowInternal,
		                                         [Optional] byte? ShowExternal,
		                                         [Optional] byte? PrintItemOverview,
		                                         [Optional] byte? DisplayHeader,
		                                         [Optional] string ConfigDetails,
		                                         [Optional] int? TaskId,
		                                         [Optional] string pSite,
		                                         [Optional] byte? PrintDrawingNumber,
		                                         [Optional] byte? PrintTax,
		                                         [Optional] byte? PrintDeliveryIncoTerms,
		                                         [Optional] byte? PrintEUCode,
		                                         [Optional] byte? PrintOriginCode,
		                                         [Optional] byte? PrintCommodityCode,
		                                         [Optional] byte? PrintCurrencyCode,
		                                         [Optional] byte? PrintHeaderOnAllPages,
		                                         [Optional] byte? PrintEndUserItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_OrderVerificationExt = new Rpt_OrderVerificationFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_OrderVerificationExt.Rpt_OrderVerificationSp(CoTypeRegular,
				                                                               CoTypeBlanket,
                                                                               CoStatus,
				                                                               CoLineReleaseStat,
				                                                               PrintItemCustItem,
				                                                               PrintOrderText,
				                                                               PrintStandardOrderText,
				                                                               PrintCompanyName,
				                                                               DisplayDate,
				                                                               DateToAppear,
				                                                               DateToAppearOffset,
				                                                               PrintBlanketLineText,
				                                                               PrintBlanketLineDes,
				                                                               PrintLineReleaseNotes,
				                                                               PrintLineReleaseDes,
				                                                               PrintShipToNotes,
				                                                               printBillToNotes,
				                                                               PrintPlanningItemMaterials,
				                                                               IncludeSerialNumbers,
				                                                               PrintEuroValue,
				                                                               PrintPrice,
				                                                               Sortby,
				                                                               OrderStarting,
				                                                               OrderEnding,
				                                                               SalespersonStarting,
				                                                               SalespersonEnding,
				                                                               OrderLineStarting,
				                                                               OrderReleaseStarting,
				                                                               OrderLineEnding,
				                                                               OrderReleaseEnding,
				                                                               ShowInternal,
				                                                               ShowExternal,
				                                                               PrintItemOverview,
				                                                               DisplayHeader,
				                                                               ConfigDetails,
				                                                               TaskId,
				                                                               pSite,
				                                                               PrintDrawingNumber,
				                                                               PrintTax,
				                                                               PrintDeliveryIncoTerms,
				                                                               PrintEUCode,
				                                                               PrintOriginCode,
				                                                               PrintCommodityCode,
				                                                               PrintCurrencyCode,
				                                                               PrintHeaderOnAllPages,
				                                                               PrintEndUserItem);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
