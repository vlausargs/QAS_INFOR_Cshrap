//PROJECT NAME: APSExt
//CLASS NAME: SLSupplyUsages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLSupplyUsages")]
    public class SLSupplyUsages : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ApsGetSupplyUsageSp(string SupplyType,
            string SupplyID,
            int? SupplyMatltag,
            Guid? SupplyRowPtr,
            string Item,
            DateTime? DueDate,
            string WildCardChar,
            int? AltNo,
            string FilterString)
        {
            var iCLM_ApsGetSupplyUsageExt = new CLM_ApsGetSupplyUsageFactory().Create(this, true);

            var result = iCLM_ApsGetSupplyUsageExt.CLM_ApsGetSupplyUsageSp(SupplyType,
                SupplyID,
                SupplyMatltag,
                SupplyRowPtr,
                Item,
                DueDate,
                WildCardChar,
                AltNo,
                FilterString);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }



        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetSupplyIDSp(string SupplyType,
		[Optional] string SupplyIdFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetSupplyIDExt = new CLM_ApsGetSupplyIDFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetSupplyIDExt.CLM_ApsGetSupplyIDSp(SupplyType,
				SupplyIdFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
