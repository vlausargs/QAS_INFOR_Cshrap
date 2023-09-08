//PROJECT NAME: APSExt
//CLASS NAME: SLResourceGroupUtilizations.cs

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
    [IDOExtensionClass("SLResourceGroupUtilizations")]
    public class SLResourceGroupUtilizations : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsGetSchedValuesSp(short? AltNum,
                                       decimal? Threshold,
                                       ref int? RGUtil,
                                       ref int? OrdLate,
                                       ref int? OrdOnTime,
                                       ref int? RGQueue)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsGetSchedValuesExt = new ApsGetSchedValuesFactory().Create(appDb);

                ApsIntType oRGUtil = RGUtil;
                ApsIntType oOrdLate = OrdLate;
                ApsIntType oOrdOnTime = OrdOnTime;
                ApsIntType oRGQueue = RGQueue;

                int Severity = iApsGetSchedValuesExt.ApsGetSchedValuesSp(AltNum,
                                                                         Threshold,
                                                                         ref oRGUtil,
                                                                         ref oOrdLate,
                                                                         ref oOrdOnTime,
                                                                         ref oRGQueue);

                RGUtil = oRGUtil;
                OrdLate = oOrdLate;
                OrdOnTime = oOrdOnTime;
                RGQueue = oRGQueue;


                return Severity;
            }
        }






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetPlannerResGrpUtilSp(int? AltNum,
		DateTime? StartDate,
		int? IntervalCount,
		int? IntervalType,
		decimal? Threshold,
		string RGID,
		int? ExcludeInfinite,
		int? GroupAllocOnly,
		string WildCardChar,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetPlannerResGrpUtilExt = new CLM_ApsGetPlannerResGrpUtilFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetPlannerResGrpUtilExt.CLM_ApsGetPlannerResGrpUtilSp(AltNum,
				StartDate,
				IntervalCount,
				IntervalType,
				Threshold,
				RGID,
				ExcludeInfinite,
				GroupAllocOnly,
				WildCardChar,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetSchedResGrpUtilSp(int? AltNum,
		DateTime? StartDate,
		int? IntervalCount,
		int? IntervalType,
		decimal? Threshold,
		string RGID,
		int? ExcludeInfinite,
		int? GroupAllocOnly,
		string WildCardChar,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetSchedResGrpUtilExt = new CLM_ApsGetSchedResGrpUtilFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetSchedResGrpUtilExt.CLM_ApsGetSchedResGrpUtilSp(AltNum,
				StartDate,
				IntervalCount,
				IntervalType,
				Threshold,
				RGID,
				ExcludeInfinite,
				GroupAllocOnly,
				WildCardChar,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
