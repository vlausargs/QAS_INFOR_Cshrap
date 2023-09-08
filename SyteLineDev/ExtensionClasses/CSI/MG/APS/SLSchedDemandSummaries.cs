//PROJECT NAME: APSExt
//CLASS NAME: SLSchedDemandSummaries.cs

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
    [IDOExtensionClass("SLSchedDemandSummaries")]
    public class SLSchedDemandSummaries : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsGetSchedulingEndDateSp(ref DateTime? PEndDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsGetSchedulingEndDateExt = new ApsGetSchedulingEndDateFactory().Create(appDb);

                DateType oPEndDate = PEndDate;

                int Severity = iApsGetSchedulingEndDateExt.ApsGetSchedulingEndDateSp(ref oPEndDate);

                PEndDate = oPEndDate;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsGetSchedulingStartDateSp(ref DateTime? PStartDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsGetSchedulingStartDateExt = new ApsGetSchedulingStartDateFactory().Create(appDb);

                DateType oPStartDate = PStartDate;

                int Severity = iApsGetSchedulingStartDateExt.ApsGetSchedulingStartDateSp(ref oPStartDate);

                PStartDate = oPStartDate;


                return Severity;
            }
        }



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SchedDemandSummariesSp(DateTime? StartDate,
		                                            DateTime? EndDate,
		                                            [Optional, DefaultParameterValue((short)0)] short? AltNum,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_SchedDemandSummariesExt = new CLM_SchedDemandSummariesFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_SchedDemandSummariesExt.CLM_SchedDemandSummariesSp(StartDate,
				                                                                     EndDate,
				                                                                     AltNum,
				                                                                     FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetSchedDemandIDSp(string PDemandType,
		string PDemandId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetSchedDemandIDExt = new CLM_ApsGetSchedDemandIDFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetSchedDemandIDExt.CLM_ApsGetSchedDemandIDSp(PDemandType,
				PDemandId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
