//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderEstimateReport.cs

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
	[IDOExtensionClass("SLServiceOrderEstimateReport")]
	public class SLServiceOrderEstimateReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SroEstimateSp([Optional] string ExOptBegSRO_Num,
		[Optional] string ExOptEndSRO_Num,
		[Optional] int? ExOptBegSRO_Line,
		[Optional] int? ExOptEndSRO_Line,
		[Optional] int? ExOptBegSRO_Oper,
		[Optional] int? ExOptEndSRO_Oper,
		[Optional] string ExOptBegCust_Num,
		[Optional] string ExOptEndCust_Num,
		[Optional] DateTime? ExOptacEstDate,
		[Optional] DateTime? ExOptacValidThru,
		[Optional] int? ExOptFreightMisc,
		[Optional] int? ExOptacCalcTax,
		[Optional] int? ExOptacIncSroNotes,
		[Optional] int? ExOptacIncLineNotes,
		[Optional] int? ExOptacIncOperNotes,
		[Optional] int? ExOptacIncCustNotes,
		[Optional] int? ExOptacIntNotes,
		[Optional] int? ExOptacExtNotes,
		[Optional] int? ExOptacDisplayHeader,
		[Optional] int? ExOptacIncTransNotes,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SroEstimateExt = new SSSFSRpt_SroEstimateFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SroEstimateExt.SSSFSRpt_SroEstimateSp(ExOptBegSRO_Num,
				ExOptEndSRO_Num,
				ExOptBegSRO_Line,
				ExOptEndSRO_Line,
				ExOptBegSRO_Oper,
				ExOptEndSRO_Oper,
				ExOptBegCust_Num,
				ExOptEndCust_Num,
				ExOptacEstDate,
				ExOptacValidThru,
				ExOptFreightMisc,
				ExOptacCalcTax,
				ExOptacIncSroNotes,
				ExOptacIncLineNotes,
				ExOptacIncOperNotes,
				ExOptacIncCustNotes,
				ExOptacIntNotes,
				ExOptacExtNotes,
				ExOptacDisplayHeader,
				ExOptacIncTransNotes,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
