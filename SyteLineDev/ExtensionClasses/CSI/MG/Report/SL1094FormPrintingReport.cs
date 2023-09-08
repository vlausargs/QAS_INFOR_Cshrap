//PROJECT NAME: ReportExt
//CLASS NAME: SL1094FormPrintingReport.cs

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
    [IDOExtensionClass("SL1094FormPrintingReport")]
    public class SL1094FormPrintingReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_1094FormPrintingSp([Optional] Guid? SessionId,
		                                        [Optional] byte? Corrected,
		                                        [Optional] byte? Transmittal,
		                                        [Optional] byte? Member,
		                                        [Optional] byte? QOM,
		                                        [Optional] byte? QOMTR,
		                                        [Optional] byte? Section480,
		                                        [Optional] byte? _98Pct,
		                                        [Optional] byte? MEC12Months,
		                                        [Optional] byte? MECJan,
		                                        [Optional] byte? MECFeb,
		                                        [Optional] byte? MECMar,
		                                        [Optional] byte? MECApr,
		                                        [Optional] byte? MECMay,
		                                        [Optional] byte? MECJun,
		                                        [Optional] byte? MECJul,
		                                        [Optional] byte? MECAug,
		                                        [Optional] byte? MECSep,
		                                        [Optional] byte? MECOct,
		                                        [Optional] byte? MECNov,
		                                        [Optional] byte? MECDec,
		                                        [Optional] byte? AGI12Months,
		                                        [Optional] byte? AGIJan,
		                                        [Optional] byte? AGIFeb,
		                                        [Optional] byte? AGIMar,
		                                        [Optional] byte? AGIApr,
		                                        [Optional] byte? AGIMay,
		                                        [Optional] byte? AGIJun,
		                                        [Optional] byte? AGIJul,
		                                        [Optional] byte? AGIAug,
		                                        [Optional] byte? AGISep,
		                                        [Optional] byte? AGIOct,
		                                        [Optional] byte? AGINov,
		                                        [Optional] byte? AGIDec,
		                                        [Optional] decimal? FTE12Months,
		                                        [Optional] decimal? FTEJan,
		                                        [Optional] decimal? FTEFeb,
		                                        [Optional] decimal? FTEMar,
		                                        [Optional] decimal? FTEApr,
		                                        [Optional] decimal? FTEMay,
		                                        [Optional] decimal? FTEJun,
		                                        [Optional] decimal? FTEJul,
		                                        [Optional] decimal? FTEAug,
		                                        [Optional] decimal? FTESep,
		                                        [Optional] decimal? FTEOct,
		                                        [Optional] decimal? FTENov,
		                                        [Optional] decimal? FTEDec,
		                                        [Optional] decimal? TEC12Months,
		                                        [Optional] decimal? TECJan,
		                                        [Optional] decimal? TECFeb,
		                                        [Optional] decimal? TECMar,
		                                        [Optional] decimal? TECApr,
		                                        [Optional] decimal? TECMay,
		                                        [Optional] decimal? TECJun,
		                                        [Optional] decimal? TECJul,
		                                        [Optional] decimal? TECAug,
		                                        [Optional] decimal? TECSep,
		                                        [Optional] decimal? TECOct,
		                                        [Optional] decimal? TECNov,
		                                        [Optional] decimal? TECDec,
		                                        [Optional] string TRI12Months,
		                                        [Optional] string TRIJan,
		                                        [Optional] string TRIFeb,
		                                        [Optional] string TRIMar,
		                                        [Optional] string TRIApr,
		                                        [Optional] string TRIMay,
		                                        [Optional] string TRIJun,
		                                        [Optional] string TRIJul,
		                                        [Optional] string TRIAug,
		                                        [Optional] string TRISep,
		                                        [Optional] string TRIOct,
		                                        [Optional] string TRINov,
		                                        [Optional] string TRIDec,
		                                        [Optional] decimal? TotalNo1095CFiledByALEMember,
		                                        [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_1094FormPrintingExt = new Rpt_1094FormPrintingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_1094FormPrintingExt.Rpt_1094FormPrintingSp(SessionId,
				                                                             Corrected,
				                                                             Transmittal,
				                                                             Member,
				                                                             QOM,
				                                                             QOMTR,
				                                                             Section480,
				                                                             _98Pct,
				                                                             MEC12Months,
				                                                             MECJan,
				                                                             MECFeb,
				                                                             MECMar,
				                                                             MECApr,
				                                                             MECMay,
				                                                             MECJun,
				                                                             MECJul,
				                                                             MECAug,
				                                                             MECSep,
				                                                             MECOct,
				                                                             MECNov,
				                                                             MECDec,
				                                                             AGI12Months,
				                                                             AGIJan,
				                                                             AGIFeb,
				                                                             AGIMar,
				                                                             AGIApr,
				                                                             AGIMay,
				                                                             AGIJun,
				                                                             AGIJul,
				                                                             AGIAug,
				                                                             AGISep,
				                                                             AGIOct,
				                                                             AGINov,
				                                                             AGIDec,
				                                                             FTE12Months,
				                                                             FTEJan,
				                                                             FTEFeb,
				                                                             FTEMar,
				                                                             FTEApr,
				                                                             FTEMay,
				                                                             FTEJun,
				                                                             FTEJul,
				                                                             FTEAug,
				                                                             FTESep,
				                                                             FTEOct,
				                                                             FTENov,
				                                                             FTEDec,
				                                                             TEC12Months,
				                                                             TECJan,
				                                                             TECFeb,
				                                                             TECMar,
				                                                             TECApr,
				                                                             TECMay,
				                                                             TECJun,
				                                                             TECJul,
				                                                             TECAug,
				                                                             TECSep,
				                                                             TECOct,
				                                                             TECNov,
				                                                             TECDec,
				                                                             TRI12Months,
				                                                             TRIJan,
				                                                             TRIFeb,
				                                                             TRIMar,
				                                                             TRIApr,
				                                                             TRIMay,
				                                                             TRIJun,
				                                                             TRIJul,
				                                                             TRIAug,
				                                                             TRISep,
				                                                             TRIOct,
				                                                             TRINov,
				                                                             TRIDec,
				                                                             TotalNo1095CFiledByALEMember,
				                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
