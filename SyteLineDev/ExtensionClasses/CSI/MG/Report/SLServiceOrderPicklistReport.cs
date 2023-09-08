//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderPicklistReport.cs

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
	[IDOExtensionClass("SLServiceOrderPicklistReport")]
	public class SLServiceOrderPicklistReport : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROPicklistSp([Optional] string ExOptBegSRO_Num,
		[Optional] string ExOptEndSRO_Num,
		[Optional] int? ExOptBegSRO_Line,
		[Optional] int? ExOptEndSRO_Line,
		[Optional] int? ExOptBegSRO_Oper,
		[Optional] int? ExOptEndSRO_Oper,
		[Optional] string ExOptBegSRO_Type,
		[Optional] string ExOptEndSRO_Type,
		[Optional] string ExOptacSROStat,
		[Optional] string ExOptacLineStat,
		[Optional] string ExOptacOperStat,
		[Optional] string ExOptacWhse,
		[Optional] string ExOptacTransWhse,
		[Optional] int? ExOptacInclPosted,
		[Optional] int? ExOptacBarcode,
		[Optional] int? ExOptacShowAddr,
		[Optional] int? ExOptacShowAllLoc,
		[Optional] int? ExOptacShowSerials,
		[Optional] int? ExOptacIncSroNotes,
		[Optional] int? ExOptacIncLineNotes,
		[Optional] int? ExOptacIncOperNotes,
		[Optional] int? ExOptacIncCustNotes,
		[Optional] int? ExOptacIntNotes,
		[Optional] int? ExOptacExtNotes,
		[Optional] int? DisplayHeader,
		[Optional, DefaultParameterValue("I")] string OrderBy,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROPicklistExt = new SSSFSRpt_SROPicklistFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROPicklistExt.SSSFSRpt_SROPicklistSp(ExOptBegSRO_Num,
				ExOptEndSRO_Num,
				ExOptBegSRO_Line,
				ExOptEndSRO_Line,
				ExOptBegSRO_Oper,
				ExOptEndSRO_Oper,
				ExOptBegSRO_Type,
				ExOptEndSRO_Type,
				ExOptacSROStat,
				ExOptacLineStat,
				ExOptacOperStat,
				ExOptacWhse,
				ExOptacTransWhse,
				ExOptacInclPosted,
				ExOptacBarcode,
				ExOptacShowAddr,
				ExOptacShowAllLoc,
				ExOptacShowSerials,
				ExOptacIncSroNotes,
				ExOptacIncLineNotes,
				ExOptacIncOperNotes,
				ExOptacIncCustNotes,
				ExOptacIntNotes,
				ExOptacExtNotes,
				DisplayHeader,
				OrderBy,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
