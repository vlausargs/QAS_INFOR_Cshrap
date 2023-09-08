//PROJECT NAME: ReportExt
//CLASS NAME: SLCustomerServiceImpactInquiryReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLCustomerServiceImpactInquiryReport")]
    public class SLCustomerServiceImpactInquiryReport : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable RPT_CustomerServiceInquirySP(string pSite,
                                                      DateTime? BaseDate,
                                                      string/*Nullable reference types is currently in preview error ?*/ LateByDate,
                                                      int? GraphInterval,
                                                      int? GraphIntervalPeriod,
                                                      byte? IncludeWithCO,
                                                      byte? JobOrderOnly,
                                                      string/*Nullable reference types is currently in preview error ?*/ UnallocJOPrice,
                                                      int? Yield,
                                                      string/*Nullable reference types is currently in preview error ?*/ RptType,
                                                      string/*Nullable reference types is currently in preview error ?*/ CustNums,
                                                      string/*Nullable reference types is currently in preview error ?*/ CustNumShipto)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iRPT_CustomerServiceInquiryExt = new RPT_CustomerServiceInquiryFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iRPT_CustomerServiceInquiryExt.RPT_CustomerServiceInquirySP(pSite,
                                                                                           BaseDate,
                                                                                           LateByDate,
                                                                                           GraphInterval,
                                                                                           GraphIntervalPeriod,
                                                                                           IncludeWithCO,
                                                                                           JobOrderOnly,
                                                                                           UnallocJOPrice,
                                                                                           Yield,
                                                                                           RptType,
                                                                                           CustNums,
                                                                                           CustNumShipto);

                return dt;
            }
        }
    }
}
