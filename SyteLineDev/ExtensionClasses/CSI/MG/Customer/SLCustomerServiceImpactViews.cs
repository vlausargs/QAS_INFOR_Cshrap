//PROJECT NAME: CustomerExt
//CLASS NAME: SLCustomerServiceImpactViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLCustomerServiceImpactViews")]
    public class SLCustomerServiceImpactViews : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CustomerServiceImpartDetailSp(string StartDate,
		                                                   [Optional] string LateByDate,
		                                                   [Optional, DefaultParameterValue(6)] int? GraphIntervalCount,
		[Optional, DefaultParameterValue(2)] int? GraphIntervalType,
		[Optional, DefaultParameterValue((byte)0)] byte? IncludeWithCO,
		[Optional, DefaultParameterValue((byte)0)] byte? JobOrderOnly,
		[Optional] string UnallocJOPrice,
		int? Yield,
		[Optional, DefaultParameterValue("DTL")] string RptType,
		[Optional] string CustNums,
		[Optional] string CustNumShipto)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_CustomerServiceImpartExt = new CLM_CustomerServiceImpartFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_CustomerServiceImpartExt.CLM_CustomerServiceImpartSp(StartDate,
				                                                                       LateByDate,
				                                                                       GraphIntervalCount,
				                                                                       GraphIntervalType,
				                                                                       IncludeWithCO,
				                                                                       JobOrderOnly,
				                                                                       UnallocJOPrice,
				                                                                       Yield,
				                                                                       RptType,
				                                                                       CustNums,
				                                                                       CustNumShipto);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CustomerServiceImpartSummarySp(string StartDate,
		                                                    [Optional] string LateByDate,
		                                                    [Optional, DefaultParameterValue(6)] int? GraphIntervalCount,
		[Optional, DefaultParameterValue(2)] int? GraphIntervalType,
		[Optional, DefaultParameterValue((byte)0)] byte? IncludeWithCO,
		[Optional, DefaultParameterValue((byte)0)] byte? JobOrderOnly,
		[Optional] string UnallocJOPrice,
		int? Yield,
		[Optional, DefaultParameterValue("DTL")] string RptType,
		[Optional] string CustNums,
		[Optional] string CustNumShipto)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_CustomerServiceImpartExt = new CLM_CustomerServiceImpartFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_CustomerServiceImpartExt.CLM_CustomerServiceImpartSp(StartDate,
				                                                                       LateByDate,
				                                                                       GraphIntervalCount,
				                                                                       GraphIntervalType,
				                                                                       IncludeWithCO,
				                                                                       JobOrderOnly,
				                                                                       UnallocJOPrice,
				                                                                       Yield,
				                                                                       RptType,
				                                                                       CustNums,
				                                                                       CustNumShipto);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
