//PROJECT NAME: ReportExt
//CLASS NAME: SLCertificateofOriginReport.cs

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
    [IDOExtensionClass("SLCertificateofOriginReport")]
    public class SLCertificateofOriginReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CertificateOfOriginSp([Optional] decimal? ShipmentStarting,
		                                           [Optional] decimal? ShipmentEnding,
		                                           [Optional] string CustomerStarting,
		                                           [Optional] string CustomerEnding,
		                                           [Optional] int? ShipToStarting,
		                                           [Optional] int? ShipToEnding,
		                                           [Optional] byte? DisplayHeader,
		                                           [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CertificateOfOriginExt = new Rpt_CertificateOfOriginFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CertificateOfOriginExt.Rpt_CertificateOfOriginSp(ShipmentStarting,
				                                                                   ShipmentEnding,
				                                                                   CustomerStarting,
				                                                                   CustomerEnding,
				                                                                   ShipToStarting,
				                                                                   ShipToEnding,
				                                                                   DisplayHeader,
				                                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
