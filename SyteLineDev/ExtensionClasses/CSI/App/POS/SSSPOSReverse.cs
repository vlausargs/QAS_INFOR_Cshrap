//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSReverse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSReverse
    {
        int SSSPOSReverseSp(string POSNum,
                            ref string NewPOSNum,
                            string Drawer,
                            ref string Infobar);
    }

    public class SSSPOSReverse : ISSSPOSReverse
    {
        readonly IApplicationDB appDB;

        public SSSPOSReverse(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSReverseSp(string POSNum,
                                   ref string NewPOSNum,
                                   string Drawer,
                                   ref string Infobar)
        {
            POSMNumType _POSNum = POSNum;
            POSMNumType _NewPOSNum = NewPOSNum;
            POSMDrawerType _Drawer = Drawer;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSReverseSp";

                appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewPOSNum", _NewPOSNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Drawer", _Drawer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                NewPOSNum = _NewPOSNum;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
