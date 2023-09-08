//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROCustPoExistsWarning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSROCustPoExistsWarning
    {
        int SSSFSSROCustPoExistsWarningSp(string SroNum,
                                          string CustPo,
                                          string CustNum,
                                          ref string Infobar);
    }

    public class SSSFSSROCustPoExistsWarning : ISSSFSSROCustPoExistsWarning
    {
        readonly IApplicationDB appDB;

        public SSSFSSROCustPoExistsWarning(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSROCustPoExistsWarningSp(string SroNum,
                                                 string CustPo,
                                                 string CustNum,
                                                 ref string Infobar)
        {
            FSSRONumType _SroNum = SroNum;
            CustPoType _CustPo = CustPo;
            CustNumType _CustNum = CustNum;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSROCustPoExistsWarningSp";

                appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
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
