//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnShipTrnNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrnShipTrnNumValid
    {
        int TrnShipTrnNumValidSp(ref TrnNumType TrnNum,
                                 ref SiteType FromSite,
                                 ref SiteType ToSite,
                                 ref WhseType FromWhse,
                                 ref WhseType ToWhse,
                                 ref SiteType FobSite,
                                 ref InfobarType Infobar,
                                 ref ListDirectIndirectNonExportType TransferExportType,
                                 ref ListYesNoType CtrlbyExtWMS);
    }

    public class TrnShipTrnNumValid : ITrnShipTrnNumValid
    {
        readonly IApplicationDB appDB;

        public TrnShipTrnNumValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrnShipTrnNumValidSp(ref TrnNumType TrnNum,
                                        ref SiteType FromSite,
                                        ref SiteType ToSite,
                                        ref WhseType FromWhse,
                                        ref WhseType ToWhse,
                                        ref SiteType FobSite,
                                        ref InfobarType Infobar,
                                        ref ListDirectIndirectNonExportType TransferExportType,
                                        ref ListYesNoType CtrlbyExtWMS)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrnShipTrnNumValidSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromWhse", FromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToWhse", ToWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FobSite", FobSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TransferExportType", TransferExportType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CtrlbyExtWMS", CtrlbyExtWMS, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
