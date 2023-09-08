//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoitemAlls.cs

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
	[IDOExtensionClass("SLCoitemAlls")]
	public class SLCoitemAlls : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_MarginSp([Optional] string CustNum,
		[Optional] string FilterString,
		[Optional] string PSiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_MarginExt = new CLM_MarginFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_MarginExt.CLM_MarginSp(CustNum,
				FilterString,
				PSiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CustomerOrderPriceHistorySp(string CustNum,
            string Item,
            string FilterString,
            [Optional] string PSiteGroup)
        {
            var iCLM_CustomerOrderPriceHistoryExt = new CLM_CustomerOrderPriceHistoryFactory().Create(this, true);

            var result = iCLM_CustomerOrderPriceHistoryExt.CLM_CustomerOrderPriceHistorySp(CustNum,
                Item,
                FilterString,
                PSiteGroup);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }
    }
}
