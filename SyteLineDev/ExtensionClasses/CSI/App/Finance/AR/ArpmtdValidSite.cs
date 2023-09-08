//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdValidSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtdValidSite
    {
        int ArpmtdValidSiteSp(SiteType PArpmtdSite,
                              CustNumType PArpmtCustNum,
                              ref Infobar Infobar);
    }

    public class ArpmtdValidSite : IArpmtdValidSite
    {
        readonly IApplicationDB appDB;

        public ArpmtdValidSite(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtdValidSiteSp(SiteType PArpmtdSite,
                                     CustNumType PArpmtCustNum,
                                     ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtdValidSiteSp";

                appDB.AddCommandParameter(cmd, "PArpmtdSite", PArpmtdSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtCustNum", PArpmtCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
