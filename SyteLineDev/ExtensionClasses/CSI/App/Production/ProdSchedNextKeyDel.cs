//PROJECT NAME: CSIProduct
//CLASS NAME: ProdSchedNextKeyDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IProdSchedNextKeyDel
    {
        int ProdSchedNextKeyDelSp(PsNumType PSNum,
                                  ref InfobarType Infobar);
    }

    public class ProdSchedNextKeyDel : IProdSchedNextKeyDel
    {
        readonly IApplicationDB appDB;

        public ProdSchedNextKeyDel(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ProdSchedNextKeyDelSp(PsNumType PSNum,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProdSchedNextKeyDelSp";

                appDB.AddCommandParameter(cmd, "PSNum", PSNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
