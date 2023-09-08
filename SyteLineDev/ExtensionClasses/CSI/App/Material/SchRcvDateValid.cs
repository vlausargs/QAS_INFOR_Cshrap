//PROJECT NAME: CSIMaterial
//CLASS NAME: SchRcvDateValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ISchRcvDateValid
    {
        int SchRcvDateValidSp(TrnNumType PTrnNum,
                              ItemType PItem,
                              ref DateType PSchRcvDate,
                              ref DateType PSchShipDate,
                              ref InfobarType Infobar);
    }

    public class SchRcvDateValid : ISchRcvDateValid
    {
        readonly IApplicationDB appDB;

        public SchRcvDateValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SchRcvDateValidSp(TrnNumType PTrnNum,
                                     ItemType PItem,
                                     ref DateType PSchRcvDate,
                                     ref DateType PSchShipDate,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SchRcvDateValidSp";

                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSchRcvDate", PSchRcvDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PSchShipDate", PSchShipDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
