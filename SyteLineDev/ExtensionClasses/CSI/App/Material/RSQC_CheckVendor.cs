//PROJECT NAME: CSIMaterial
//CLASS NAME: RSQC_CheckVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRSQC_CheckVendor
    {
        int RSQC_CheckVendorSp(PoNumType ToNum,
                               PoLineType ToLine,
                               PoReleaseType ToRelease,
                               ItemType Item,
                               VendNumType VendNum,
                               QtyUnitType QtyToShip,
                               UMType ToitemUM,
                               ref ListYesNoType NeedsQC,
                               ref ListYesNoType HoldCertificateRequired,
                               ref InfobarType Messages,
                               ref ListYesNoType Status,
                               ref InfobarType Infobar);
    }

    public class RSQC_CheckVendor : IRSQC_CheckVendor
    {
        readonly IApplicationDB appDB;

        public RSQC_CheckVendor(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RSQC_CheckVendorSp(PoNumType ToNum,
                                      PoLineType ToLine,
                                      PoReleaseType ToRelease,
                                      ItemType Item,
                                      VendNumType VendNum,
                                      QtyUnitType QtyToShip,
                                      UMType ToitemUM,
                                      ref ListYesNoType NeedsQC,
                                      ref ListYesNoType HoldCertificateRequired,
                                      ref InfobarType Messages,
                                      ref ListYesNoType Status,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RSQC_CheckVendorSp";

                appDB.AddCommandParameter(cmd, "ToNum", ToNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToLine", ToLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToRelease", ToRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendNum", VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyToShip", QtyToShip, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToitemUM", ToitemUM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NeedsQC", NeedsQC, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "HoldCertificateRequired", HoldCertificateRequired, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Messages", Messages, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Status", Status, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
