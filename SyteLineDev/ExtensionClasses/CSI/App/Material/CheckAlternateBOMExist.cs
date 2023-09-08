//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckAlternateBOMExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICheckAlternateBOMExist
    {
        int CheckAlternateBOMExistSp(ItemType Item,
                                     ref InfobarType Infobar);
    }

    public class CheckAlternateBOMExist : ICheckAlternateBOMExist
    {
        readonly IApplicationDB appDB;

        public CheckAlternateBOMExist(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckAlternateBOMExistSp(ItemType Item,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckAlternateBOMExistSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
