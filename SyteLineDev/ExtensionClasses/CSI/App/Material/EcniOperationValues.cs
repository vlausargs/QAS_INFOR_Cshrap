//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniOperationValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniOperationValues
    {
        int EcniOperationValuesSp(LongListType InJob,
                                  LongListType InSuffix,
                                  LongListType InOperNum,
                                  ref LongListType OutWc,
                                  ref LongListType OutBflushType,
                                  ref RunHoursPiecesType OutRunMchHrs,
                                  ref RunHoursPiecesType OutRunLbrHrs,
                                  ref LongListType OutRunBasisMch,
                                  ref LongListType OutRunBasisLbr,
                                  ref LongListType OutEffDate,
                                  ref LongListType OutObsDate,
                                  ref LongListType OutMoveHrs,
                                  ref LongListType OutQueueHrs,
                                  ref LongListType OutSetupHrs,
                                  ref LongListType OutFinishHrs,
                                  ref LongListType OutOffsetHrs,
                                  ref LongListType OutSchedHrs,
                                  ref DescriptionType OutWcDesc);
    }

    public class EcniOperationValues : IEcniOperationValues
    {
        readonly IApplicationDB appDB;

        public EcniOperationValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniOperationValuesSp(LongListType InJob,
                                         LongListType InSuffix,
                                         LongListType InOperNum,
                                         ref LongListType OutWc,
                                         ref LongListType OutBflushType,
                                         ref RunHoursPiecesType OutRunMchHrs,
                                         ref RunHoursPiecesType OutRunLbrHrs,
                                         ref LongListType OutRunBasisMch,
                                         ref LongListType OutRunBasisLbr,
                                         ref LongListType OutEffDate,
                                         ref LongListType OutObsDate,
                                         ref LongListType OutMoveHrs,
                                         ref LongListType OutQueueHrs,
                                         ref LongListType OutSetupHrs,
                                         ref LongListType OutFinishHrs,
                                         ref LongListType OutOffsetHrs,
                                         ref LongListType OutSchedHrs,
                                         ref DescriptionType OutWcDesc)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniOperationValuesSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutWc", OutWc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutBflushType", OutBflushType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutRunMchHrs", OutRunMchHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutRunLbrHrs", OutRunLbrHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutRunBasisMch", OutRunBasisMch, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutRunBasisLbr", OutRunBasisLbr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutEffDate", OutEffDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutObsDate", OutObsDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutMoveHrs", OutMoveHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutQueueHrs", OutQueueHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutSetupHrs", OutSetupHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutFinishHrs", OutFinishHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutOffsetHrs", OutOffsetHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutSchedHrs", OutSchedHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutWcDesc", OutWcDesc, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
