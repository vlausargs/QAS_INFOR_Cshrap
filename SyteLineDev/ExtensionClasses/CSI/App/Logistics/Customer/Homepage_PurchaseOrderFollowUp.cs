//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_PurchaseOrderFollowUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_PurchaseOrderFollowUp
    {
        DataTable Homepage_PurchaseOrderFollowUpSp(string Buyer);
    }

    public class Homepage_PurchaseOrderFollowUp : IHomepage_PurchaseOrderFollowUp
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Homepage_PurchaseOrderFollowUp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Homepage_PurchaseOrderFollowUpSp(string Buyer)
        {
            UsernameType _Buyer = Buyer;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_PurchaseOrderFollowUpSp";

                appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
