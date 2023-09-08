//PROJECT NAME: CSIProduct
//CLASS NAME: WcEopCostLasttran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IWcEopCostLasttran
    {
        int WcEopCostLasttranSp(ref byte? TAsked,
                                ref string PromptMsg,
                                ref string PromptButtons,
                                ref string Infobar);
    }

    public class WcEopCostLasttran : IWcEopCostLasttran
    {
        readonly IApplicationDB appDB;

        public WcEopCostLasttran(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int WcEopCostLasttranSp(ref byte? TAsked,
                                       ref string PromptMsg,
                                       ref string PromptButtons,
                                       ref string Infobar)
        {
            ListYesNoType _TAsked = TAsked;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WcEopCostLasttranSp";

                appDB.AddCommandParameter(cmd, "TAsked", _TAsked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                TAsked = _TAsked;
                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
