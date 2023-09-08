//PROJECT NAME: CSIReport
//CLASS NAME: RPT_CustomerServiceInquiry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Reporting
{
    public interface IRPT_CustomerServiceInquiry
    {
        DataTable RPT_CustomerServiceInquirySP(SiteType pSite,
                                               DateType BaseDate,
                                               StringType LateByDate,
                                               IntType GraphInterval,
                                               IntType GraphIntervalPeriod,
                                               ListYesNoType IncludeWithCO,
                                               ListYesNoType JobOrderOnly,
                                               StringType UnallocJOPrice,
                                               IntType Yield,
                                               StringType RptType,
                                               StringType CustNums,
                                               StringType CustNumShipto);
    }

    public class RPT_CustomerServiceInquiry : IRPT_CustomerServiceInquiry
    {
        IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public RPT_CustomerServiceInquiry(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable RPT_CustomerServiceInquirySP(SiteType pSite,
                                                      DateType BaseDate,
                                                      StringType LateByDate,
                                                      IntType GraphInterval,
                                                      IntType GraphIntervalPeriod,
                                                      ListYesNoType IncludeWithCO,
                                                      ListYesNoType JobOrderOnly,
                                                      StringType UnallocJOPrice,
                                                      IntType Yield,
                                                      StringType RptType,
                                                      StringType CustNums,
                                                      StringType CustNumShipto)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RPT_CustomerServiceInquirySP";

                appDB.AddCommandParameter(cmd, "pSite", pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BaseDate", BaseDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LateByDate", LateByDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GraphInterval", GraphInterval, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GraphIntervalPeriod", GraphIntervalPeriod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeWithCO", IncludeWithCO, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobOrderOnly", JobOrderOnly, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UnallocJOPrice", UnallocJOPrice, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Yield", Yield, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RptType", RptType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNums", CustNums, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNumShipto", CustNumShipto, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
