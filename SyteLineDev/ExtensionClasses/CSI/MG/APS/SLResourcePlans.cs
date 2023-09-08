//PROJECT NAME: APSExt
//CLASS NAME: SLResourcePlans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLResourcePlans")]
    public class SLResourcePlans : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ResourceGroupPlanSp([Optional, DefaultParameterValue((short)0)] short? AltNum,
        [Optional] string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ResourceGroupPlanExt = new CLM_ResourceGroupPlanFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_ResourceGroupPlanExt.CLM_ResourceGroupPlanSp(AltNum,
                                                                               FilterString);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ResourcePlanSp([Optional, DefaultParameterValue(0)] int? AltNum,
            [Optional] string FilterString)
        {
            var iCLM_ResourcePlanExt = new CLM_ResourcePlanFactory().Create(this, true);

            var result = iCLM_ResourcePlanExt.CLM_ResourcePlanSp(AltNum,
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
        public DataTable CLM_ApsGetGanttResourcesSp(DateTime? StartDate,
        DateTime? EndDate,
        int? Plan0Sched1,
        [Optional, DefaultParameterValue(0)] int? AltNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_ApsGetGanttResourcesExt = new CLM_ApsGetGanttResourcesFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCLM_ApsGetGanttResourcesExt.CLM_ApsGetGanttResourcesSp(StartDate,
                EndDate,
                Plan0Sched1,
                AltNum);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ResGanttDemandsSp([Optional, DefaultParameterValue(0)] int? AltNum,
        [Optional, DefaultParameterValue(1)] int? PlannerFg)
        {
            var iCLM_ResGanttDemandsExt = this.GetService<ICLM_ResGanttDemands>();

            var result = iCLM_ResGanttDemandsExt.CLM_ResGanttDemandsSp(AltNum,
                PlannerFg);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ResGanttPlanSp(DateTime? StartDate,
        DateTime? EndDate,
        [Optional, DefaultParameterValue(0)] int? AltNum,
        [Optional] string FilterString,
        [Optional] string CustNum,
        [Optional] string Item,
        [Optional] string Material)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_ResGanttPlanExt = new CLM_ResGanttPlanFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCLM_ResGanttPlanExt.CLM_ResGanttPlanSp(StartDate,
                EndDate,
                AltNum,
                FilterString,
                CustNum,
                Item,
                Material);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_ResourcePlanSp([Optional, DefaultParameterValue(0)] int? AltNum,
        [Optional] string FilterString,
        string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_ResourcePlanExt = new Home_ResourcePlanFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_ResourcePlanExt.Home_ResourcePlanSp(AltNum,
                FilterString,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }
    }
}
