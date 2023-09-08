//PROJECT NAME: Logistics
//CLASS NAME: AREnd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IAREnd
    {
        (int? ReturnCode, string Infobar) AREndSp(byte? ZeroPTDOnly,
        string CustSlsBoth,
        string StatCycle,
        string BegCustNum,
        string EndCustNum,
        string BegSlsMan,
        string EndSlsMan,
        string Infobar);
    }

    public class AREnd : IAREnd
    {
        readonly IApplicationDB appDB;

        public AREnd(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) AREndSp(byte? ZeroPTDOnly,
        string CustSlsBoth,
        string StatCycle,
        string BegCustNum,
        string EndCustNum,
        string BegSlsMan,
        string EndSlsMan,
        string Infobar)
        {
            ListYesNoType _ZeroPTDOnly = ZeroPTDOnly;
            StringType _CustSlsBoth = CustSlsBoth;
            StatementCycleType _StatCycle = StatCycle;
            CustNumType _BegCustNum = BegCustNum;
            CustNumType _EndCustNum = EndCustNum;
            SlsmanType _BegSlsMan = BegSlsMan;
            SlsmanType _EndSlsMan = EndSlsMan;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AREndSp";

                appDB.AddCommandParameter(cmd, "ZeroPTDOnly", _ZeroPTDOnly, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustSlsBoth", _CustSlsBoth, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StatCycle", _StatCycle, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegCustNum", _BegCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegSlsMan", _BegSlsMan, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndSlsMan", _EndSlsMan, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
