//PROJECT NAME: ReportExt
//CLASS NAME: SLItemSerialNumberReport.cs

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
    [IDOExtensionClass("SLItemSerialNumberReport")]
    public class SLItemSerialNumberReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemSerialNumberSp([Optional] string SSerial,
		                                        [Optional] string ESerial,
		                                        [Optional] string SItem,
		                                        [Optional] string EItem,
		                                        [Optional] string SLot,
		                                        [Optional] string ELot,
		                                        [Optional] string CustStarting,
		                                        [Optional] string CustENDing,
		                                        [Optional] byte? DisplayHeader,
		                                        [Optional] string DisplaySource,
		                                        [Optional] string DisplayDestination,
		                                        [Optional] int? TaskId,
		                                        [Optional] string BGSessionId,
		                                        [Optional] string pSite,
		                                        [Optional] string DocumentNumStarting,
		                                        [Optional] string DocumentNumEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemSerialNumberExt = new Rpt_ItemSerialNumberFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemSerialNumberExt.Rpt_ItemSerialNumberSp(SSerial,
				                                                             ESerial,
				                                                             SItem,
				                                                             EItem,
				                                                             SLot,
				                                                             ELot,
				                                                             CustStarting,
				                                                             CustENDing,
				                                                             DisplayHeader,
				                                                             DisplaySource,
				                                                             DisplayDestination,
				                                                             TaskId,
				                                                             BGSessionId,
				                                                             pSite,
				                                                             DocumentNumStarting,
				                                                             DocumentNumEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
