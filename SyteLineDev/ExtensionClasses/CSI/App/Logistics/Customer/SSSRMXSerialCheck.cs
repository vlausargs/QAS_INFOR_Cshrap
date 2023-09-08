//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXSerialCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXSerialCheck
    {
        int SSSRMXSerialCheckSp(string SerNum,
                                ref string Prompt,
                                ref string Infobar,
                                string Item);
    }

    public class SSSRMXSerialCheck : ISSSRMXSerialCheck
    {
        readonly IApplicationDB appDB;

        public SSSRMXSerialCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXSerialCheckSp(string SerNum,
                                       ref string Prompt,
                                       ref string Infobar,
                                       string Item)
        {
            SerNumType _SerNum = SerNum;
            Infobar _Prompt = Prompt;
            Infobar _Infobar = Infobar;
            ItemType _Item = Item;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXSerialCheckSp";

                appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Prompt = _Prompt;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
