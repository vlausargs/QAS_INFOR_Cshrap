//PROJECT NAME: ReportExt
//CLASS NAME: SLSingleLevelCurrentBillofMaterialReport.cs

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
    [IDOExtensionClass("SLSingleLevelCurrentBillofMaterialReport")]
    public class SLSingleLevelCurrentBillofMaterialReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SingleLevelCurrentBillOfMaterialSp([Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] string AlternateIDStarting,
		[Optional] string AlternateIDEnding,
		[Optional] string MaterialType,
		[Optional] string Source,
		[Optional] string Shocked,
		[Optional] string ABCCode,
		[Optional] int? ShowCost,
		[Optional] int? DisplayReferenceFields,
		[Optional] int? PageBetweenItems,
		[Optional] int? PrintAlternate,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SingleLevelCurrentBillOfMaterialExt = new Rpt_SingleLevelCurrentBillOfMaterialFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SingleLevelCurrentBillOfMaterialExt.Rpt_SingleLevelCurrentBillOfMaterialSp(ItemStarting,
				ItemEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				AlternateIDStarting,
				AlternateIDEnding,
				MaterialType,
				Source,
				Shocked,
				ABCCode,
				ShowCost,
				DisplayReferenceFields,
				PageBetweenItems,
				PrintAlternate,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
