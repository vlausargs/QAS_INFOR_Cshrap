//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtPreDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtPreDelete
    {
        int AppmtPreDeleteSp(Guid? PRowid,
                             ref string Infobar,
                             ref string PromptMsg,
                             ref string PromptButtons);
    }

    public class AppmtPreDelete : IAppmtPreDelete
    {
        readonly IApplicationDB appDB;

        public AppmtPreDelete(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtPreDeleteSp(Guid? PRowid,
                                    ref string Infobar,
                                    ref string PromptMsg,
                                    ref string PromptButtons)
        {
            RowPointerType _PRowid = PRowid;
            InfobarType _Infobar = Infobar;
            InfobarType _PromptMsg = PromptMsg;
            Infobar _PromptButtons = PromptButtons;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtPreDeleteSp";

                appDB.AddCommandParameter(cmd, "PRowid", _PRowid, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;
                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;

                return Severity;
            }
        }
    }
}
