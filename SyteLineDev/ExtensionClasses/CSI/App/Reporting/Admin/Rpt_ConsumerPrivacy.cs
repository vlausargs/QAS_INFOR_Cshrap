//PROJECT NAME: CSIAdmin
//CLASS NAME: Rpt_ConsumerPrivacy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Reporting.Admin
{
    public interface IRpt_ConsumerPrivacy
    {
        DataTable Rpt_ConsumerPrivacySp(RowPointerType SessionID,
                                        SiteType pSite);
    }

    public class Rpt_ConsumerPrivacy : IRpt_ConsumerPrivacy
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;

        public Rpt_ConsumerPrivacy(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Rpt_ConsumerPrivacySp(RowPointerType SessionID,
                                               SiteType pSite)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Rpt_ConsumerPrivacySp";

                    appDB.AddCommandParameter(cmd, "SessionID", SessionID, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pSite", pSite, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
