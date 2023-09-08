//PROJECT NAME: CSIDataCollection
//CLASS NAME: SecondsPastMidnight.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface ISecondsPastMidnight
    {
        int SecondsPastMidnightSp(DateTimeType PostTime,
                                  ref IntType PSecondsPastMidnight);
    }

    public class SecondsPastMidnight : ISecondsPastMidnight
    {
        readonly IApplicationDB appDB;

        public SecondsPastMidnight(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SecondsPastMidnightSp(DateTimeType PostTime,
                                         ref IntType PSecondsPastMidnight)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SecondsPastMidnightSp";

                appDB.AddCommandParameter(cmd, "PostTime", PostTime, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSecondsPastMidnight", PSecondsPastMidnight, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

