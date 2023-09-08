//PROJECT NAME: MG.MGCore
//CLASS NAME: InterpretText.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class InterpretText : IInterpretText
    {
        IApplicationDB appDB;


        public InterpretText(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string InterpretedText,
        string Infobar) InterpretTextSp(string Text,
        string UserName = null,
        string InterpretedText = null,
        string Infobar = null)
        {
            StringType _Text = Text;
            UsernameType _UserName = UserName;
            StringType _InterpretedText = InterpretedText;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InterpretTextSp";

                appDB.AddCommandParameter(cmd, "Text", _Text, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InterpretedText", _InterpretedText, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                InterpretedText = _InterpretedText;
                Infobar = _Infobar;

                return (Severity, InterpretedText, Infobar);
            }
        }
    }
}
