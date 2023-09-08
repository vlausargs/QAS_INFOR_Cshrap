//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemStatusChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemStatusChange
    {
        DataTable ItemStatusChangeSp(StringType Process,
                                     ItemType FromItem,
                                     ItemType ToItem,
                                     ProductCodeType FromProductCode,
                                     ProductCodeType ToProductCode,
                                     NameType FromBuyer,
                                     NameType ToBuyer,
                                     ItemStatusType OldStat,
                                     ItemStatusType NewStat,
                                     ReasonCodeType ReasonCode,
                                     TokenType UserID,
                                     ref InfobarType Infobar);
    }

    public class ItemStatusChange : IItemStatusChange
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public ItemStatusChange(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable ItemStatusChangeSp(StringType Process,
                                            ItemType FromItem,
                                            ItemType ToItem,
                                            ProductCodeType FromProductCode,
                                            ProductCodeType ToProductCode,
                                            NameType FromBuyer,
                                            NameType ToBuyer,
                                            ItemStatusType OldStat,
                                            ItemStatusType NewStat,
                                            ReasonCodeType ReasonCode,
                                            TokenType UserID,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemStatusChangeSp";

                appDB.AddCommandParameter(cmd, "Process", Process, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromItem", FromItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToItem", ToItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromProductCode", FromProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToProductCode", ToProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromBuyer", FromBuyer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToBuyer", ToBuyer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OldStat", OldStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewStat", NewStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReasonCode", ReasonCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserID", UserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
