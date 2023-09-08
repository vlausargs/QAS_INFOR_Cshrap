//PROJECT NAME: ReportExt
//CLASS NAME: MOCoProduct.cs

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
    [IDOExtensionClass("MOCoProduct")]
    public class MOCoProduct : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable MO_Rpt_CoProductSp([Optional] string JobNum,
		                                    [Optional] short? JobSuffix,
		                                    [Optional, DefaultParameterValue((byte)0)] byte? CoProduct,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iMO_Rpt_CoProductExt = new MO_Rpt_CoProductFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iMO_Rpt_CoProductExt.MO_Rpt_CoProductSp(JobNum,
				                                                     JobSuffix,
				                                                     CoProduct,
				                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
