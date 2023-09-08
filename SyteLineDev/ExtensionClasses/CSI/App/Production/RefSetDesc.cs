//PROJECT NAME: Data
//CLASS NAME: RefSetDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
    public class RefSetDesc : IRefSetDesc
    {
        readonly IApplicationDB appDB;


        public RefSetDesc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string RefSetDescSp(
            string JobOrdType,
            string JobOrdTypeDesc,
            string JobOrdNum,
            int? JobOrdLine,
            int? JobOrdRelease)
        {
            RefTypeIJKPRTType _JobOrdType = JobOrdType;
            StringType _JobOrdTypeDesc = JobOrdTypeDesc;
            CoProjTrnNumType _JobOrdNum = JobOrdNum;
            CoProjTaskTrnLineType _JobOrdLine = JobOrdLine;
            CoReleaseType _JobOrdRelease = JobOrdRelease;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[RefSetDescSp](@JobOrdType, @JobOrdTypeDesc, @JobOrdNum, @JobOrdLine, @JobOrdRelease)";

                appDB.AddCommandParameter(cmd, "JobOrdType", _JobOrdType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobOrdTypeDesc", _JobOrdTypeDesc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobOrdNum", _JobOrdNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobOrdLine", _JobOrdLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobOrdRelease", _JobOrdRelease, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
