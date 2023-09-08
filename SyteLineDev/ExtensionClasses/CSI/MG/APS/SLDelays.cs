//PROJECT NAME: APSExt
//CLASS NAME: SLDelays.cs

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
    [IDOExtensionClass("SLDelays")]
    public class SLDelays : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ApsGetDelaysSp(int? AltNo,
                                            string DemandType,
                                            string DemandRef,
                                            byte? CriticalPathOnly,
                                            byte? ShowItemDelays,
                                            byte? ShowGroupDelays,
                                            byte? ExcludeInfinite,
                                            string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ApsGetDelaysExt = new CLM_ApsGetDelaysFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_ApsGetDelaysExt.CLM_ApsGetDelaysSp(AltNo,
                                                                       DemandType,
                                                                       DemandRef,
                                                                       CriticalPathOnly,
                                                                       ShowItemDelays,
                                                                       ShowGroupDelays,
                                                                       ExcludeInfinite,
                                                                       FilterString);

                return dt;
            }
        }


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetLateDemandIdSp(string PDemandType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetLateDemandIdExt = new CLM_ApsGetLateDemandIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetLateDemandIdExt.CLM_ApsGetLateDemandIdSp(PDemandType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
