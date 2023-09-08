//PROJECT NAME: CSIMaterial
//CLASS NAME: RSQC_QCCheckTO2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRSQC_QCCheckTO2
    {
        int RSQC_QCCheckTO2Sp(PoNumType i_ToNum,
                              PoLineType i_ToLine,
                              InfobarType i_ToRelease,
                              QtyUnitNoNegType i_Qty,
                              LocType i_Loc,
                              LotType i_Lot,
                              IntType i_Seq,
                              WhseType i_Whse,
                              SiteType i_Site,
                              ref LocType o_Loc,
                              ref IntType o_IsQC,
                              ref InfobarType Infobar);
    }

    public class RSQC_QCCheckTO2 : IRSQC_QCCheckTO2
    {
        readonly IApplicationDB appDB;

        public RSQC_QCCheckTO2(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RSQC_QCCheckTO2Sp(PoNumType i_ToNum,
                                     PoLineType i_ToLine,
                                     InfobarType i_ToRelease,
                                     QtyUnitNoNegType i_Qty,
                                     LocType i_Loc,
                                     LotType i_Lot,
                                     IntType i_Seq,
                                     WhseType i_Whse,
                                     SiteType i_Site,
                                     ref LocType o_Loc,
                                     ref IntType o_IsQC,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RSQC_QCCheckTO2Sp";

                appDB.AddCommandParameter(cmd, "i_ToNum", i_ToNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_ToLine", i_ToLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_ToRelease", i_ToRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Qty", i_Qty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Loc", i_Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Lot", i_Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Seq", i_Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Whse", i_Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_Site", i_Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "o_Loc", o_Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "o_IsQC", o_IsQC, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
