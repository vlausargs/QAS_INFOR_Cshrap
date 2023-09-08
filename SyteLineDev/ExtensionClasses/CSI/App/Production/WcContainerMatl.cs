//PROJECT NAME: CSIProduct
//CLASS NAME: WcContainerMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IWcContainerMatl
    {
        int WcContainerMatlSp(string TWc,
                              string TWhse,
                              DateTime? TTransDate,
                              string TEmpNum,
                              string TAcct,
                              string TAcctUnit1,
                              string TAcctUnit2,
                              string TAcctUnit3,
                              string TAcctUnit4,
                              string SerialPrefix,
                              string ContainerNum,
                              ref string Infobar);
    }

    public class WcContainerMatl : IWcContainerMatl
    {
        readonly IApplicationDB appDB;

        public WcContainerMatl(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int WcContainerMatlSp(string TWc,
                                     string TWhse,
                                     DateTime? TTransDate,
                                     string TEmpNum,
                                     string TAcct,
                                     string TAcctUnit1,
                                     string TAcctUnit2,
                                     string TAcctUnit3,
                                     string TAcctUnit4,
                                     string SerialPrefix,
                                     string ContainerNum,
                                     ref string Infobar)
        {
            WcType _TWc = TWc;
            WhseType _TWhse = TWhse;
            DateType _TTransDate = TTransDate;
            EmpNumType _TEmpNum = TEmpNum;
            AcctType _TAcct = TAcct;
            UnitCode1Type _TAcctUnit1 = TAcctUnit1;
            UnitCode2Type _TAcctUnit2 = TAcctUnit2;
            UnitCode3Type _TAcctUnit3 = TAcctUnit3;
            UnitCode4Type _TAcctUnit4 = TAcctUnit4;
            SerialPrefixType _SerialPrefix = SerialPrefix;
            ContainerNumType _ContainerNum = ContainerNum;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WcContainerMatlSp";

                appDB.AddCommandParameter(cmd, "TWc", _TWc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TWhse", _TWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TAcct", _TAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TAcctUnit1", _TAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TAcctUnit2", _TAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TAcctUnit3", _TAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TAcctUnit4", _TAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
