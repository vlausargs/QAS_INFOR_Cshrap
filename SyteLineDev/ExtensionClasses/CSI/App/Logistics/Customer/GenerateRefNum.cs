//PROJECT NAME: CSICustomer
//CLASS NAME: GenerateRefNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IGenerateRefNum
    {
        int GenerateRefNumSp(RefTypeIJKPRTType RefType,
                             ref JobPoProjReqTrnNumType RefNum,
                             ref InfobarType Infobar);
    }

    public class GenerateRefNum : IGenerateRefNum
    {
        readonly IApplicationDB appDB;

        public GenerateRefNum(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GenerateRefNumSp(RefTypeIJKPRTType RefType,
                                    ref JobPoProjReqTrnNumType RefNum,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GenerateRefNumSp";

                appDB.AddCommandParameter(cmd, "RefType", RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", RefNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
