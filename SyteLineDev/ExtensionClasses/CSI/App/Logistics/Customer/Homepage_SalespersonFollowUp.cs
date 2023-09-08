//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_SalespersonFollowUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_SalespersonFollowUp
    {
        DataTable Homepage_SalespersonFollowUpSp(string Salesperson,
                                                 string Username);
    }

    public class Homepage_SalespersonFollowUp : IHomepage_SalespersonFollowUp
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Homepage_SalespersonFollowUp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Homepage_SalespersonFollowUpSp(string Salesperson,
                                                        string Username)
        {
            SlsmanType _Salesperson = Salesperson;
            UsernameType _Username = Username;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_SalespersonFollowUpSp";

                appDB.AddCommandParameter(cmd, "Salesperson", _Salesperson, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
