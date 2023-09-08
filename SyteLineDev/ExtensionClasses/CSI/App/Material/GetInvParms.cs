//PROJECT NAME: CSIMaterial
//CLASS NAME: GetInvParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetInvParms
    {
        int GetInvParmsSp(ref EcnModeType LocalEcnJob,
                          ref LocType LocalBflushLoc,
                          ref ListYesNoType LocalNegFlag,
                          ref WhseType LocalDefWhse,
                          ref EcnModeType LocalEcnStd,
                          ref ListYesNoType LocalPrintBarcodes,
                          ref LocType LocalPackLoc,
                          ref LocType LocalShipLoc);
    }

    public class GetInvParms : IGetInvParms
    {
        readonly IApplicationDB appDB;

        public GetInvParms(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetInvParmsSp(ref EcnModeType LocalEcnJob,
                                 ref LocType LocalBflushLoc,
                                 ref ListYesNoType LocalNegFlag,
                                 ref WhseType LocalDefWhse,
                                 ref EcnModeType LocalEcnStd,
                                 ref ListYesNoType LocalPrintBarcodes,
                                 ref LocType LocalPackLoc,
                                 ref LocType LocalShipLoc)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetInvParmsSp";

                appDB.AddCommandParameter(cmd, "LocalEcnJob", LocalEcnJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalBflushLoc", LocalBflushLoc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalNegFlag", LocalNegFlag, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalDefWhse", LocalDefWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalEcnStd", LocalEcnStd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalPrintBarcodes", LocalPrintBarcodes, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalPackLoc", LocalPackLoc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocalShipLoc", LocalShipLoc, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
