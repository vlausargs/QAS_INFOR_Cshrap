//PROJECT NAME: CSIMaterial
//CLASS NAME: SchShipDateValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ISchShipDateValid
    {
        int SchShipDateValidSp(TrnNumType PTrnNum,
                               ItemType PItem,
                               DateType PSchShipDate,
                               ref DateType PSchRcvDate,
                               ref InfobarType Infobar);
    }

    public class SchShipDateValid : ISchShipDateValid
    {
        readonly IApplicationDB appDB;

        public SchShipDateValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SchShipDateValidSp(TrnNumType PTrnNum,
                                      ItemType PItem,
                                      DateType PSchShipDate,
                                      ref DateType PSchRcvDate,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SchShipDateValidSp";

                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSchShipDate", PSchShipDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSchRcvDate", PSchRcvDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
