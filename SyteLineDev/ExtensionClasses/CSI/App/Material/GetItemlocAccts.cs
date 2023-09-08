//PROJECT NAME: CSIMaterial
//CLASS NAME: GetItemlocAccts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetItemlocAccts
    {
        int GetItemlocAcctsSp(ItemType Item,
                              WhseType Whse,
                              ref AcctType InvAcct,
                              ref AcctType LbrAcct,
                              ref AcctType FovhdAcct,
                              ref AcctType VovhdAcct,
                              ref AcctType OutAcct);
    }

    public class GetItemlocAccts : IGetItemlocAccts
    {
        readonly IApplicationDB appDB;

        public GetItemlocAccts(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetItemlocAcctsSp(ItemType Item,
                                     WhseType Whse,
                                     ref AcctType InvAcct,
                                     ref AcctType LbrAcct,
                                     ref AcctType FovhdAcct,
                                     ref AcctType VovhdAcct,
                                     ref AcctType OutAcct)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetItemlocAcctsSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvAcct", InvAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LbrAcct", LbrAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FovhdAcct", FovhdAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VovhdAcct", VovhdAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutAcct", OutAcct, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
