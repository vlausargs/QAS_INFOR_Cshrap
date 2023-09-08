//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_ProductionFollowUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_ProductionFollowUp
    {
        DataTable Homepage_ProductionFollowUpSp();
    }

    public class Homepage_ProductionFollowUp : IHomepage_ProductionFollowUp
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Homepage_ProductionFollowUp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Homepage_ProductionFollowUpSp()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_ProductionFollowUpSp";

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
