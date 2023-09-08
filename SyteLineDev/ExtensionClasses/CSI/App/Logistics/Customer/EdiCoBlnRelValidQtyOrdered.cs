//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoBlnRelValidQtyOrdered.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEdiCoBlnRelValidQtyOrdered
    {
        int EdiCoBlnRelValidQtyOrderedSp(string CustNum,
                                         string CoNum,
                                         short? CoLine,
                                         short? CoRelease,
                                         string Item,
                                         string UM,
                                         decimal? NewQtyOrderedConv,
                                         ref decimal? TotQtyOrderedConv,
                                         ref string Infobar);
    }

    public class EdiCoBlnRelValidQtyOrdered : IEdiCoBlnRelValidQtyOrdered
    {
        readonly IApplicationDB appDB;

        public EdiCoBlnRelValidQtyOrdered(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EdiCoBlnRelValidQtyOrderedSp(string CustNum,
                                                string CoNum,
                                                short? CoLine,
                                                short? CoRelease,
                                                string Item,
                                                string UM,
                                                decimal? NewQtyOrderedConv,
                                                ref decimal? TotQtyOrderedConv,
                                                ref string Infobar)
        {
            CustNumType _CustNum = CustNum;
            CoNumType _CoNum = CoNum;
            CoLineType _CoLine = CoLine;
            CoReleaseType _CoRelease = CoRelease;
            ItemType _Item = Item;
            UMType _UM = UM;
            QtyUnitType _NewQtyOrderedConv = NewQtyOrderedConv;
            QtyUnitType _TotQtyOrderedConv = TotQtyOrderedConv;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EdiCoBlnRelValidQtyOrderedSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewQtyOrderedConv", _NewQtyOrderedConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TotQtyOrderedConv", _TotQtyOrderedConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                TotQtyOrderedConv = _TotQtyOrderedConv;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
