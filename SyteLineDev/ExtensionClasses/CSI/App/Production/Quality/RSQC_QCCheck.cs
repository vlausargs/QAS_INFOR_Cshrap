//PROJECT NAME: CSIRSQCS
//CLASS NAME: RSQC_QCCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Quality
{
    public interface IRSQC_QCCheck
    {
        int RSQC_QCCheckSp(string i_PoNum,
                           short? i_PoLine,
                           string i_PoRelease,
                           decimal? i_Qty,
                           string i_Loc,
                           string i_Lot,
                           int? i_Seq,
                           string i_Whse,
                           DateTime? i_transdate,
                           ref string o_Loc,
                           ref int? o_IsQC,
                           ref int? o_IsCertified,
                           ref string Infobar);
    }

    public class RSQC_QCCheck : IRSQC_QCCheck
    {
        readonly IApplicationDB appDB;

        public RSQC_QCCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RSQC_QCCheckSp(string i_PoNum,
                                  short? i_PoLine,
                                  string i_PoRelease,
                                  decimal? i_Qty,
                                  string i_Loc,
                                  string i_Lot,
                                  int? i_Seq,
                                  string i_Whse,
                                  DateTime? i_transdate,
                                  ref string o_Loc,
                                  ref int? o_IsQC,
                                  ref int? o_IsCertified,
                                  ref string Infobar)
        {
            PoNumType _i_PoNum = i_PoNum;
            PoLineType _i_PoLine = i_PoLine;
            InfobarType _i_PoRelease = i_PoRelease;
            QtyUnitNoNegType _i_Qty = i_Qty;
            LocType _i_Loc = i_Loc;
            LotType _i_Lot = i_Lot;
            IntType _i_Seq = i_Seq;
            WhseType _i_Whse = i_Whse;
            DateType _i_transdate = i_transdate;
            LocType _o_Loc = o_Loc;
            IntType _o_IsQC = o_IsQC;
            IntType _o_IsCertified = o_IsCertified;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RSQC_QCCheckSp";

                appDB.AddCommandParameter(cmd, "i_PoNum", _i_PoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_PoLine", _i_PoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_PoRelease", _i_PoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Qty", _i_Qty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Loc", _i_Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Lot", _i_Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Seq", _i_Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Whse", _i_Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_transdate", _i_transdate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "o_Loc", _o_Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "o_IsQC", _o_IsQC, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "o_IsCertified", _o_IsCertified, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                o_Loc = _o_Loc;
                o_IsQC = _o_IsQC;
                o_IsCertified = _o_IsCertified;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
