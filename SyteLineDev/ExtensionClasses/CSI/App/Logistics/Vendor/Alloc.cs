//PROJECT NAME: CSIVendor
//CLASS NAME: Alloc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAlloc
    {
        int AllocSp(string CurPoNum,
                    ref int? ProcessLevel,
                    ref string PromptMsg,
                    ref string Buttons,
                    ref string Infobar);
    }

    public class Alloc : IAlloc
    {
        readonly IApplicationDB appDB;

        public Alloc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AllocSp(string CurPoNum,
                           ref int? ProcessLevel,
                           ref string PromptMsg,
                           ref string Buttons,
                           ref string Infobar)
        {
            PoNumType _CurPoNum = CurPoNum;
            IntType _ProcessLevel = ProcessLevel;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _Buttons = Buttons;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AllocSp";

                appDB.AddCommandParameter(cmd, "CurPoNum", _CurPoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProcessLevel", _ProcessLevel, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                ProcessLevel = _ProcessLevel;
                PromptMsg = _PromptMsg;
                Buttons = _Buttons;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
