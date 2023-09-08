//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniGetRevisionAndItemDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniGetRevisionAndItemDesc
    {
        int EcniGetRevisionAndItemDescSp(LongListType PRevision,
                                         LongListType PItem,
                                         EcnitemTypeType PEcnitemType,
                                         ref LongListType PJob,
                                         SuffixType PSuffix,
                                         ref LongListType PDrawingNbr,
                                         ref DescriptionType PItemDesc,
                                         ref InfobarType Infobar);
    }

    public class EcniGetRevisionAndItemDesc : IEcniGetRevisionAndItemDesc
    {
        readonly IApplicationDB appDB;

        public EcniGetRevisionAndItemDesc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniGetRevisionAndItemDescSp(LongListType PRevision,
                                                LongListType PItem,
                                                EcnitemTypeType PEcnitemType,
                                                ref LongListType PJob,
                                                SuffixType PSuffix,
                                                ref LongListType PDrawingNbr,
                                                ref DescriptionType PItemDesc,
                                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniGetRevisionAndItemDescSp";

                appDB.AddCommandParameter(cmd, "PRevision", PRevision, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEcnitemType", PEcnitemType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDrawingNbr", PDrawingNbr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PItemDesc", PItemDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
