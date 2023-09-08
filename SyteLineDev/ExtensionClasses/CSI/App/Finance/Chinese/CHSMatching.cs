//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSMatching.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSMatching
    {
        int CHSMatchingSp(StringType PBankBookSeq,
                          StringType PBankBookRecSeq);
    }

    public class CHSMatching : ICHSMatching
    {
        readonly IApplicationDB appDB;

        public CHSMatching(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSMatchingSp(StringType PBankBookSeq,
                                 StringType PBankBookRecSeq)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSMatchingSp";

                appDB.AddCommandParameter(cmd, "PBankBookSeq", PBankBookSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankBookRecSeq", PBankBookRecSeq, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}