//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSMatlGetDisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSMatlGetDisc
    {
        int SSSPOSMatlGetDiscSp(string Item,
                                string CustNum,
                                ref string ItemDescription,
                                ref byte? LotTracked,
                                ref string UM,
                                ref byte? SerialTracked,
                                ref decimal? DiscPct,
                                ref string Infobar,
                                ref string TaxCode);
    }

    public class SSSPOSMatlGetDisc : ISSSPOSMatlGetDisc
    {
        readonly IApplicationDB appDB;

        public SSSPOSMatlGetDisc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSMatlGetDiscSp(string Item,
                                       string CustNum,
                                       ref string ItemDescription,
                                       ref byte? LotTracked,
                                       ref string UM,
                                       ref byte? SerialTracked,
                                       ref decimal? DiscPct,
                                       ref string Infobar,
                                       ref string TaxCode)
        {
            ItemType _Item = Item;
            CustNumType _CustNum = CustNum;
            DescriptionType _ItemDescription = ItemDescription;
            ListYesNoType _LotTracked = LotTracked;
            UMType _UM = UM;
            ListYesNoType _SerialTracked = SerialTracked;
            LineDiscType _DiscPct = DiscPct;
            Infobar _Infobar = Infobar;
            TaxCodeType _TaxCode = TaxCode;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSMatlGetDiscSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DiscPct", _DiscPct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                ItemDescription = _ItemDescription;
                LotTracked = _LotTracked;
                UM = _UM;
                SerialTracked = _SerialTracked;
                DiscPct = _DiscPct;
                Infobar = _Infobar;
                TaxCode = _TaxCode;

                return Severity;
            }
        }
    }
}
