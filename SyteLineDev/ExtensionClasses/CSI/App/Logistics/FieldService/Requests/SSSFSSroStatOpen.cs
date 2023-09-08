//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroStatOpen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSroStatOpen
    {
        int SSSFSSroStatOpenSp(string iSro_Num,
                               int? iSro_Line,
                               int? iSro_Oper,
                               string iSro_Stat,
                               string Infobar);
    }

    public class SSSFSSroStatOpen : ISSSFSSroStatOpen
    {
        readonly IApplicationDB appDB;

        public SSSFSSroStatOpen(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSroStatOpenSp(string iSro_Num,
                                      int? iSro_Line,
                                      int? iSro_Oper,
                                      string iSro_Stat,
                                      string Infobar)
        {
            FSSRONumType _iSro_Num = iSro_Num;
            FSSROLineType _iSro_Line = iSro_Line;
            FSSROOperType _iSro_Oper = iSro_Oper;
            FSSROStatType _iSro_Stat = iSro_Stat;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSroStatOpenSp";

                appDB.AddCommandParameter(cmd, "iSro_Num", _iSro_Num, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSro_Line", _iSro_Line, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSro_Oper", _iSro_Oper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSro_Stat", _iSro_Stat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
