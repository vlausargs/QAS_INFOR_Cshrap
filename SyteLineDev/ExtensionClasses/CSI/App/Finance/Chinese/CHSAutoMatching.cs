//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSAutoMatching.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSAutoMatching
    {
        int CHSAutoMatchingSp(ref GenericIntType PMatchCount);
    }

    public class CHSAutoMatching : ICHSAutoMatching
    {
        readonly IApplicationDB appDB;

        public CHSAutoMatching(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSAutoMatchingSp(ref GenericIntType PMatchCount)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSAutoMatchingSp";

                appDB.AddCommandParameter(cmd, "PMatchCount", PMatchCount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
