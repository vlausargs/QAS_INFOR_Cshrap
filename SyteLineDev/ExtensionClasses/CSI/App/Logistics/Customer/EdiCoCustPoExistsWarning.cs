//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoCustPoExistsWarning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEdiCoCustPoExistsWarning
    {
        int EdiCoCustPoExistsWarningSp(string CoNum,
                                       string CustPo,
                                       string CustNum,
                                       ref string Infobar);
    }

    public class EdiCoCustPoExistsWarning : IEdiCoCustPoExistsWarning
    {
        readonly IApplicationDB appDB;

        public EdiCoCustPoExistsWarning(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EdiCoCustPoExistsWarningSp(string CoNum,
                                              string CustPo,
                                              string CustNum,
                                              ref string Infobar)
        {
            CoNumType _CoNum = CoNum;
            CustPoType _CustPo = CustPo;
            CustNumType _CustNum = CustNum;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EdiCoCustPoExistsWarningSp";

                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
