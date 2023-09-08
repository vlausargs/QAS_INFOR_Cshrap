//PROJECT NAME: ReportExt
//CLASS NAME: SL1095FormPrintingReport.cs

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
    [IDOExtensionClass("SL1095FormPrintingReport")]
    public class SL1095FormPrintingReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_1095FormPrintingSp([Optional] Guid? SessionId,
		                                        [Optional] string EmployeeNumStarting,
		                                        [Optional] string EmployeeNumEnding,
		                                        [Optional] string PPhone,
		                                        [Optional] string pSite,
		                                        [Optional] DateTime? OfferDateStarting,
		                                        [Optional] DateTime? OfferDateEnding,
		                                        [Optional] string EmployerName,
		                                        [Optional] string EmployerAddr__1,
		                                        [Optional] string EmployerZip,
		                                        [Optional] string EmployerCity,
		                                        [Optional] string EmployerState,
		                                        [Optional] string EmployerCountry,
		                                        [Optional] string EmployerEIN,
		                                        [Optional] byte? PCorrected)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_1095FormPrintingExt = new Rpt_1095FormPrintingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_1095FormPrintingExt.Rpt_1095FormPrintingSp(SessionId,
				                                                             EmployeeNumStarting,
				                                                             EmployeeNumEnding,
				                                                             PPhone,
				                                                             pSite,
				                                                             OfferDateStarting,
				                                                             OfferDateEnding,
				                                                             EmployerName,
				                                                             EmployerAddr__1,
				                                                             EmployerZip,
				                                                             EmployerCity,
				                                                             EmployerState,
				                                                             EmployerCountry,
				                                                             EmployerEIN,
				                                                             PCorrected);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
