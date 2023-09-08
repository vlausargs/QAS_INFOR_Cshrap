//PROJECT NAME: APSExt
//CLASS NAME: SLResourceUtilizations.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLResourceUtilizations")]
    public class SLResourceUtilizations : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ApsGetPlannerResrcUtilSp(short? AltNum,
                                                      DateTime? StartDate,
                                                      int? IntervalCount,
                                                      int? IntervalType,
                                                      decimal? Threshold,
                                                      string ResrcID,
                                                      byte? ExcludeInfinite,
                                                      string WildCardChar,
                                                      string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ApsGetPlannerResrcUtilExt = new CLM_ApsGetPlannerResrcUtilFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_ApsGetPlannerResrcUtilExt.CLM_ApsGetPlannerResrcUtilSp(AltNum,
                                                                                           StartDate,
                                                                                           IntervalCount,
                                                                                           IntervalType,
                                                                                           Threshold,
                                                                                           ResrcID,
                                                                                           ExcludeInfinite,
                                                                                           WildCardChar,
                                                                                           FilterString);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ApsGetSchedResrcUtilSp(short? AltNum,
                                                    DateTime? StartDate,
                                                    int? IntervalCount,
                                                    int? IntervalType,
                                                    decimal? Threshold,
                                                    string ResrcID,
                                                    byte? ExcludeInfinite,
                                                    string WildCardChar,
                                                    string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ApsGetSchedResrcUtilExt = new CLM_ApsGetSchedResrcUtilFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_ApsGetSchedResrcUtilExt.CLM_ApsGetSchedResrcUtilSp(AltNum,
                                                                                       StartDate,
                                                                                       IntervalCount,
                                                                                       IntervalType,
                                                                                       Threshold,
                                                                                       ResrcID,
                                                                                       ExcludeInfinite,
                                                                                       WildCardChar,
                                                                                       FilterString);

                return dt;
            }
        }
    }
}
