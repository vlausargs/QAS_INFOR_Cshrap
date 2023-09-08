//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniWc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniWc
    {
        int EcniWcSp(LongListType InWc,
                     ref LongListType OutMoveHrs,
                     ref LongListType OutQueueHrs,
                     ref LongListType OutBflushType,
                     ref DescriptionType OutWcDesc);
    }

    public class EcniWc : IEcniWc
    {
        readonly IApplicationDB appDB;

        public EcniWc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniWcSp(LongListType InWc,
                            ref LongListType OutMoveHrs,
                            ref LongListType OutQueueHrs,
                            ref LongListType OutBflushType,
                            ref DescriptionType OutWcDesc)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniWcSp";

                appDB.AddCommandParameter(cmd, "InWc", InWc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutMoveHrs", OutMoveHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutQueueHrs", OutQueueHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutBflushType", OutBflushType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutWcDesc", OutWcDesc, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
