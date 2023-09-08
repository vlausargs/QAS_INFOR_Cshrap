//PROJECT NAME: CSIMaterial
//CLASS NAME: TransferDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITransferDefaults
    {
        int TransferDefaultsSp(SiteType FromSite,
                               ref WhseType FromWhse,
                               ref InfobarType Infobar);
    }

    public class TransferDefaults : ITransferDefaults
    {
        readonly IApplicationDB appDB;

        public TransferDefaults(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TransferDefaultsSp(SiteType FromSite,
                                      ref WhseType FromWhse,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TransferDefaultsSp";

                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromWhse", FromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
