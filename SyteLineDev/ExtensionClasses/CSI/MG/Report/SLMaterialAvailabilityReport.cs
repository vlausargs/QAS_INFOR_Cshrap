//PROJECT NAME: ReportExt
//CLASS NAME: SLMaterialAvailabilityReport.cs

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
    [IDOExtensionClass("SLMaterialAvailabilityReport")]
    public class SLMaterialAvailabilityReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MaterialAvailabilitySp([Optional] string ExOptdfEst08Item,
		[Optional] string ExOptdfEst08Job,
		[Optional] int? ExOptdfEst08Suffix,
		[Optional] string ExOptprPsNum,
		[Optional] DateTime? ReleaseDueDate,
		[Optional] decimal? ExOptdfEst08QtyReq,
		[Optional] DateTime? ExOptdfEst08Date,
		[Optional] int? ExOptacConsItemOh,
		[Optional] int? ExOptszUseSafety,
		[Optional] int? ExOptgoInclRelJobs,
		[Optional] string TPsStat,
		[Optional] int? ExOptgoInclOrdPo,
		[Optional] int? ExOptszShowShortOnly,
		[Optional] int? ExOptszSubFromOnhand,
		[Optional] int? TDateSensitive,
		[Optional] string ExOptdfEst08Whse,
		[Optional] int? ExOptdfEst08DateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MaterialAvailabilityExt = new Rpt_MaterialAvailabilityFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MaterialAvailabilityExt.Rpt_MaterialAvailabilitySp(ExOptdfEst08Item,
				ExOptdfEst08Job,
				ExOptdfEst08Suffix,
				ExOptprPsNum,
				ReleaseDueDate,
				ExOptdfEst08QtyReq,
				ExOptdfEst08Date,
				ExOptacConsItemOh,
				ExOptszUseSafety,
				ExOptgoInclRelJobs,
				TPsStat,
				ExOptgoInclOrdPo,
				ExOptszShowShortOnly,
				ExOptszSubFromOnhand,
				TDateSensitive,
				ExOptdfEst08Whse,
				ExOptdfEst08DateOffset,
				DisplayHeader,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
