//PROJECT NAME: ReportExt
//CLASS NAME: SLAPRemittanceAdviceLaserReport.cs

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
    [IDOExtensionClass("SLAPRemittanceAdviceLaserReport")]
    public class SLAPRemittanceAdviceLaserReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_APRemittanceAdviceSp([Optional] string PSessionIDChar,
		[Optional, DefaultParameterValue("Number")] string PSortNameNum,
		[Optional] string PPayType,
		[Optional] string PBankCode,
		[Optional] string PStartingVendNum,
		[Optional] string PEndingVendNum,
		[Optional] string PStartingVendName,
		[Optional] string PEndingVendName,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_APRemittanceAdviceExt = new Rpt_APRemittanceAdviceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_APRemittanceAdviceExt.Rpt_APRemittanceAdviceSp(PSessionIDChar,
				PSortNameNum,
				PPayType,
				PBankCode,
				PStartingVendNum,
				PEndingVendNum,
				PStartingVendName,
				PEndingVendName,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
