//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSCreateSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSCreateSerial
    {
        int SSSPOSCreateSerialSp(string POSNum,
                                 int? TransNum,
                                 string Item,
                                 string SerNum,
                                 decimal? QtyShippedConv,
                                 byte? Selected,
                                 ref string Infobar);
    }

    public class SSSPOSCreateSerial : ISSSPOSCreateSerial
    {
        readonly IApplicationDB appDB;

        public SSSPOSCreateSerial(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSCreateSerialSp(string POSNum,
                                        int? TransNum,
                                        string Item,
                                        string SerNum,
                                        decimal? QtyShippedConv,
                                        byte? Selected,
                                        ref string Infobar)
        {
            POSMNumType _POSNum = POSNum;
            POSMTransNumType _TransNum = TransNum;
            ItemType _Item = Item;
            SerNumType _SerNum = SerNum;
            QtyUnitType _QtyShippedConv = QtyShippedConv;
            ListYesNoType _Selected = Selected;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSCreateSerialSp";

                appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyShippedConv", _QtyShippedConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
