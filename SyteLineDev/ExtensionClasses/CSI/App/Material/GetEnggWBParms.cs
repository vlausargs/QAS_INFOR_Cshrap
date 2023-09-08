//PROJECT NAME: CSIMaterial
//CLASS NAME: GetEnggWBParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetEnggWBParms
    {
        int GetEnggWBParmsSp(ref ListYesNoType PAnyCanAdd,
                             ref ListYesNoType PAnyCanDelete,
                             ref ListYesNoType PAnyCanUpdate,
                             ref WhseType DefWhse,
                             ref EcnModeType EcnEst,
                             ref EcnModeType EcnJob,
                             ref EcnModeType EcnStd,
                             ref ListYesNoType NegFlag,
                             ref WhseType LocalDefWhse,
                             ref LocType LocalBFlushLoc,
                             ref RunBasisType Parm_RunBasis,
                             ref InfobarType Infobar);
    }

    public class GetEnggWBParms : IGetEnggWBParms
    {
        readonly IApplicationDB appDB;

        public GetEnggWBParms(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetEnggWBParmsSp(ref ListYesNoType PAnyCanAdd,
                                    ref ListYesNoType PAnyCanDelete,
                                    ref ListYesNoType PAnyCanUpdate,
                                    ref WhseType DefWhse,
                                    ref EcnModeType EcnEst,
                                    ref EcnModeType EcnJob,
                                    ref EcnModeType EcnStd,
                                    ref ListYesNoType NegFlag,
                                    ref WhseType LocalDefWhse,
                                    ref LocType LocalBFlushLoc,
                                    ref RunBasisType Parm_RunBasis,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEnggWBParmsSp";

                appDB.AddCommandParameter(cmd, "PAnyCanAdd", PAnyCanAdd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PAnyCanDelete", PAnyCanDelete, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PAnyCanUpdate", PAnyCanUpdate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DefWhse", DefWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EcnEst", EcnEst, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EcnJob", EcnJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EcnStd", EcnStd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NegFlag", NegFlag, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalDefWhse", LocalDefWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalBFlushLoc", LocalBFlushLoc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Parm_RunBasis", Parm_RunBasis, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
