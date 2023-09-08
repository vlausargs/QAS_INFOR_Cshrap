//PROJECT NAME: MG.MGCore
//CLASS NAME: MsgAsk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class MsgAsk : IMsgAsk
    {
        IApplicationDB appDB;


        public MsgAsk(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar,
        string Buttons) MsgAskSp(string Infobar,
        string Buttons,
        string BaseMsg,
        string Parm1 = "",
        string Parm2 = "",
        string Parm3 = "",
        string Parm4 = "",
        string Parm5 = "",
        string Parm6 = "",
        string Parm7 = "",
        string Parm8 = "",
        string Parm9 = "",
        string Parm10 = "",
        string Parm11 = "",
        string Parm12 = "",
        string Parm13 = "",
        string Parm14 = "",
        string Parm15 = "")
        {
            Infobar _Infobar = Infobar;
            Infobar _Buttons = Buttons;
            Infobar _BaseMsg = BaseMsg;
            Infobar _Parm1 = Parm1;
            Infobar _Parm2 = Parm2;
            Infobar _Parm3 = Parm3;
            Infobar _Parm4 = Parm4;
            Infobar _Parm5 = Parm5;
            Infobar _Parm6 = Parm6;
            Infobar _Parm7 = Parm7;
            Infobar _Parm8 = Parm8;
            Infobar _Parm9 = Parm9;
            Infobar _Parm10 = Parm10;
            Infobar _Parm11 = Parm11;
            Infobar _Parm12 = Parm12;
            Infobar _Parm13 = Parm13;
            Infobar _Parm14 = Parm14;
            Infobar _Parm15 = Parm15;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MsgAskSp";

                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BaseMsg", _BaseMsg, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm1", _Parm1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm2", _Parm2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm3", _Parm3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm4", _Parm4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm5", _Parm5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm6", _Parm6, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm7", _Parm7, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm8", _Parm8, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm9", _Parm9, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm10", _Parm10, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm11", _Parm11, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm12", _Parm12, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm13", _Parm13, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm14", _Parm14, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm15", _Parm15, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;
                Buttons = _Buttons;

                return (Severity, Infobar, Buttons);
            }
        }
    }
}
