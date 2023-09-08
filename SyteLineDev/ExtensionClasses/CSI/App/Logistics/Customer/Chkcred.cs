//PROJECT NAME: Logistics.Customer
//CLASS NAME: Chkcred.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Chkcred : IChkcred
    {
        readonly IApplicationDB appDB;

        public Chkcred(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode,
            string CredHold) ChkcredSp(
            string CustNum,
            string CredHold)
        {
            CoNumType _CustNum = CustNum;
            InfobarType _CredHold = CredHold;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChkcredSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CredHold", _CredHold, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                CredHold = _CredHold;

                return (Severity, CredHold);
            }
        }
    }
}
