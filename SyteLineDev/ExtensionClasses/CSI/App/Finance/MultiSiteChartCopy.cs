//PROJECT NAME: CSIFinance
//CLASS NAME: MultiSiteChartCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiSiteChartCopy
    {
        int MultiSiteChartCopySp(HighLowCharType pStartAcct,
                                 HighLowCharType pEndAcct,
                                 SiteType pToSite,
                                 Flag pCopyReportsToAcct,
                                 Flag pOverwriteExistingRecords,
                                 ref InfobarType Infobar);
    }

    public class MultiSiteChartCopy : IMultiSiteChartCopy
    {
        readonly IApplicationDB appDB;

        public MultiSiteChartCopy(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiSiteChartCopySp(HighLowCharType pStartAcct,
                                        HighLowCharType pEndAcct,
                                        SiteType pToSite,
                                        Flag pCopyReportsToAcct,
                                        Flag pOverwriteExistingRecords,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiSiteChartCopySp";

                appDB.AddCommandParameter(cmd, "pStartAcct", pStartAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndAcct", pEndAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pToSite", pToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCopyReportsToAcct", pCopyReportsToAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pOverwriteExistingRecords", pOverwriteExistingRecords, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}