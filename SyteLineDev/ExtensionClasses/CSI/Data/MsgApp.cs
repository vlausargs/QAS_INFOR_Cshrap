using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data
{
    public interface IMsgApp
    {
        (int ReturnCode, string Infobar) MsgAppSp(string Infobar, string messageId, params object[] args);
        (int ReturnCode, string Infobar) MsgAppSp(string Infobar, string BaseMsg, string Parm1 = "",string Parm2 = "",string Parm3 = "",string Parm4 = "",string Parm5 = "",string Parm6 = "",string Parm7 = "",string Parm8 = "",string Parm9 = "",string Parm10 = "",string Parm11 = "",string Parm12 = "",string Parm13 = "",string Parm14 = "",string Parm15 = "");
    }

    public class MsgApp : IMsgApp
    {
        readonly IApplicationDB appDB;

        public MsgApp(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int ReturnCode, string Infobar) MsgAppSp(string Infobar, string messageId, params object[] args)
        {
            int messageSeverity = 0;

            var infobar = this.appDB.GetMessage(messageId, args);
            if(string.IsNullOrEmpty(Infobar) == false)
            {
                infobar = Infobar + Environment.NewLine + Environment.NewLine + (infobar ?? " "); 
            }
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("SELECT MessageSeverity FROM ObjectMainMessages WHERE ObjectName = '{0}'", messageId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        messageSeverity = (int)reader[0];
                    }
                }
                return (messageSeverity, infobar);
            }
        }
        public (int ReturnCode, string Infobar) MsgAppSp(string Infobar, string BaseMsg, string Parm1 = "", string Parm2 = "", string Parm3 = "", string Parm4 = "", string Parm5 = "", string Parm6 = "", string Parm7 = "", string Parm8 = "", string Parm9 = "", string Parm10 = "", string Parm11 = "", string Parm12 = "", string Parm13 = "", string Parm14 = "", string Parm15 = "")
        {
            int messageSeverity = 0;

            object[] args = new object[] { Parm1, Parm2, Parm3, Parm4, Parm5, Parm6, Parm7, Parm8, Parm9, Parm10, Parm11, Parm12, Parm13, Parm14, Parm15 };

            var infobar = this.appDB.GetMessage(BaseMsg, args);
            if (string.IsNullOrEmpty(Infobar) == false)
            {
                infobar = Infobar + Environment.NewLine + Environment.NewLine + (infobar??" ");
            }
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("SELECT MessageSeverity FROM ObjectMainMessages WHERE ObjectName = '{0}'", BaseMsg);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        messageSeverity = (int)reader[0];
                    }
                }
                return (messageSeverity, infobar);
            }
        }
    }
}
