//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQUpdateLineBrkQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQUpdateLineBrkQty
    {
        int SSSRFQUpdateLineBrkQtySp(string RFQNum,
                                     int? RFQLine,
                                     decimal? BrkQtyConv1,
                                     decimal? BrkQtyConv2,
                                     decimal? BrkQtyConv3,
                                     decimal? BrkQtyConv4,
                                     decimal? BrkQtyConv5,
                                     decimal? BrkQtyConv6,
                                     decimal? BrkQtyConv7,
                                     decimal? BrkQtyConv8,
                                     decimal? BrkQtyConv9,
                                     decimal? BrkQtyConv10,
                                     ref string Infobar);
    }

    public class SSSRFQUpdateLineBrkQty : ISSSRFQUpdateLineBrkQty
    {
        readonly IApplicationDB appDB;

        public SSSRFQUpdateLineBrkQty(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRFQUpdateLineBrkQtySp(string RFQNum,
                                            int? RFQLine,
                                            decimal? BrkQtyConv1,
                                            decimal? BrkQtyConv2,
                                            decimal? BrkQtyConv3,
                                            decimal? BrkQtyConv4,
                                            decimal? BrkQtyConv5,
                                            decimal? BrkQtyConv6,
                                            decimal? BrkQtyConv7,
                                            decimal? BrkQtyConv8,
                                            decimal? BrkQtyConv9,
                                            decimal? BrkQtyConv10,
                                            ref string Infobar)
        {
            RFQNumType _RFQNum = RFQNum;
            RFQLineType _RFQLine = RFQLine;
            QtyUnitType _BrkQtyConv1 = BrkQtyConv1;
            QtyUnitType _BrkQtyConv2 = BrkQtyConv2;
            QtyUnitType _BrkQtyConv3 = BrkQtyConv3;
            QtyUnitType _BrkQtyConv4 = BrkQtyConv4;
            QtyUnitType _BrkQtyConv5 = BrkQtyConv5;
            QtyUnitType _BrkQtyConv6 = BrkQtyConv6;
            QtyUnitType _BrkQtyConv7 = BrkQtyConv7;
            QtyUnitType _BrkQtyConv8 = BrkQtyConv8;
            QtyUnitType _BrkQtyConv9 = BrkQtyConv9;
            QtyUnitType _BrkQtyConv10 = BrkQtyConv10;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQUpdateLineBrkQtySp";

                appDB.AddCommandParameter(cmd, "RFQNum", _RFQNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RFQLine", _RFQLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv1", _BrkQtyConv1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv2", _BrkQtyConv2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv3", _BrkQtyConv3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv4", _BrkQtyConv4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv5", _BrkQtyConv5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv6", _BrkQtyConv6, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv7", _BrkQtyConv7, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv8", _BrkQtyConv8, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv9", _BrkQtyConv9, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQtyConv10", _BrkQtyConv10, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
