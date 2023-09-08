//PROJECT NAME: ReportExt
//CLASS NAME: SLItemCurrentRoutingReport.cs

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
    [IDOExtensionClass("SLItemCurrentRoutingReport")]
    public class SLItemCurrentRoutingReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemCurrentRoutingSp([Optional] string ItemStarting,
		                                          [Optional] string ItemEnding,
		                                          [Optional] string ProductCodeStarting,
		                                          [Optional] string ProductCodeEnding,
		                                          [Optional, DefaultParameterValue("ABC")] string ABCCode,
		[Optional] int? OperationStarting,
		[Optional] int? OperationEnding,
		[Optional] string AlternateIDStarting,
		[Optional] string AlternateIDEnding,
		[Optional] byte? PageBetweenOperations,
		[Optional] byte? PrintItemMaterials,
		[Optional] byte? PrintAlternate,
		[Optional] byte? DisplayReferenceFields,
		[Optional] byte? CheckEffectivityDates,
		[Optional] DateTime? EffectiveDate,
		[Optional, DefaultParameterValue("OM")] string PrintTextFor,
		[Optional] short? DateOffset,
		[Optional, DefaultParameterValue((byte)0)] byte? ShowInternal,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowExternal,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemCurrentRoutingExt = new Rpt_ItemCurrentRoutingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemCurrentRoutingExt.Rpt_ItemCurrentRoutingSp(ItemStarting,
				                                                                 ItemEnding,
				                                                                 ProductCodeStarting,
				                                                                 ProductCodeEnding,
				                                                                 ABCCode,
				                                                                 OperationStarting,
				                                                                 OperationEnding,
				                                                                 AlternateIDStarting,
				                                                                 AlternateIDEnding,
				                                                                 PageBetweenOperations,
				                                                                 PrintItemMaterials,
				                                                                 PrintAlternate,
				                                                                 DisplayReferenceFields,
				                                                                 CheckEffectivityDates,
				                                                                 EffectiveDate,
				                                                                 PrintTextFor,
				                                                                 DateOffset,
				                                                                 ShowInternal,
				                                                                 ShowExternal,
				                                                                 DisplayHeader,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}

