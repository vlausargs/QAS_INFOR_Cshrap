//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXRtnOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXRtnOne
    {
        int SSSRMXRtnOneSp(decimal? ReturnSeq,
                           DateTime? ReturnDate,
                           decimal? QtyToReturnConv,
                           string Whse,
                           string Loc,
                           string Lot,
                           string UM,
                           byte? Reverse,
                           ref string Infobar);
    }

    public class SSSRMXRtnOne : ISSSRMXRtnOne
    {
        readonly IApplicationDB appDB;

        public SSSRMXRtnOne(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXRtnOneSp(decimal? ReturnSeq,
                                  DateTime? ReturnDate,
                                  decimal? QtyToReturnConv,
                                  string Whse,
                                  string Loc,
                                  string Lot,
                                  string UM,
                                  byte? Reverse,
                                  ref string Infobar)
        {
            RMXSeqType _ReturnSeq = ReturnSeq;
            DateType _ReturnDate = ReturnDate;
            QtyUnitType _QtyToReturnConv = QtyToReturnConv;
            WhseType _Whse = Whse;
            LocType _Loc = Loc;
            LotType _Lot = Lot;
            UMType _UM = UM;
            ListYesNoType _Reverse = Reverse;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXRtnOneSp";

                appDB.AddCommandParameter(cmd, "ReturnSeq", _ReturnSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReturnDate", _ReturnDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyToReturnConv", _QtyToReturnConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Reverse", _Reverse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
