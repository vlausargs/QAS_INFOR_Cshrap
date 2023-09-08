//PROJECT NAME: CSIProduct
//CLASS NAME: PendingMaterialPostValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IPendingMaterialPostValidate
    {
        int PendingMaterialPostValidateSp(StringType TransClass,
                                          DateType StartingTransDate,
                                          DateType EndingTransDate,
                                          ref InfobarType Infobar);
    }

    public class PendingMaterialPostValidate : IPendingMaterialPostValidate
    {
        readonly IApplicationDB appDB;

        public PendingMaterialPostValidate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PendingMaterialPostValidateSp(StringType TransClass,
                                                 DateType StartingTransDate,
                                                 DateType EndingTransDate,
                                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PendingMaterialPostValidateSp";

                appDB.AddCommandParameter(cmd, "TransClass", TransClass, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingTransDate", StartingTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingTransDate", EndingTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
