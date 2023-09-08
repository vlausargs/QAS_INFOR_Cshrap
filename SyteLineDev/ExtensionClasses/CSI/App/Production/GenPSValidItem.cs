//PROJECT NAME: CSIProduct
//CLASS NAME: GenPSValidItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IGenPSValidItem
    {
        int GenPSValidItemSp(PsStatusType PsGenStat,
                             SortDirectionPlusType PsGenType,
                             ref ItemType InItem,
                             ref UMType ItemUM,
                             ref QtyUnitType GenQty,
                             ref RunRateType ItemRatePerDay,
                             ref DateType OutFromDate,
                             ref DateType OutToDate,
                             ref DateType MDate,
                             ref MdayNumType MdayNum,
                             ref MdaysType Freq,
                             ref PsNumType PsNum,
                             ref InfobarType Infobar);
    }

    public class GenPSValidItem : IGenPSValidItem
    {
        readonly IApplicationDB appDB;

        public GenPSValidItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GenPSValidItemSp(PsStatusType PsGenStat,
                                    SortDirectionPlusType PsGenType,
                                    ref ItemType InItem,
                                    ref UMType ItemUM,
                                    ref QtyUnitType GenQty,
                                    ref RunRateType ItemRatePerDay,
                                    ref DateType OutFromDate,
                                    ref DateType OutToDate,
                                    ref DateType MDate,
                                    ref MdayNumType MdayNum,
                                    ref MdaysType Freq,
                                    ref PsNumType PsNum,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GenPSValidItemSp";

                appDB.AddCommandParameter(cmd, "PsGenStat", PsGenStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PsGenType", PsGenType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InItem", InItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemUM", ItemUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GenQty", GenQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemRatePerDay", ItemRatePerDay, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutFromDate", OutFromDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutToDate", OutToDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MDate", MDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MdayNum", MdayNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Freq", Freq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PsNum", PsNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
