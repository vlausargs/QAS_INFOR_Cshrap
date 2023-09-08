//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckW2TaxCons.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface ICheckW2TaxCons
    {
        int CheckW2TaxConsSp(ref InfobarType PromptMsg,
                             ref InfobarType PromptButtons);
    }

    public class CheckW2TaxCons : ICheckW2TaxCons
    {
        readonly IApplicationDB appDB;

        public CheckW2TaxCons(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckW2TaxConsSp(ref InfobarType PromptMsg,
                                    ref InfobarType PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckW2TaxConsSp";

                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
