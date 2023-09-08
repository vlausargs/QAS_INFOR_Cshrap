//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ArTermsDue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICLM_ArTermsDue
    {
        DataTable CLM_ArTermsDueSp(SiteType PSite_ref,
                                   CustNumType PCustNum,
                                   InvNumType PInvNum,
                                   InvSeqType PInvSeq);
    }

    public class CLM_ArTermsDue : ICLM_ArTermsDue
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_ArTermsDue(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_ArTermsDueSp(SiteType PSite_ref,
                                          CustNumType PCustNum,
                                          InvNumType PInvNum,
                                          InvSeqType PInvSeq)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_ArTermsDueSp";

                    appDB.AddCommandParameter(cmd, "PSite_ref", PSite_ref, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PInvNum", PInvNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PInvSeq", PInvSeq, ParameterDirection.Input);

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
