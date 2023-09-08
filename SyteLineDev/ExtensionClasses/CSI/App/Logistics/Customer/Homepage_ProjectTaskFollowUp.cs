//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_ProjectTaskFollowUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_ProjectTaskFollowUp
    {
        DataTable Homepage_ProjectTaskFollowUpSp(string ProjMgr);
    }

    public class Homepage_ProjectTaskFollowUp : IHomepage_ProjectTaskFollowUp
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Homepage_ProjectTaskFollowUp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Homepage_ProjectTaskFollowUpSp(string ProjMgr)
        {
            NameType _ProjMgr = ProjMgr;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_ProjectTaskFollowUpSp";

                appDB.AddCommandParameter(cmd, "ProjMgr", _ProjMgr, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
