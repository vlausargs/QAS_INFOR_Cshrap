//PROJECT NAME: CSIMaterial
//CLASS NAME: GetInterSiteCurrData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetInterSiteCurrData
    {
        int GetInterSiteCurrDataSp(SiteType PFromSite,
                                   SiteType PToSite,
                                   ref CurrCodeType PFromCurrCode,
                                   ref CurrCodeType PToCurrCode,
                                   ref ExchRateType PBuyRate,
                                   ref Infobar Infobar);
    }

    public class GetInterSiteCurrData : IGetInterSiteCurrData
    {
        readonly IApplicationDB appDB;

        public GetInterSiteCurrData(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetInterSiteCurrDataSp(SiteType PFromSite,
                                          SiteType PToSite,
                                          ref CurrCodeType PFromCurrCode,
                                          ref CurrCodeType PToCurrCode,
                                          ref ExchRateType PBuyRate,
                                          ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetInterSiteCurrDataSp";

                appDB.AddCommandParameter(cmd, "PFromSite", PFromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PToSite", PToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PFromCurrCode", PFromCurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PToCurrCode", PToCurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PBuyRate", PBuyRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
