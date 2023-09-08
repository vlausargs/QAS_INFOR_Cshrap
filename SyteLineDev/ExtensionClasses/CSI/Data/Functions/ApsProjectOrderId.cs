//PROJECT NAME: Data
//CLASS NAME: ApsProjectOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ApsProjectOrderId : IApsProjectOrderId
    {
        readonly IApplicationDB appDB;

        public ApsProjectOrderId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string ApsProjectOrderIdFn(
            string PProjNum,
            int? PTaskNum,
            int? PSeq)
        {
            ProjNumType _PProjNum = PProjNum;
            TaskNumType _PTaskNum = PTaskNum;
            ProjmatlSeqType _PSeq = PSeq;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsProjectOrderId](@PProjNum, @PTaskNum, @PSeq)";

                appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }

        public int? ApsProjectOrderIdSp()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsProjectOrderIdSp";

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
