//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_AccountBalanceBP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_AccountBalanceBP
    {
        DataTable Homepage_AccountBalanceBPSp(string Acct,
                                              string SiteRef);
    }

    public class Homepage_AccountBalanceBP : IHomepage_AccountBalanceBP
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Homepage_AccountBalanceBP(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Homepage_AccountBalanceBPSp(string Acct,
                                                     string SiteRef)
        {
            AcctType _Acct = Acct;
            SiteType _SiteRef = SiteRef;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_AccountBalanceBPSp";

                appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
