//PROJECT NAME: CSIProduct
//CLASS NAME: ValidateTargetPsNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IValidateTargetPsNumForCopy
    {
        int ValidateTargetPsNumForCopySp(ref PsNumType PsNum,
                                         PsNumType FROMPsNum,
                                         ref Infobar Infobar);
    }

    public class ValidateTargetPsNumForCopy : IValidateTargetPsNumForCopy
    {
        readonly IApplicationDB appDB;

        public ValidateTargetPsNumForCopy(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateTargetPsNumForCopySp(ref PsNumType PsNum,
                                                PsNumType FROMPsNum,
                                                ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateTargetPsNumForCopySp";

                appDB.AddCommandParameter(cmd, "PsNum", PsNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FROMPsNum", FROMPsNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
