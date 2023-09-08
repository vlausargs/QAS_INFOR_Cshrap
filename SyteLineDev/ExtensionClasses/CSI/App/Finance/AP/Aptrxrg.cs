//PROJECT NAME: CSIVendor
//CLASS NAME: Aptrxrg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AP
{
    public interface IAptrxrg
    {
        int AptrxrgSp(ListYesNoType PAskFlag,
                      RowPointerType PRecidAptrx,
                      ref ListYesNoType RCheck1,
                      ref GenericDecimalType RSalesTax1,
                      ref ListYesNoType RCheck2,
                      ref GenericDecimalType RSalesTax2,
                      ref InfobarType PromptMsg,
                      ref InfobarType PromptButtons,
                      ref InfobarType Infobar);
    }

    public class Aptrxrg : IAptrxrg
    {
        readonly IApplicationDB appDB;

        public Aptrxrg(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AptrxrgSp(ListYesNoType PAskFlag,
                             RowPointerType PRecidAptrx,
                             ref ListYesNoType RCheck1,
                             ref GenericDecimalType RSalesTax1,
                             ref ListYesNoType RCheck2,
                             ref GenericDecimalType RSalesTax2,
                             ref InfobarType PromptMsg,
                             ref InfobarType PromptButtons,
                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AptrxrgSp";

                appDB.AddCommandParameter(cmd, "PAskFlag", PAskFlag, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRecidAptrx", PRecidAptrx, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RCheck1", RCheck1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RSalesTax1", RSalesTax1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RCheck2", RCheck2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RSalesTax2", RSalesTax2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
