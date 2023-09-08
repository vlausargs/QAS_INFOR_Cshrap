//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQSelectBest.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQSelectBest
    {
        int SSSRFQSelectBestSp(byte? Commit,
                               string RFQNum,
                               int? RFQLine,
                               ref int? BestSeq,
                               ref string BestVendor,
                               ref string BestVendorDisp,
                               ref decimal? BestPrice,
                               ref Guid? BestRowPointer,
                               ref string Infobar);
    }

    public class SSSRFQSelectBest : ISSSRFQSelectBest
    {
        readonly IApplicationDB appDB;

        public SSSRFQSelectBest(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRFQSelectBestSp(byte? Commit,
                                      string RFQNum,
                                      int? RFQLine,
                                      ref int? BestSeq,
                                      ref string BestVendor,
                                      ref string BestVendorDisp,
                                      ref decimal? BestPrice,
                                      ref Guid? BestRowPointer,
                                      ref string Infobar)
        {
            ListYesNoType _Commit = Commit;
            RFQNumType _RFQNum = RFQNum;
            RFQLineType _RFQLine = RFQLine;
            RFQSeqType _BestSeq = BestSeq;
            VendNumType _BestVendor = BestVendor;
            NameType _BestVendorDisp = BestVendorDisp;
            CostPrcType _BestPrice = BestPrice;
            RowPointer _BestRowPointer = BestRowPointer;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQSelectBestSp";

                appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RFQNum", _RFQNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RFQLine", _RFQLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BestSeq", _BestSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BestVendor", _BestVendor, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BestVendorDisp", _BestVendorDisp, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BestPrice", _BestPrice, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BestRowPointer", _BestRowPointer, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                BestSeq = _BestSeq;
                BestVendor = _BestVendor;
                BestVendorDisp = _BestVendorDisp;
                BestPrice = _BestPrice;
                BestRowPointer = _BestRowPointer;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
