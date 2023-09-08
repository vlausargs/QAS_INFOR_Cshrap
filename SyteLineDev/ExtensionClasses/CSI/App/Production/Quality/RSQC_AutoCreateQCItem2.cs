//PROJECT NAME: CSIRSQCS
//CLASS NAME: RSQC_AutoCreateQCItem2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Quality
{
    public interface IRSQC_AutoCreateQCItem2
    {
        int RSQC_AutoCreateQCItem2Sp(string i_po,
                                     short? i_line,
                                     ref string o_messages,
                                     ref string Infobar);
    }

    public class RSQC_AutoCreateQCItem2 : IRSQC_AutoCreateQCItem2
    {
        readonly IApplicationDB appDB;

        public RSQC_AutoCreateQCItem2(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RSQC_AutoCreateQCItem2Sp(string i_po,
                                            short? i_line,
                                            ref string o_messages,
                                            ref string Infobar)
        {
            PoNumType _i_po = i_po;
            PoLineType _i_line = i_line;
            InfobarType _o_messages = o_messages;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RSQC_AutoCreateQCItem2Sp";

                appDB.AddCommandParameter(cmd, "i_po", _i_po, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "i_line", _i_line, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "o_messages", _o_messages, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                o_messages = _o_messages;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
