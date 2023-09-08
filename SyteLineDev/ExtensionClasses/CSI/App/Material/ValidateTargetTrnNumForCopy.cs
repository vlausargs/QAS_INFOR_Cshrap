//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateTargetTrnNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IValidateTargetTrnNumForCopy
    {
        int ValidateTargetTrnNumForCopySp(TrnNumType TargetTrnNum,
                                          TrnNumType SourceTrnNum,
                                          ref Infobar Infobar);
    }

    public class ValidateTargetTrnNumForCopy : IValidateTargetTrnNumForCopy
    {
        readonly IApplicationDB appDB;

        public ValidateTargetTrnNumForCopy(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateTargetTrnNumForCopySp(TrnNumType TargetTrnNum,
                                                 TrnNumType SourceTrnNum,
                                                 ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateTargetTrnNumForCopySp";

                appDB.AddCommandParameter(cmd, "TargetTrnNum", TargetTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceTrnNum", SourceTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
