//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemLifoSnap.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemLifoSnap
    {
        int ItemLifoSnapSp(ItemType ItemlifoItem,
                           AcctType ItemlifoInvAcct,
                           AcctType ItemlifoLbrAcct,
                           AcctType ItemlifoFovhdAcct,
                           AcctType ItemlifoVovhdAcct,
                           AcctType ItemlifoOutAcct,
                           WhseType ItemlifoWhse,
                           ref RowPointerType SessionId,
                           ref Infobar Infobar);
    }

    public class ItemLifoSnap : IItemLifoSnap
    {
        readonly IApplicationDB appDB;

        public ItemLifoSnap(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemLifoSnapSp(ItemType ItemlifoItem,
                                  AcctType ItemlifoInvAcct,
                                  AcctType ItemlifoLbrAcct,
                                  AcctType ItemlifoFovhdAcct,
                                  AcctType ItemlifoVovhdAcct,
                                  AcctType ItemlifoOutAcct,
                                  WhseType ItemlifoWhse,
                                  ref RowPointerType SessionId,
                                  ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemLifoSnapSp";

                appDB.AddCommandParameter(cmd, "ItemlifoItem", ItemlifoItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemlifoInvAcct", ItemlifoInvAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemlifoLbrAcct", ItemlifoLbrAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemlifoFovhdAcct", ItemlifoFovhdAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemlifoVovhdAcct", ItemlifoVovhdAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemlifoOutAcct", ItemlifoOutAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemlifoWhse", ItemlifoWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SessionId", SessionId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
