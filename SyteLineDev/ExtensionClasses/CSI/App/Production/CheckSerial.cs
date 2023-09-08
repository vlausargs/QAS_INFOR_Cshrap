//PROJECT NAME: CSIProduct
//CLASS NAME: CheckSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICheckSerial
    {
        int CheckSerialSp(SerNumType PSerNum,
                          ItemType PItem,
                          ref InfobarType Infobar);
    }

    public class CheckSerial : ICheckSerial
    {
        readonly IApplicationDB appDB;

        public CheckSerial(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckSerialSp(SerNumType PSerNum,
                                 ItemType PItem,
                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckSerialSp";

                appDB.AddCommandParameter(cmd, "PSerNum", PSerNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
