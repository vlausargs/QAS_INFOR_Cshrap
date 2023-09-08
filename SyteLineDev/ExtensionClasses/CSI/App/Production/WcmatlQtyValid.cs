//PROJECT NAME: CSIProduct
//CLASS NAME: WcmatlQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IWcmatlQtyValid
    {
        int WcmatlQtyValidSp(decimal? NewQty,
                             string PItem,
                             string UM,
                             double? UomConvFactor,
                             ref decimal? TQty,
                             ref string Infobar);
    }

    public class WcmatlQtyValid : IWcmatlQtyValid
    {
        readonly IApplicationDB appDB;

        public WcmatlQtyValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int WcmatlQtyValidSp(decimal? NewQty,
                                    string PItem,
                                    string UM,
                                    double? UomConvFactor,
                                    ref decimal? TQty,
                                    ref string Infobar)
        {
            QtyPerType _NewQty = NewQty;
            ItemType _PItem = PItem;
            UMType _UM = UM;
            UMConvFactorType _UomConvFactor = UomConvFactor;
            QtyPerType _TQty = TQty;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WcmatlQtyValidSp";

                appDB.AddCommandParameter(cmd, "NewQty", _NewQty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                TQty = _TQty;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
