//PROJECT NAME: CSIFinance
//CLASS NAME: RemoveAccountUnitCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IRemoveAccountUnitCodes
    {
        int RemoveAccountUnitCodesSp(AcctType BegAcct,
                                     AcctType EndAcct,
                                     IntType UnitNumber,
                                     UnitCode1Type UnitCode,
                                     ref InfobarType Infobar);
    }

    public class RemoveAccountUnitCodes : IRemoveAccountUnitCodes
    {
        readonly IApplicationDB appDB;

        public RemoveAccountUnitCodes(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RemoveAccountUnitCodesSp(AcctType BegAcct,
                                            AcctType EndAcct,
                                            IntType UnitNumber,
                                            UnitCode1Type UnitCode,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemoveAccountUnitCodesSp";

                appDB.AddCommandParameter(cmd, "BegAcct", BegAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndAcct", EndAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UnitNumber", UnitNumber, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UnitCode", UnitCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
