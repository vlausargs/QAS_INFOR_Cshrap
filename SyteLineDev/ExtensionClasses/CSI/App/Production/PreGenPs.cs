//PROJECT NAME: CSIProduct
//CLASS NAME: PreGenPs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IPreGenPs
    {
        int PreGenPsSp(ItemType Item,
                       QtyUnitType GenQty,
                       RunRateType RatePerDay,
                       DateType MDate,
                       MdaysType Freq,
                       PsStatusType PsGenStat,
                       PsNumType PsNum,
                       ref InfobarType PromptMsg1,
                       ref InfobarType PromptButtons1,
                       ref InfobarType PromptMsg2,
                       ref InfobarType PromptButtons2,
                       ref InfobarType Infobar);
    }

    public class PreGenPs : IPreGenPs
    {
        readonly IApplicationDB appDB;

        public PreGenPs(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PreGenPsSp(ItemType Item,
                              QtyUnitType GenQty,
                              RunRateType RatePerDay,
                              DateType MDate,
                              MdaysType Freq,
                              PsStatusType PsGenStat,
                              PsNumType PsNum,
                              ref InfobarType PromptMsg1,
                              ref InfobarType PromptButtons1,
                              ref InfobarType PromptMsg2,
                              ref InfobarType PromptButtons2,
                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PreGenPsSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GenQty", GenQty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RatePerDay", RatePerDay, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MDate", MDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Freq", Freq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PsGenStat", PsGenStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PsNum", PsNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg1", PromptMsg1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons1", PromptButtons1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg2", PromptMsg2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons2", PromptButtons2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
