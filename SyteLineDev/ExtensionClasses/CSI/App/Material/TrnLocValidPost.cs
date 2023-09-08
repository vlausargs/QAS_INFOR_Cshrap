//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnLocValidPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrnLocValidPost
    {
        int TrnLocValidPostSp(ItemType PItem,
                              TrnNumType PTrnNum,
                              LocType PTrnLoc,
                              ref InfobarType Infobar);
    }

    public class TrnLocValidPost : ITrnLocValidPost
    {
        readonly IApplicationDB appDB;

        public TrnLocValidPost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrnLocValidPostSp(ItemType PItem,
                                     TrnNumType PTrnNum,
                                     LocType PTrnLoc,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrnLocValidPostSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnLoc", PTrnLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
