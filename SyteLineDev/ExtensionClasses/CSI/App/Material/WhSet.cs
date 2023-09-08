//PROJECT NAME: CSIMaterial
//CLASS NAME: WhSet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IWhSet
    {
        int WhSetSp(WhseType Whse,
                    ListYesNoType CustomerSet,
                    CustNumType CustNumBegin,
                    CustNumType CustNumEnd,
                    ListYesNoType VendorSet,
                    VendNumType VendNumBegin,
                    VendNumType VendNumEnd,
                    ListYesNoType UserSet,
                    UsernameType UserBegin,
                    UsernameType UserEnd,
                    ref InfobarType Infobar);
    }

    public class WhSet : IWhSet
    {
        readonly IApplicationDB appDB;

        public WhSet(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int WhSetSp(WhseType Whse,
                           ListYesNoType CustomerSet,
                           CustNumType CustNumBegin,
                           CustNumType CustNumEnd,
                           ListYesNoType VendorSet,
                           VendNumType VendNumBegin,
                           VendNumType VendNumEnd,
                           ListYesNoType UserSet,
                           UsernameType UserBegin,
                           UsernameType UserEnd,
                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WhSetSp";

                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerSet", CustomerSet, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNumBegin", CustNumBegin, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNumEnd", CustNumEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendorSet", VendorSet, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendNumBegin", VendNumBegin, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendNumEnd", VendNumEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserSet", UserSet, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserBegin", UserBegin, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserEnd", UserEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
