//PROJECT NAME: CSICustomer
//CLASS NAME: ChargebackTypeAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IChargebackTypeAccount
    {
        int ChargebackTypeAccountSp(ChargebackTypeType ChargebackType,
                                    ref AcctType Account,
                                    ref DescriptionType Description,
                                    ref UnitCode1Type UnitCode1,
                                    ref UnitCode2Type UnitCode2,
                                    ref UnitCode3Type UnitCode3,
                                    ref UnitCode4Type UnitCode4);
    }

    public class ChargebackTypeAccount : IChargebackTypeAccount
    {
        readonly IApplicationDB appDB;

        public ChargebackTypeAccount(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ChargebackTypeAccountSp(ChargebackTypeType ChargebackType,
                                           ref AcctType Account,
                                           ref DescriptionType Description,
                                           ref UnitCode1Type UnitCode1,
                                           ref UnitCode2Type UnitCode2,
                                           ref UnitCode3Type UnitCode3,
                                           ref UnitCode4Type UnitCode4)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChargebackTypeAccountSp";

                appDB.AddCommandParameter(cmd, "ChargebackType", ChargebackType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Account", Account, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Description", Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitCode1", UnitCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitCode2", UnitCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitCode3", UnitCode3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitCode4", UnitCode4, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
