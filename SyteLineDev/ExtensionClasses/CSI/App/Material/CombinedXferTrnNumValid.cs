//PROJECT NAME: CSIMaterial
//CLASS NAME: CombinedXferTrnNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICombinedXferTrnNumValid
    {
        int CombinedXferTrnNumValidSp(TrnNumType TrnNum,
                                      ref TrnLineType TrnLine,
                                      ref SiteType FromSite,
                                      ref WhseType FromWhse,
                                      ref SiteType ToSite,
                                      ref WhseType ToWhse,
                                      ref InfobarType Infobar,
                                      ref ListDirectIndirectNonExportType TransferExportType,
                                      ref ListYesNoType UseExistingSerials,
                                      ref SiteType FobSite);
    }

    public class CombinedXferTrnNumValid : ICombinedXferTrnNumValid
    {
        readonly IApplicationDB appDB;

        public CombinedXferTrnNumValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CombinedXferTrnNumValidSp(TrnNumType TrnNum,
                                             ref TrnLineType TrnLine,
                                             ref SiteType FromSite,
                                             ref WhseType FromWhse,
                                             ref SiteType ToSite,
                                             ref WhseType ToWhse,
                                             ref InfobarType Infobar,
                                             ref ListDirectIndirectNonExportType TransferExportType,
                                             ref ListYesNoType UseExistingSerials,
                                             ref SiteType FobSite)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CombinedXferTrnNumValidSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TrnLine", TrnLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromWhse", FromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToWhse", ToWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TransferExportType", TransferExportType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseExistingSerials", UseExistingSerials, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FobSite", FobSite, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
